using Dapper.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
namespace Dapper.Factory
{
    public partial class DALFactory
    {
        private static readonly string path = ConfigurationManager.AppSettings["ConsoleDAL"];
        public DALFactory() { }
        public static Dapper.IDAL.IUserRoleDAL CreateUserRoleDAL()
        {
            string className = path + ".UserRoleDAL";
            return (Dapper.IDAL.IUserRoleDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}

namespace Dapper.Factory
{
    public partial class DALFactory
    {
        public static Dapper.IDAL.IUserDAL CreateUserDAL()
        {
            string className = path + ".UserDAL";
            return (Dapper.IDAL.IUserDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}

namespace Dapper.Factory
{
    public partial class DALFactory
    {
        public static Dapper.IDAL.IRolePermissionDAL CreateRolePermissionDAL()
        {
            string className = path + ".RolePermissionDAL";
            return (Dapper.IDAL.IRolePermissionDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}

namespace Dapper.Factory
{
    public partial class DALFactory
    {
        public static Dapper.IDAL.IRoleDAL CreateRoleDAL()
        {
            string className = path + ".RoleDAL";
            return (Dapper.IDAL.IRoleDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}

namespace Dapper.Factory
{
    public partial class DALFactory
    {
        public static Dapper.IDAL.IPermissionDAL CreatePermissionDAL()
        {
            string className = path + ".PermissionDAL";
            return (Dapper.IDAL.IPermissionDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}

namespace Dapper.Factory
{
    public partial class DALFactory
    {
        public static Dapper.IDAL.IMenuDAL CreateMenuDAL()
        {
            string className = path + ".MenuDAL";
            return (Dapper.IDAL.IMenuDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}
