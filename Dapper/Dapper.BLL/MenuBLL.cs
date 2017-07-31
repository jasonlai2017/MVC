using System;
using System.Data;
using System.Collections.Generic;
using Dapper.IDAL;
using Dapper.Model;
using Dapper.Factory;
using Dapper.IBLL;
using System.Text;

namespace Dapper.BLL
{
    public partial class MenuBLL
    {

        public IEnumerable<Menu> GetListByParentMenuId(int ParentMenuId)
        {
            return dal.GetListByParentMenuId(ParentMenuId);
        }
        public string GetStringByParentMenuId(int ParentMenuId)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<Menu> lst = dal.GetListByParentMenuId(ParentMenuId);
            sb.Append("{");
            foreach (var item in lst)
            {
                sb.Append(item.MenuName + ":" + item.Id + ",");
            }
            sb.Append("}");
            return sb.ToString();//{ "菜单1": 1, "菜单2": 2 }
        }
        public IEnumerable<Model.Menu> GetAllList()
        {
            return dal.GetAllList();
        }
        public bool ExsitMenu(string AreaName, string ControllerName)
        {
            return dal.ExsitMenu(AreaName, ControllerName);
        }
        public Menu GetEntityByUrl(string AreaName, string ControllerName)
        {
            return dal.GetEntityByUrl(AreaName, ControllerName);
        }
        //public IList<Model.Menu> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal)
        //{
        //    return dal.GetList(startIndex, endIndex, strWhere, out recordTotal);
        //}
    }

}