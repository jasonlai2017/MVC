using Dapper.BLL;
using Dapper.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSite;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        UserBLL bll_User = new UserBLL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user, string returnUrl, string YZM)
        {
            if (ModelState.IsValid)
            {
                bool bln = bll_User.CheckUserLogin(user.LoginName, Common.HashEncryption(user.LoginPwd), Convert.ToInt16(ConfigurationManager.AppSettings["SystemTypeId"].ToString()));

                if (bln == true && GetValidateCode() == YZM)
                {
                    //数据放入ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.LoginName,
                                                                                             DateTime.Now,
                                                                                             DateTime.Now.Add(FormsAuthentication.Timeout),
                                                                                             false, user.LoginName);
                    //数据加密
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);

                    #region 路径跳转
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    #endregion
                }
                else
                {
                    return RedirectToAction("SignIn", "Home");
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }
        }

        public ActionResult SignOff()
        {
            Dapper.Common.DataCache.RemoveCache();
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", "Home");
        }

        #region 验证码
        public ActionResult GetValidateCode(int length)
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(length);

            Session["ValidateCode"] = code;

            var bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/gif");
        }

        protected string GetValidateCode()
        {
            if (Session["ValidateCode"] != null)
                return Session["ValidateCode"].ToString();
            else
                return string.Empty;
        }
        #endregion
    }
}