using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.IBLL
{
    public partial interface IUserBLL
    {
        bool ExistsByLoginName(string LoginName);
        bool CheckUserLogin(string LoginName, string LoginPwd, int SystemTypeId);
    }
}