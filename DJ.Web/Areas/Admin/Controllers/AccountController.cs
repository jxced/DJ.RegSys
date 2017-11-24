using DJ.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DJ.Utility;
using System.Security.Cryptography;
using System.Web.WebPages;
using DJ.Web.Attributes;


namespace DJ.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken,NoCheck]
        public ActionResult Login(DJ.Models.ViewEntity.LoginVEntity entity)
        {
            ModelState.Remove("IsKeep");
            if (ModelState.IsValid)
            {
                string name,pwd;
                using (MD5CryptoServiceProvider md5 =new MD5CryptoServiceProvider())
                {
                    name = entity.Email;
                    pwd = entity.Pwd.ToMD5(md5);
                }
                var user = CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName == name).FirstOrDefault().ToPOCO();
                if (user!=null)
                {
                    if (user.UserPwd==pwd)
                    {
                        CurrentContext.SessionUserInfo= user;
                        if (entity.IsKeep)
                        {
                            CurrentContext.Cookie = user.UserId.ToString();
                        }
                        return Redirect("~/HtmlPage1.html");
                        //return RedirectToAction("");
                    }
                }
            }
            ModelState.AddModelError("", "用户名或密码错误");
            return View();
        }
        public ActionResult LoginOut()
        {
            return View();
        }
        public ActionResult Check()
        {
            string name= Request.Form["Email"];
            bool isexsit= CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName == name).Any();
            return isexsit? Content("true"):Content("false");
        }
    }
}