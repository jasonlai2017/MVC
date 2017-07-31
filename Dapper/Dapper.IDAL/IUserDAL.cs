using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.IDAL
{
    public partial interface IUserDAL
    {
        bool ExistsByLoginName(string LoginName);
        bool CheckUserLogin(string LoginName, string LoginPwd, int SystemTypeId);
    }
}
