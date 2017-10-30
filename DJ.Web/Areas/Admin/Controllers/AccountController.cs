﻿using DJ.UIHelper;
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
        public ActionResult Login(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string name,pwd;
                using (MD5CryptoServiceProvider md5 =new MD5CryptoServiceProvider())
                {
                    name = form["Email"].ToMD5(md5);
                     pwd = form["Pwd"].ToMD5(md5);
                }
                if (CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName == name).Any())
                {
                    if (CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName == pwd).Any())
                    {
                        return RedirectToAction("");
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