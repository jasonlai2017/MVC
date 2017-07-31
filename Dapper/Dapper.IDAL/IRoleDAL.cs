using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.IDAL
{
    public partial interface IRoleDAL
    {
        IEnumerable<string> GetPermissionListByRole(int RoleId, int SystemTypeId);
        bool UpdatePermissionListByRole(Role roleModel, IEnumerable<string> PermissionList);
    }
}
