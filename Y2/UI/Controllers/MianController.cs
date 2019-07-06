using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class MianController : Controller
    {
        // GET: Mian
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            string sql = "";
            string s = Request["id"];
            if (Request["id"] == null)
            {
                sql = string.Format(@"select * from dbo.Quan as qwe
inner join (select qid from dbo.RoleQuan where rid={0}) as tree
on tree.qid=qwe.id
where fid=0 ", Session["uid"]);
            }
            else
            {
                sql = string.Format(@"select * from dbo.Quan as qwe
inner join (select qid from dbo.RoleQuan where rid={0}) as tree
on tree.qid=qwe.id
where fid={1}", Session["uid"], Request["id"]);
            }
            var dt = DBhelper.Select(sql,"");
            return Content( JsonConvert.SerializeObject(dt));
        }

        //public ActionResult Index3()
        //{


        //    return Content();
        //}

    }
}