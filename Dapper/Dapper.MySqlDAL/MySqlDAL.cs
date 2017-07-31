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
    public partial class UserRoleDAL : IUserRoleDAL
    {
        public IDbConnection Conn = ConnectionFactory.CreateConnection();

        #region CRUD using raw dapper

        public int Exists(string id)
        {
            using (Conn)
            {
                string query = "SELECT count(1) FROM UserRole WHERE Id=@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public int Insert(Model.UserRole model)
        {
            using (Conn)
            {
                string query = "INSERT INTO UserRole(UserId,RoleId)VALUES(@UserId,@RoleId)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Model.UserRole model)
        {
            using (Conn)
            {
                string query = "UPDATE UserRole SET  UserId=@UserId,RoleId=@RoleId WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(Model.UserRole model)
        {
            using (Conn)
            {
                string query = "DELETE FROM UserRole WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(string id)
        {
            using (Conn)
            {
                string query = "DELETE FROM UserRole WHERE Id =@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public IList<Model.UserRole> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM UserRole";
                return Conn.Query<UserRole>(query).ToList();
            }
        }

        public IList<Model.UserRole> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append("SELECT COUNT(1) FROM UserRole ");
                sbList.Append("SELECT * FROM UserRole ");
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<UserRole> list = Conn.Query<UserRole>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public IList<Model.UserRole> GetList(int startIndex, int endIndex, string sqlCount, string sqlQuery, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append(sqlCount);
                sbList.Append(sqlQuery);
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<UserRole> list = Conn.Query<UserRole>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public Model.UserRole GetEntity(string id)
        {
            UserRole model;
            string query = "SELECT * FROM UserRole WHERE id = @id";
            using (Conn)
            {
                model = Conn.Query<UserRole>(query, new { id = id }).SingleOrDefault();
                return model;
            }
        }

        #endregion
    }

}

namespace Dapper.MySqlDAL
{
    public partial class UserDAL : IUserDAL
    {
        public IDbConnection Conn = ConnectionFactory.CreateConnection();

        #region CRUD using raw dapper

        public int Exists(string id)
        {
            using (Conn)
            {
                string query = "SELECT count(1) FROM User WHERE Id=@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public int Insert(Model.User model)
        {
            using (Conn)
            {
                string query = "INSERT INTO User(LoginName,LoginPwd,Name,Status)VALUES(@LoginName,@LoginPwd,@Name,@Status)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Model.User model)
        {
            using (Conn)
            {
                string query = "UPDATE User SET  LoginName=@LoginName,LoginPwd=@LoginPwd,Name=@Name,Status=@Status WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(Model.User model)
        {
            using (Conn)
            {
                string query = "DELETE FROM User WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(string id)
        {
            using (Conn)
            {
                string query = "DELETE FROM User WHERE Id =@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public IList<Model.User> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM User";
                return Conn.Query<User>(query).ToList();
            }
        }

        public IList<Model.User> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append("SELECT COUNT(1) FROM User ");
                sbList.Append("SELECT * FROM User ");
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<User> list = Conn.Query<User>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public IList<Model.User> GetList(int startIndex, int endIndex, string sqlCount, string sqlQuery, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append(sqlCount);
                sbList.Append(sqlQuery);
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<User> list = Conn.Query<User>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public Model.User GetEntity(string id)
        {
            User model;
            string query = "SELECT * FROM User WHERE id = @id";
            using (Conn)
            {
                model = Conn.Query<User>(query, new { id = id }).SingleOrDefault();
                return model;
            }
        }

        #endregion
    }

}

namespace Dapper.MySqlDAL
{
    public partial class RolePermissionDAL : IRolePermissionDAL
    {
        public IDbConnection Conn = ConnectionFactory.CreateConnection();

        #region CRUD using raw dapper

        public int Exists(string id)
        {
            using (Conn)
            {
                string query = "SELECT count(1) FROM RolePermission WHERE Id=@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public int Insert(Model.RolePermission model)
        {
            using (Conn)
            {
                string query = "INSERT INTO RolePermission(RoleId,PermissionCode)VALUES(@RoleId,@PermissionCode)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Model.RolePermission model)
        {
            using (Conn)
            {
                string query = "UPDATE RolePermission SET  RoleId=@RoleId,PermissionCode=@PermissionCode WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(Model.RolePermission model)
        {
            using (Conn)
            {
                string query = "DELETE FROM RolePermission WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(string id)
        {
            using (Conn)
            {
                string query = "DELETE FROM RolePermission WHERE Id =@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public IList<Model.RolePermission> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM RolePermission";
                return Conn.Query<RolePermission>(query).ToList();
            }
        }

        public IList<Model.RolePermission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append("SELECT COUNT(1) FROM RolePermission ");
                sbList.Append("SELECT * FROM RolePermission ");
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<RolePermission> list = Conn.Query<RolePermission>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public IList<Model.RolePermission> GetList(int startIndex, int endIndex, string sqlCount, string sqlQuery, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append(sqlCount);
                sbList.Append(sqlQuery);
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<RolePermission> list = Conn.Query<RolePermission>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public Model.RolePermission GetEntity(string id)
        {
            RolePermission model;
            string query = "SELECT * FROM RolePermission WHERE id = @id";
            using (Conn)
            {
                model = Conn.Query<RolePermission>(query, new { id = id }).SingleOrDefault();
                return model;
            }
        }

        #endregion
    }

}

namespace Dapper.MySqlDAL
{
    public partial class RoleDAL : IRoleDAL
    {
        public IDbConnection Conn = ConnectionFactory.CreateConnection();

        #region CRUD using raw dapper

        public int Exists(string id)
        {
            using (Conn)
            {
                string query = "SELECT count(1) FROM Role WHERE Id=@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public int Insert(Model.Role model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Role(RoleName,IsEnabled,SystemTypeId)VALUES(@RoleName,@IsEnabled,@SystemTypeId)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Model.Role model)
        {
            using (Conn)
            {
                string query = "UPDATE Role SET  RoleName=@RoleName,IsEnabled=@IsEnabled,SystemTypeId=@SystemTypeId WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(Model.Role model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Role WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(string id)
        {
            using (Conn)
            {
                string query = "DELETE FROM Role WHERE Id =@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public IList<Model.Role> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM Role";
                return Conn.Query<Role>(query).ToList();
            }
        }

        public IList<Model.Role> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append("SELECT COUNT(1) FROM Role ");
                sbList.Append("SELECT * FROM Role ");
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<Role> list = Conn.Query<Role>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public IList<Model.Role> GetList(int startIndex, int endIndex, string sqlCount, string sqlQuery, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append(sqlCount);
                sbList.Append(sqlQuery);
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<Role> list = Conn.Query<Role>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public Model.Role GetEntity(string id)
        {
            Role model;
            string query = "SELECT * FROM Role WHERE id = @id";
            using (Conn)
            {
                model = Conn.Query<Role>(query, new { id = id }).SingleOrDefault();
                return model;
            }
        }

        #endregion
    }

}

namespace Dapper.MySqlDAL
{
    public partial class PermissionDAL : IPermissionDAL
    {
        public IDbConnection Conn = ConnectionFactory.CreateConnection();

        #region CRUD using raw dapper

        public int Exists(string id)
        {
            using (Conn)
            {
                string query = "SELECT count(1) FROM Permission WHERE Id=@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public int Insert(Model.Permission model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Permission(Code,MenuId,ControllerName,ActionName,SystemTypeId)VALUES(@Code,@MenuId,@ControllerName,@ActionName,@SystemTypeId)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Model.Permission model)
        {
            using (Conn)
            {
                string query = "UPDATE Permission SET  Code=@Code,MenuId=@MenuId,ControllerName=@ControllerName,ActionName=@ActionName,SystemTypeId=@SystemTypeId WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(Model.Permission model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Permission WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(string id)
        {
            using (Conn)
            {
                string query = "DELETE FROM Permission WHERE Id =@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public IList<Model.Permission> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM Permission";
                return Conn.Query<Permission>(query).ToList();
            }
        }

        public IList<Model.Permission> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append("SELECT COUNT(1) FROM Permission ");
                sbList.Append("SELECT * FROM Permission ");
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<Permission> list = Conn.Query<Permission>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public IList<Model.Permission> GetList(int startIndex, int endIndex, string sqlCount, string sqlQuery, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append(sqlCount);
                sbList.Append(sqlQuery);
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<Permission> list = Conn.Query<Permission>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public Model.Permission GetEntity(string id)
        {
            Permission model;
            string query = "SELECT * FROM Permission WHERE id = @id";
            using (Conn)
            {
                model = Conn.Query<Permission>(query, new { id = id }).SingleOrDefault();
                return model;
            }
        }

        #endregion
    }

}

namespace Dapper.MySqlDAL
{
    public partial class MenuDAL : IMenuDAL
    {
        public IDbConnection Conn = ConnectionFactory.CreateConnection();

        #region CRUD using raw dapper

        public int Exists(string id)
        {
            using (Conn)
            {
                string query = "SELECT count(1) FROM Menu WHERE Id=@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public int Insert(Model.Menu model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Menu(MenuName,ParentId,AreaName,ControllerName,Icon,SystemTypeId,OrderBy,IsEnabled)VALUES(@MenuName,@ParentId,@AreaName,@ControllerName,@Icon,@SystemTypeId,@OrderBy,@IsEnabled)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Model.Menu model)
        {
            using (Conn)
            {
                string query = "UPDATE Menu SET  MenuName=@MenuName,ParentId=@ParentId,AreaName=@AreaName,ControllerName=@ControllerName,Icon=@Icon,SystemTypeId=@SystemTypeId,OrderBy=@OrderBy,IsEnabled=@IsEnabled WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(Model.Menu model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Menu WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public int Delete(string id)
        {
            using (Conn)
            {
                string query = "DELETE FROM Menu WHERE Id =@Id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public IList<Model.Menu> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM Menu";
                return Conn.Query<Menu>(query).ToList();
            }
        }

        public IList<Model.Menu> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append("SELECT COUNT(1) FROM Menu ");
                sbList.Append("SELECT * FROM Menu ");
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<Menu> list = Conn.Query<Menu>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public IList<Model.Menu> GetList(int startIndex, int endIndex, string sqlCount, string sqlQuery, string strWhere, out int recordTotal)
        {
            using (Conn)
            {
                StringBuilder sbCount = new StringBuilder();
                StringBuilder sbList = new StringBuilder();
                sbCount.Append(sqlCount);
                sbList.Append(sqlQuery);
                if (string.IsNullOrEmpty(strWhere) == false)
                {
                    sbCount.Append(" WHERE " + strWhere);
                    sbList.Append(" WHERE " + strWhere);
                }
                recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
                IList<Menu> list = Conn.Query<Menu>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
                return list;
            }
        }

        public Model.Menu GetEntity(string id)
        {
            Menu model;
            string query = "SELECT * FROM Menu WHERE id = @id";
            using (Conn)
            {
                model = Conn.Query<Menu>(query, new { id = id }).SingleOrDefault();
                return model;
            }
        }

        #endregion
    }

}
