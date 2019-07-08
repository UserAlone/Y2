using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class SalaryStandardDetailsController : Controller
    {
        // GET: SalaryStandardDetails
        public ActionResult Index()
        {
            return View();
        }
        //注册页面
        public ActionResult SalaryStandardRegPage()
        {
            return View();
        }
    }
}