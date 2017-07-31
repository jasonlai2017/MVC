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
    public partial class RoleBLL
    {
        public IEnumerable<string> GetPermissionListByRole(int RoleId, int SystemTypeId)
        {
            return dal.GetPermissionListByRole(RoleId, SystemTypeId);
        }
        public bool UpdatePermissionListByRole(Role roleModel, IEnumerable<string> PermissionList)
        {
            DataCache.RemoveCache();
            return dal.UpdatePermissionListByRole(roleModel, PermissionList);
        }
    }

}