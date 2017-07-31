using System;
using System.Data;
using System.Collections.Generic;
using Dapper.IDAL;
using Dapper.Model;
using Dapper.Factory;
using Dapper.IBLL;

namespace Dapper.BLL
{
    public partial class UserBLL
    {
        public bool ExistsByLoginName(string LoginName)
        {
            return dal.ExistsByLoginName(LoginName);
        }

        public bool CheckUserLogin(string LoginName, string LoginPwd, int SystemTypeId)
        {
            return dal.CheckUserLogin(LoginName, LoginPwd, SystemTypeId);
        }
    }
}
