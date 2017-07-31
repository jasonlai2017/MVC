using System;using DapperExtensions.Mapper;
namespace Dapper.Model{
	 	//UserRole
		public partial class UserRole
	{
		public UserRole()
		{ }
		
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id{ get; set; }   
		/// <summary>
		/// UserId
		/// </summary>
		public int? UserId{ get; set; }   
		/// <summary>
		/// RoleId
		/// </summary>
		public int? RoleId{ get; set; }   
		   
	}

	public class UserRoleMapper : ClassMapper<UserRole>
    {
        public UserRoleMapper()
        {
            Table("UserRoles");
            Map(b => b.Id).Ignore();
            AutoMap();
        }
    }
}

//using System;using DapperExtensions.Mapper;
namespace Dapper.Model{
	 	//User
		public partial class User
	{
		public User()
		{ }
		
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id{ get; set; }   
		/// <summary>
		/// LoginName
		/// </summary>
		public string LoginName{ get; set; }   
		/// <summary>
		/// LoginPwd
		/// </summary>
		public string LoginPwd{ get; set; }   
		/// <summary>
		/// Name
		/// </summary>
		public string Name{ get; set; }   
		/// <summary>
		/// Status
		/// </summary>
		public int? Status{ get; set; }   
		   
	}

	public class UserMapper : ClassMapper<User>
    {
        public UserMapper()
        {
            Table("Users");
            Map(b => b.Id).Ignore();
            AutoMap();
        }
    }
}

//using System;using DapperExtensions.Mapper;
namespace Dapper.Model{
	 	//RolePermission
		public partial class RolePermission
	{
		public RolePermission()
		{ }
		
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id{ get; set; }   
		/// <summary>
		/// RoleId
		/// </summary>
		public int? RoleId{ get; set; }   
		/// <summary>
		/// PermissionCode
		/// </summary>
		public string PermissionCode{ get; set; }   
		   
	}

	public class RolePermissionMapper : ClassMapper<RolePermission>
    {
        public RolePermissionMapper()
        {
            Table("RolePermissions");
            Map(b => b.Id).Ignore();
            AutoMap();
        }
    }
}

//using System;using DapperExtensions.Mapper;
namespace Dapper.Model{
	 	//Role
		public partial class Role
	{
		public Role()
		{ }
		
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id{ get; set; }   
		/// <summary>
		/// RoleName
		/// </summary>
		public string RoleName{ get; set; }   
		/// <summary>
		/// IsEnabled
		/// </summary>
		public int? IsEnabled{ get; set; }   
		/// <summary>
		/// SystemTypeId
		/// </summary>
		public int? SystemTypeId{ get; set; }   
		   
	}

	public class RoleMapper : ClassMapper<Role>
    {
        public RoleMapper()
        {
            Table("Roles");
            Map(b => b.Id).Ignore();
            AutoMap();
        }
    }
}

//using System;using DapperExtensions.Mapper;
namespace Dapper.Model{
	 	//Permission
		public partial class Permission
	{
		public Permission()
		{ }
		
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id{ get; set; }   
		/// <summary>
		/// Code
		/// </summary>
		public string Code{ get; set; }   
		/// <summary>
		/// MenuId
		/// </summary>
		public int? MenuId{ get; set; }   
		/// <summary>
		/// ControllerName
		/// </summary>
		public string ControllerName{ get; set; }   
		/// <summary>
		/// ActionName
		/// </summary>
		public string ActionName{ get; set; }   
		/// <summary>
		/// SystemTypeId
		/// </summary>
		public int? SystemTypeId{ get; set; }   
		   
	}

	public class PermissionMapper : ClassMapper<Permission>
    {
        public PermissionMapper()
        {
            Table("Permissions");
            Map(b => b.Id).Ignore();
            AutoMap();
        }
    }
}

//using System;using DapperExtensions.Mapper;
namespace Dapper.Model{
	 	//Menu
		public partial class Menu
	{
		public Menu()
		{ }
		
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id{ get; set; }   
		/// <summary>
		/// MenuName
		/// </summary>
		public string MenuName{ get; set; }   
		/// <summary>
		/// ParentId
		/// </summary>
		public int? ParentId{ get; set; }   
		/// <summary>
		/// AreaName
		/// </summary>
		public string AreaName{ get; set; }   
		/// <summary>
		/// ControllerName
		/// </summary>
		public string ControllerName{ get; set; }   
		/// <summary>
		/// Icon
		/// </summary>
		public string Icon{ get; set; }   
		/// <summary>
		/// SystemTypeId
		/// </summary>
		public int? SystemTypeId{ get; set; }   
		/// <summary>
		/// OrderBy
		/// </summary>
		public int? OrderBy{ get; set; }   
		/// <summary>
		/// IsEnabled
		/// </summary>
		public int? IsEnabled{ get; set; }   
		   
	}

	public class MenuMapper : ClassMapper<Menu>
    {
        public MenuMapper()
        {
            Table("Menus");
            Map(b => b.Id).Ignore();
            AutoMap();
        }
    }
}

