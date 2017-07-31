using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Newtonsoft.Json;
using Dapper.BLL;
using Dapper.Model;
using System.Security.Principal;
using System.Configuration;
using Dapper.Common;
namespace WebSite
{
    public partial class Common
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HashEncryption(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");
        }

        /// <summary>
        /// 获取当前登录用户权限
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CurrentUserPermission> GetCurrentUserPermission()
        {
            PermissionBLL bll_Permission = new PermissionBLL();
            string strCache = ConfigurationManager.AppSettings["CachePermission"].ToString();
            object objPermissionList = DataCache.GetCache(strCache);//从缓存读取
            if (objPermissionList == null)
            {
                objPermissionList = bll_Permission.GetPermissionListByUser(HttpContext.Current.User.Identity.Name);//设置功能权限;
                DataCache.SetCache(strCache, objPermissionList);// 写入缓存
            }
            return (IEnumerable<CurrentUserPermission>)objPermissionList;
        }
        public static IEnumerable<CurrentUserMenu> GetCurrentUserMenu()
        {
            PermissionBLL bll_Permission = new PermissionBLL();
            string strCache = System.Configuration.ConfigurationManager.AppSettings["CacheMenu"].ToString();
            object objMenuList = Dapper.Common.DataCache.GetCache(strCache);//从缓存读取
            if (objMenuList == null)
            {
                objMenuList = bll_Permission.GetMenuListByUser(HttpContext.Current.User.Identity.Name);//设置管理员菜单权限;
                Dapper.Common.DataCache.SetCache(strCache, objMenuList);// 写入缓存
            }
            return (IEnumerable<CurrentUserMenu>)objMenuList;
        }
    }
}
