using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IDAL {
	public partial interface IUserRoleDAL
    {
    	int Exists(string id);
    
        int Insert(UserRole model);

        int Update(UserRole model);

        int Delete(UserRole model);

        int Delete(string id);

        IList<UserRole> GetList();

		IList<UserRole> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
		
		IList<UserRole> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
        
        UserRole GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IDAL {
	public partial interface IUserDAL
    {
    	int Exists(string id);
    
        int Insert(User model);

        int Update(User model);

        int Delete(User model);

        int Delete(string id);

        IList<User> GetList();

		IList<User> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
		
		IList<User> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
        
        User GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IDAL {
	public partial interface IRolePermissionDAL
    {
    	int Exists(string id);
    
        int Insert(RolePermission model);

        int Update(RolePermission model);

        int Delete(RolePermission model);

        int Delete(string id);

        IList<RolePermission> GetList();

		IList<RolePermission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
		
		IList<RolePermission> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
        
        RolePermission GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IDAL {
	public partial interface IRoleDAL
    {
    	int Exists(string id);
    
        int Insert(Role model);

        int Update(Role model);

        int Delete(Role model);

        int Delete(string id);

        IList<Role> GetList();

		IList<Role> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
		
		IList<Role> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
        
        Role GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IDAL {
	public partial interface IPermissionDAL
    {
    	int Exists(string id);
    
        int Insert(Permission model);

        int Update(Permission model);

        int Delete(Permission model);

        int Delete(string id);

        IList<Permission> GetList();

		IList<Permission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
		
		IList<Permission> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
        
        Permission GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IDAL {
	public partial interface IMenuDAL
    {
    	int Exists(string id);
    
        int Insert(Menu model);

        int Update(Menu model);

        int Delete(Menu model);

        int Delete(string id);

        IList<Menu> GetList();

		IList<Menu> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
		
		IList<Menu> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
        
        Menu GetEntity(string id);
    }
}
