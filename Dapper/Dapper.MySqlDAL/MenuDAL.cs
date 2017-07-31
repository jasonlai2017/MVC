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
    public partial class MenuDAL
    {
        public IEnumerable<Model.Menu> GetListByParentMenuId(int ParentMenuId)
        {
            using (Conn)
            {
                string query = "SELECT * FROM Menu where IsEnabled=1 and ParentId=@ParentMenuId";
                return Conn.Query<Menu>(query, new { ParentMenuId = ParentMenuId }).ToList();
            }
        }
        public IEnumerable<Model.Menu> GetAllList()
        {
            using (Conn)
            {
                string query = @"SELECT M.*,PM.MenuName AS ParentMenuName from Menu AS M LEFT JOIN Menu as PM ON M.ParentId=PM.Id";
                return Conn.Query<Menu>(query).ToList();
            }
        }

        /// <summary>
        /// 菜单是否存在
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public bool ExsitMenu(string AreaName, string ControllerName)
        {
            using (Conn)
            {
                string query = "SELECT * FROM Menu where AreaName=@AreaName and ControllerName=@ControllerName";
                if (null != Conn.Query<Menu>(query, new { AreaName = AreaName, ControllerName = ControllerName }).SingleOrDefault())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Menu GetEntityByUrl(string AreaName, string ControllerName)
        {
            using (Conn)
            {
                Menu model;
                string query = "SELECT * FROM Menu where AreaName=@AreaName and ControllerName=@ControllerName";
                model = Conn.Query<Menu>(query, new { AreaName = AreaName, ControllerName = ControllerName }).SingleOrDefault();
                return model;
            }
        }


        //public IList<Model.Menu> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        //{
        //    using (Conn)
        //    {
        //        StringBuilder sbCount = new StringBuilder();
        //        StringBuilder sbList = new StringBuilder();
        //        sbCount.Append("SELECT COUNT(1) FROM Menu ");
        //        sbList.Append("SELECT * FROM Menu ");
        //        if (string.IsNullOrEmpty(strWhere) == false)
        //        {
        //            sbCount.Append("WHERE " + strWhere);
        //            sbList.Append("WHERE " + strWhere);
        //        }
        //        recordTotal = Conn.ExecuteScalar<int>(sbCount.ToString());
        //        IList<Model.Menu> list = Conn.Query<Menu>(sbList.ToString() + " LIMIT " + startIndex + "," + endIndex).ToList();
        //        return list;
        //    }
        //}
    }
}

