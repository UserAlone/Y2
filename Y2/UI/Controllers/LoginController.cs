using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using BAL;
using System.Data;
using Newtonsoft.Json;
using IBLL;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        userServices ub = new userServices();
        // GET: Login
        public ActionResult Index(Users us)
        {
          

            return View();
        }

        public ActionResult Index2()
        {
            string sql =string.Format( "select * from dbo.RoleUs where user_id={0}",Session["rid"]);
            var dt= DBhelper.Select(sql,"");
            return Content(JsonConvert.SerializeObject(dt)); ;
        }

        public ActionResult Logion(Users us)
        {
          List<Users> list= ub.SelectWhere(e => e.user_name == us.user_name && e.user_password==us.user_password);
            if (list.Count>0)
            {
                Users u = list[0];
                Session["uid"] = u.rid;
                Session["name"] = us.user_name;
                Session["rid"] = u.user_id;
                return Content("ok");
             
            }
            else
            {
                return View();
            }
        }
    }
}