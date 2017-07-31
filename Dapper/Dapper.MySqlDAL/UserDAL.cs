using Dapper;
using Dapper.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Factory;
using System.Data;
using Dapper.Model;
using DapperExtensions;
using DapperExtensions.Mapper;

namespace Dapper.MySqlDAL
{
    public partial class UserDAL
    {
        public bool ExistsByLoginName(string LoginName)
        {
            using (Conn)
            {
                Conn.Open();
                string query = "SELECT count(1) FROM User WHERE LoginName=@LoginName";
                int result = Conn.ExecuteScalar<int>(query, new { LoginName = LoginName });
                Conn.Close();
                return result > 0 ? true : false;
            }
        }

        public bool CheckUserLogin(string LoginName, string LoginPwd, int SystemTypeId)
        {
            using (Conn)
            {
                Conn.Open();
                string query = @"
SELECT COUNT(1) FROM User AS U
LEFT JOIN UserSystemType AS UST ON U.Id=UST.UserId AND UST.SystemTypeId=@SystemTypeId
where U.LoginName=@LoginName AND U.LoginPwd=@LoginPwd AND U.`Status`=1";
                int n = Conn.ExecuteScalar<int>(query, new { LoginName = LoginName, LoginPwd = LoginPwd, SystemTypeId = SystemTypeId });
                Conn.Close();
                return n > 0 ? true : false;
            }
        }
    }
}
