using BAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class salary_standard_detailsController : Controller
    {
        // GET: config_public_char
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            string sql = "select * from salary_standard_details";
            var dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }

        public ActionResult Delete(string id)
        {
            string sql = string.Format("delete from salary_standard_details where sdt_id='{0}'", id);
            int sc = DBhelper.InsertUpdateDelte(sql, "");
            if (sc > 0)
            {
                return Content("<script>alert('删除成功');window.location.href='/salary_standard_details/Index';</script>");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Add()
        {
           return View();
        }

        public ActionResult Add2()
        {
            string name = Request["tj11"];

            string sql = string.Format("insert into dbo.salary_standard_details (standard_name)values('{0}')",name);
            int sc = DBhelper.InsertUpdateDelte(sql, "");
            if (sc > 0)
            {
                return Content("<script>alert('添加成功'); window.location.href = '/salary_standard_details/Index';</script>");
            }
            else
            {
                return View();
            }
        }
    }
}