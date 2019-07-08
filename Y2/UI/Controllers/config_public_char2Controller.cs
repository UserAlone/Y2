using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class config_public_char2Controller : Controller
    {
        // GET: config_public_char2
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            string sql = "select * from config_public_char";
            var dt= DBhelper.Select(sql,"");
            return Content(JsonConvert.SerializeObject(dt));
        }

        public ActionResult Delete(string id)
        {
            string sql =string.Format("delete from config_public_char where pbc_id='{0}'",id);
            int sc=DBhelper.InsertUpdateDelte(sql,"");
            if (sc>0)
            {
               return Content("<script>alert('删除成功');window.location.href='/config_public_char2/Index';</script>");
            }
            else
            {
                return View();
            }
        }
    }
}