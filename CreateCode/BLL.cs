using System;using System.Data;using System.Collections.Generic;using Dapper.IDAL;using Dapper.Model;using Dapper.Factory;using Dapper.IBLL;

namespace Dapper.BLL {
    public partial class UserRoleBLL : IUserRoleBLL
    {
        private static readonly IUserRoleDAL dal = DALFactory.CreateUserRoleDAL();

		public bool Exists(string id)
		{
			return dal.Exists(id) > 0 ? true : false;
		}
        public bool Insert(UserRole model)
        {
            return dal.Insert(model) > 0 ? true : false;
        }

        public bool Update(UserRole model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        public bool Delete(UserRole model)
        {
            return dal.Delete(model) > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            return dal.Delete(id) > 0 ? true : false;
        }

        public IList<UserRole> GetList()
        {
            return dal.GetList();
        }
        
        public IList<UserRole> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, strWhere, out recordTotal);
        }
        
        public IList<UserRole> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, sqlCount, sqlQuery, strWhere, out recordTotal);
        }
        
        public UserRole GetEntity(string id)
        {
            return dal.GetEntity(id);
        }
    }

}
//using System;using System.Data;using System.Collections.Generic;using Dapper.IDAL;using Dapper.Model;using Dapper.Factory;using Dapper.IBLL;

namespace Dapper.BLL {
    public partial class UserBLL : IUserBLL
    {
        private static readonly IUserDAL dal = DALFactory.CreateUserDAL();

		public bool Exists(string id)
		{
			return dal.Exists(id) > 0 ? true : false;
		}
        public bool Insert(User model)
        {
            return dal.Insert(model) > 0 ? true : false;
        }

        public bool Update(User model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        public bool Delete(User model)
        {
            return dal.Delete(model) > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            return dal.Delete(id) > 0 ? true : false;
        }

        public IList<User> GetList()
        {
            return dal.GetList();
        }
        
        public IList<User> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, strWhere, out recordTotal);
        }
        
        public IList<User> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, sqlCount, sqlQuery, strWhere, out recordTotal);
        }
        
        public User GetEntity(string id)
        {
            return dal.GetEntity(id);
        }
    }

}
//using System;using System.Data;using System.Collections.Generic;using Dapper.IDAL;using Dapper.Model;using Dapper.Factory;using Dapper.IBLL;

namespace Dapper.BLL {
    public partial class RolePermissionBLL : IRolePermissionBLL
    {
        private static readonly IRolePermissionDAL dal = DALFactory.CreateRolePermissionDAL();

		public bool Exists(string id)
		{
			return dal.Exists(id) > 0 ? true : false;
		}
        public bool Insert(RolePermission model)
        {
            return dal.Insert(model) > 0 ? true : false;
        }

        public bool Update(RolePermission model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        public bool Delete(RolePermission model)
        {
            return dal.Delete(model) > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            return dal.Delete(id) > 0 ? true : false;
        }

        public IList<RolePermission> GetList()
        {
            return dal.GetList();
        }
        
        public IList<RolePermission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, strWhere, out recordTotal);
        }
        
        public IList<RolePermission> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, sqlCount, sqlQuery, strWhere, out recordTotal);
        }
        
        public RolePermission GetEntity(string id)
        {
            return dal.GetEntity(id);
        }
    }

}
//using System;using System.Data;using System.Collections.Generic;using Dapper.IDAL;using Dapper.Model;using Dapper.Factory;using Dapper.IBLL;

namespace Dapper.BLL {
    public partial class RoleBLL : IRoleBLL
    {
        private static readonly IRoleDAL dal = DALFactory.CreateRoleDAL();

		public bool Exists(string id)
		{
			return dal.Exists(id) > 0 ? true : false;
		}
        public bool Insert(Role model)
        {
            return dal.Insert(model) > 0 ? true : false;
        }

        public bool Update(Role model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        public bool Delete(Role model)
        {
            return dal.Delete(model) > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            return dal.Delete(id) > 0 ? true : false;
        }

        public IList<Role> GetList()
        {
            return dal.GetList();
        }
        
        public IList<Role> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, strWhere, out recordTotal);
        }
        
        public IList<Role> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, sqlCount, sqlQuery, strWhere, out recordTotal);
        }
        
        public Role GetEntity(string id)
        {
            return dal.GetEntity(id);
        }
    }

}
//using System;using System.Data;using System.Collections.Generic;using Dapper.IDAL;using Dapper.Model;using Dapper.Factory;using Dapper.IBLL;

namespace Dapper.BLL {
    public partial class PermissionBLL : IPermissionBLL
    {
        private static readonly IPermissionDAL dal = DALFactory.CreatePermissionDAL();

		public bool Exists(string id)
		{
			return dal.Exists(id) > 0 ? true : false;
		}
        public bool Insert(Permission model)
        {
            return dal.Insert(model) > 0 ? true : false;
        }

        public bool Update(Permission model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        public bool Delete(Permission model)
        {
            return dal.Delete(model) > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            return dal.Delete(id) > 0 ? true : false;
        }

        public IList<Permission> GetList()
        {
            return dal.GetList();
        }
        
        public IList<Permission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, strWhere, out recordTotal);
        }
        
        public IList<Permission> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, sqlCount, sqlQuery, strWhere, out recordTotal);
        }
        
        public Permission GetEntity(string id)
        {
            return dal.GetEntity(id);
        }
    }

}
//using System;using System.Data;using System.Collections.Generic;using Dapper.IDAL;using Dapper.Model;using Dapper.Factory;using Dapper.IBLL;

namespace Dapper.BLL {
    public partial class MenuBLL : IMenuBLL
    {
        private static readonly IMenuDAL dal = DALFactory.CreateMenuDAL();

		public bool Exists(string id)
		{
			return dal.Exists(id) > 0 ? true : false;
		}
        public bool Insert(Menu model)
        {
            return dal.Insert(model) > 0 ? true : false;
        }

        public bool Update(Menu model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        public bool Delete(Menu model)
        {
            return dal.Delete(model) > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            return dal.Delete(id) > 0 ? true : false;
        }

        public IList<Menu> GetList()
        {
            return dal.GetList();
        }
        
        public IList<Menu> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, strWhere, out recordTotal);
        }
        
        public IList<Menu> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal)
        {
            return dal.GetList(startIndex, endIndex, sqlCount, sqlQuery, strWhere, out recordTotal);
        }
        
        public Menu GetEntity(string id)
        {
            return dal.GetEntity(id);
        }
    }

}
