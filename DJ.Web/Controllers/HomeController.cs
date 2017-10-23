using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DJ.Models;
using DJ.Service;

namespace DJ.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DJ.IService.IClassInfoBLL classInfoBLL = Utility.DI.GetObject("classInfoBLL");
            DJ.IService.IServiceSession serviceSession = DJ.Utility.DI.GetObject<ServiceSession>("ServiceSession");
            serviceSession.ClassInfoBLL.Where(c => c.ClassId == 1);
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