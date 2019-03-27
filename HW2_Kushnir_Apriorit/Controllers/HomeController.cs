using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW2_Kushnir_Apriorit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//our HTTP GET
        {
            return View(model: System.IO.File.ReadAllLines(MvcApplication.FilePath).AsEnumerable().Reverse());
        }
       
        [HttpPost]
        public ActionResult Index(int i)//our HTTP POST
        {
            return View(model: System.IO.File.ReadAllLines(MvcApplication.FilePath).AsEnumerable().Reverse());
        }
    }
}