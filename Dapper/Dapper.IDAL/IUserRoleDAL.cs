using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.IDAL
{
    public partial interface IUserRoleDAL
    {
        IEnumerable<int> GetRoleListByUser(int UserId);
        bool UpdateUserRoleList(User userModel, IEnumerable<int> RoleList);
    }
}
