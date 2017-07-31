using System;
using DapperExtensions.Mapper;

using System.Security.Principal;
using System.Collections.Generic;
using Jil;
namespace Dapper.Model
{
    //User
    public partial class User
    {
        public virtual int SystemTypeId { get; set; }
        public virtual string StatusName
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "无效";
                    case 1:
                        return "有效";
                    default:
                        return "无效";
                }
            }
        }
        public virtual string ReLoginPwd { get; set; }
        public virtual string ToJsonString()
        {
            //return JsonConvert.SerializeObject(this);
            return JSON.SerializeDynamic(this);
        }
    }
    public class CurrentLoginUser
    {
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// 当前管理员菜单类
    /// </summary>
    public class CurrentUserMenu
    {
        public int? MenuId { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
    }
    public class CurrentUserPermission
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }

}
