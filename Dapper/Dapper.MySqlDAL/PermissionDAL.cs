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
    public partial class PermissionDAL
    {
        /// <summary>
        /// 获取当前管理员拥有的菜单权限列表
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public IEnumerable<CurrentUserMenu> GetMenuListByUser(string LoginName)
        {
            using (Conn)
            {
                Conn.Open();
                string query =
@"SELECT DISTINCT P.MenuId,M.MenuName,M.AreaName,M.ControllerName from Permission as P 
INNER JOIN RolePermission as RP ON RP.PermissionCode=P.Code
INNER JOIN UserRole AS UR ON UR.RoleId=RP.RoleId
INNER JOIN User AS U ON U.Id=UR.UserId AND U.`Status`=1 AND U.LoginName=@LoginName
LEFT JOIN Menu as M ON P.MenuId=M.id and M.IsEnabled=1 ORDER BY M.OrderBy ";
                IEnumerable<CurrentUserMenu> list = Conn.Query<CurrentUserMenu>(query, new { LoginName = LoginName });
                Conn.Close();
                return list;
            }
        }
        /// <summary>
        /// 获取当前管理员操作/按钮权限列表
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public IEnumerable<CurrentUserPermission> GetPermissionListByUser(string LoginName)
        {
            using (Conn)
            {
                Conn.Open();
                string query =
@"SELECT P.Code,P.ControllerName,P.ActionName from Permission as P 
INNER JOIN RolePermission as RP ON RP.PermissionCode=P.Code
INNER JOIN UserRole AS UR ON UR.RoleId=RP.RoleId
INNER JOIN User AS U ON U.Id=UR.UserId AND U.`Status`=1 AND U.LoginName=@LoginName
LEFT JOIN Menu as M ON P.MenuId=M.id and M.IsEnabled=1
WHERE LENGTH(P.ControllerName)>0 and LENGTH(P.ActionName)>0";
                IEnumerable<CurrentUserPermission> list = Conn.Query<CurrentUserPermission>(query, new { LoginName = LoginName });
                Conn.Close();
                return list;
            }
        }
        /// <summary>
        /// 根据菜单ID获取该菜单下已有的功能列表
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetActionNamesByMenu(int MenuId, int SystemTypeId, bool IsTopMenu)
        {
            using (Conn)
            {
                Conn.Open();
                string query = string.Empty;
                if (IsTopMenu)
                {
                    query = @"SELECT Code from Permission where MenuId=@MenuId AND SystemTypeId=@SystemTypeId";
                }
                else
                {
                    query = @"SELECT ActionName from Permission where MenuId=@MenuId AND SystemTypeId=@SystemTypeId AND LENGTH(ControllerName)>0";
                }
                IEnumerable<string> list = Conn.Query<string>(query, new { MenuId = MenuId, SystemTypeId = SystemTypeId });
                Conn.Close();
                return list;
            }
        }
        /// <summary>
        /// 更新菜单的具体功能
        /// </summary>
        /// <param name="menuModel"></param>
        /// <param name="ActionNameList"></param>
        /// <returns></returns>
        public bool UpdatePermissionList(Menu menuModel, IEnumerable<string> ActionNameList)
        {
            using (Conn)
            {
                Conn.Open();
                //开始事务
                IDbTransaction transaction = Conn.BeginTransaction();
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("DELETE FROM Permission WHERE MenuId=@MenuId and SystemTypeId=@SystemTypeId ;");
                    if (menuModel.ParentId > 0)
                    {//对应子菜单的操作
                        if (ActionNameList != null && ActionNameList.Count() > 0)
                        {
                            foreach (var ActionName in ActionNameList)
                            {
                                sb.Append("INSERT INTO Permission(Code,MenuId,ControllerName,ActionName,SystemTypeId)VALUES('" + menuModel.ControllerName + "_" + ActionName + "',@MenuId,@ControllerName,'" + ActionName + "',@SystemTypeId);");
                            }
                        }
                    }
                    else
                    { //对应顶级菜单的操作
                        if (ActionNameList != null && ActionNameList.Count() == 1)
                        {
                            foreach (var ActionName in ActionNameList)
                            {
                                sb.Append("INSERT INTO Permission(Code,MenuId,SystemTypeId)VALUES('" + ActionName + "',@MenuId,@SystemTypeId);");
                            }
                        }
                    }

                    Conn.Execute(
                        sb.ToString(),
                        new
                        {
                            SystemTypeId = menuModel.SystemTypeId,
                            MenuId = menuModel.Id,
                            ControllerName = menuModel.ControllerName
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
                }
            }
        }
        public IEnumerable<string> GetAllPermissionCode(int SystemTypeId)
        {
            using (Conn)
            {
                Conn.Open();
                string query =
@"SELECT `Code` FROM Permission where SystemTypeId=@SystemTypeId ";
                IEnumerable<string> list = Conn.Query<string>(query, new { SystemTypeId = SystemTypeId });
                Conn.Close();
                return list;
            }
        }
    }
}
