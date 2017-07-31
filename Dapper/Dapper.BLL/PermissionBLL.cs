using System;
using System.Data;
using System.Collections.Generic;
using Dapper.IDAL;
using Dapper.Model;
using Dapper.Factory;
using Dapper.IBLL;
using Dapper.Common;
namespace Dapper.BLL
{
    public partial class PermissionBLL : IPermissionBLL
    {
        /// <summary>
        /// 获取管理员菜单列表
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public IEnumerable<CurrentUserMenu> GetMenuListByUser(string LoginName)
        {
            return dal.GetMenuListByUser(LoginName);
        }
        /// <summary>
        /// 获取管理员操作权限列表
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public IEnumerable<CurrentUserPermission> GetPermissionListByUser(string LoginName)
        {
            return dal.GetPermissionListByUser(LoginName);
        }
        /// <summary>
        /// 根据菜单ID获取该菜单下已有的功能列表
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetActionNamesByMenu(int MenuId, int SystemTypeId, bool IsTopMenu)
        {
            return dal.GetActionNamesByMenu(MenuId, SystemTypeId, IsTopMenu);
        }

        public bool UpdatePermissionList(Menu menuModel, IEnumerable<string> ActionNameList)
        {
            DataCache.RemoveCache();
            return dal.UpdatePermissionList(menuModel, ActionNameList);
        }

        public IEnumerable<string> GetAllPermissionCode(int SystemTypeId)
        {
            return dal.GetAllPermissionCode(SystemTypeId);
        }
    }

}