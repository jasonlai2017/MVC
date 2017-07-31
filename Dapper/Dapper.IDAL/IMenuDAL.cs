using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.IDAL
{
    public partial interface IMenuDAL
    {
        IEnumerable<Menu> GetListByParentMenuId(int ParentMenuId);
        IEnumerable<Menu> GetAllList();
        bool ExsitMenu(string AreaName, string ControllerName);
        Menu GetEntityByUrl(string AreaName, string ControllerName);
        //IList<Model.Menu> GetList(int startIndex, int endIndex, string strWhere, out int recordTotal);
    }
}