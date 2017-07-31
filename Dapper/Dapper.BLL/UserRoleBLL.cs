using System;
using System.Data;
using System.Collections.Generic;
using Dapper.IDAL;
using Dapper.Model;
using Dapper.Factory;
using Dapper.IBLL;
using System.Text;

namespace Dapper.BLL
{
    public partial class UserRoleBLL
    {
        public IEnumerable<int> GetRoleListByUser(int UserId)
        {
            return dal.GetRoleListByUser(UserId);
        }
        public bool UpdateUserRoleList(User userModel, IEnumerable<int> RoleList)
        {
            return dal.UpdateUserRoleList(userModel, RoleList);
        }
    }

}