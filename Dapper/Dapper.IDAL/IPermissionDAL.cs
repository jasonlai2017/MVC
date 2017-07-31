using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.IDAL
{
    public partial interface IPermissionDAL
    {
        IEnumerable<Model.CurrentUserMenu> GetMenuListByUser(string LoginName);
        IEnumerable<Model.CurrentUserPermission> GetPermissionListByUser(string LoginName);
        IEnumerable<string> GetActionNamesByMenu(int MenuId, int SystemTypeId, bool IsTopMenu);
        bool UpdatePermissionList(Menu menuModel, IEnumerable<string> ActionNameList);
        IEnumerable<string> GetAllPermissionCode(int SystemTypeId);
    }
}