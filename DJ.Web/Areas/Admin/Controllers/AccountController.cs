﻿using DJ.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJ.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
           string name=form["UserName"];
           string pwd= form["UserPwd"];
            if (CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName ==name ).Any())
            {
                if (CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName == pwd).Any())
                {
                    return RedirectToAction("");
                }
                
            }
            return JavaScript("用户名密码不正确！");
        }
        public ActionResult LoginOut()
        {
            return View();
        }
        public ActionResult Check()
        {
            string name= Request.Form["UserName"];
            bool isexsit= CurrentContext.ServiceSession.UserInfoBLL.Where(o => o.UserName == name).Any();
            return isexsit? Content("true"):Content("false");
        }
    }
}