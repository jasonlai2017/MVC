using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.IBLL
{
    public partial interface IUserRoleBLL
    {
        IEnumerable<int> GetRoleListByUser(int UserId);
        bool UpdateUserRoleList(User userModel, IEnumerable<int> RoleList);
    }
}