using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IBLL {
	public partial interface IUserRoleBLL
    {
    	bool Exists(string id);
    	
        bool Insert(UserRole model);

        bool Update(UserRole model);

        bool Delete(UserRole model);

        bool Delete(string id);

        IList<UserRole> GetList();
        
 		IList<UserRole> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
 		
 		IList<UserRole> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
 
        UserRole GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IBLL {
	public partial interface IUserBLL
    {
    	bool Exists(string id);
    	
        bool Insert(User model);

        bool Update(User model);

        bool Delete(User model);

        bool Delete(string id);

        IList<User> GetList();
        
 		IList<User> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
 		
 		IList<User> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
 
        User GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IBLL {
	public partial interface IRolePermissionBLL
    {
    	bool Exists(string id);
    	
        bool Insert(RolePermission model);

        bool Update(RolePermission model);

        bool Delete(RolePermission model);

        bool Delete(string id);

        IList<RolePermission> GetList();
        
 		IList<RolePermission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
 		
 		IList<RolePermission> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
 
        RolePermission GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IBLL {
	public partial interface IRoleBLL
    {
    	bool Exists(string id);
    	
        bool Insert(Role model);

        bool Update(Role model);

        bool Delete(Role model);

        bool Delete(string id);

        IList<Role> GetList();
        
 		IList<Role> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
 		
 		IList<Role> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
 
        Role GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IBLL {
	public partial interface IPermissionBLL
    {
    	bool Exists(string id);
    	
        bool Insert(Permission model);

        bool Update(Permission model);

        bool Delete(Permission model);

        bool Delete(string id);

        IList<Permission> GetList();
        
 		IList<Permission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
 		
 		IList<Permission> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
 
        Permission GetEntity(string id);
    }
}
//using Dapper.Model;using System;using System.Collections.Generic;using System.Linq;using System.Text;

namespace Dapper.IBLL {
	public partial interface IMenuBLL
    {
    	bool Exists(string id);
    	
        bool Insert(Menu model);

        bool Update(Menu model);

        bool Delete(Menu model);

        bool Delete(string id);

        IList<Menu> GetList();
        
 		IList<Menu> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
 		
 		IList<Menu> GetList(int startIndex, int endIndex,string sqlCount,string sqlQuery, string strWhere, out int recordTotal);
 
        Menu GetEntity(string id);
    }
}
