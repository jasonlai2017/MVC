using Dapper;
using Dapper.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Factory;
using System.Data;
using Dapper.Model;
using DapperExtensions;
using DapperExtensions.Mapper;
namespace Dapper.MySqlDAL
{
    public partial class RoleDAL
    {
        /// <summary>
        /// 根据角色下的权限列表
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetPermissionListByRole(int RoleId, int SystemTypeId)
        {
            using (Conn)
            {
                Conn.Open();
                string query =
@"SELECT RP.PermissionCode from RolePermission AS RP
INNER JOIN Permission AS P ON P.`Code`=RP.PermissionCode AND P.SystemTypeId=@SystemTypeId
WHERE RP.RoleId=@RoleId";
                IEnumerable<string> list = Conn.Query<string>(query, new { RoleId = RoleId, SystemTypeId = SystemTypeId });
                Conn.Close();
                return list;
            }
        }
        /// <summary>
        /// 更新角色下的权限
        /// </summary>
        /// <param name="roleModel"></param>
        /// <param name="PermissionList"></param>
        /// <returns></returns>
        public bool UpdatePermissionListByRole(Role roleModel, IEnumerable<string> PermissionList)
        {

            using (Conn)
            {
                Conn.Open();
                //开始事务
                IDbTransaction transaction = Conn.BeginTransaction();
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("DELETE FROM RolePermission WHERE RoleId=@RoleId ;");
                    if (PermissionList != null && PermissionList.Count() > 0)
                    {
                        foreach (var PermissionCode in PermissionList)
                        {
                            sb.Append("INSERT INTO RolePermission(RoleId,PermissionCode)VALUES(@RoleId,'" + PermissionCode + "');");
                        }
                    }

                    Conn.Execute(
                        sb.ToString(),
                        new
                        {
                            RoleId = roleModel.Id,
                        },
                        transaction, null, null);
                    //提交事务
                    transaction.Commit();
                    Conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    //出现异常，事务Rollback
                    transaction.Rollback();
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                    return false;
                    //throw new Exception(ex.Message);
                }
            }
        }
    }
}
