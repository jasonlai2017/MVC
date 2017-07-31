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
    public partial class UserRoleDAL
    {
        /// <summary>
        /// 根据管理员ID获取RoleList
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IEnumerable<int> GetRoleListByUser(int UserId)
        {
            using (Conn)
            {
                string query = @"
SELECT UR.RoleId
FROM UserRole AS UR
LEFT JOIN `User` AS U ON U.Id=UR.UserId
LEFT JOIN Role AS R ON R.Id=UR.RoleId
where UR.UserId=@UserId AND R.IsEnabled=1";
                return Conn.Query<int>(query, new { UserId = UserId }).ToList();
            }
        }

        /// <summary>
        /// 更管理员的角色
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="RoleList"></param>
        /// <returns></returns>
        public bool UpdateUserRoleList(User userModel, IEnumerable<int> RoleList)
        {
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            using (Conn)
            {
                //开始事务
                IDbTransaction transaction = Conn.BeginTransaction();
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("DELETE FROM UserRole WHERE UserId=@UserId ;");
                    if (RoleList != null && RoleList.Count() > 0)
                    {
                        foreach (var RoleId in RoleList)
                        {
                            sb.Append("INSERT INTO UserRole(UserId,RoleId)VALUES(@UserId," + RoleId + ");");
                        }
                    }

                    Conn.Execute(
                        sb.ToString(),
                        new
                        {
                            UserId = userModel.Id
                        },
                        transaction, null, null);
                    //提交事务
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    //出现异常，事务Rollback
                    transaction.Rollback();
                    return false;
                    //throw new Exception(ex.Message);
                }
            }
        }
    }
}
