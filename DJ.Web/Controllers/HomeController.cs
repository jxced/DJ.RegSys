using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DJ.Models;
using DJ.IService;
using DJ.UIHelper;

namespace DJ.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
           CurrentContext.ServiceSession.ClassInfoBLL
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}