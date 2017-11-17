using DJ.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DJ.Utility;
using System.Security.Cryptography;

namespace DJ.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
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
                var user = CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName == name).FirstOrDefault();
                if (user!=null)
                {
                    if (user.UserPwd==pwd)
                    {
                        CurrentContext.Session[UtilityStr.USER_SESSION_KEY]= user.ToPOCO();
                        if (entity.IsKeep)
                        {
                            (user.ToPOCO() as DJ.Models.UserInfo).UserName.Cookie();
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