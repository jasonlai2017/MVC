using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.IBLL
{
    public partial interface IRoleBLL
    {
        IEnumerable<string> GetPermissionListByRole(int RoleId, int SystemTypeId);
        bool UpdatePermissionListByRole(Role roleModel, IEnumerable<string> PermissionList);
    }
}