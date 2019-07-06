using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Data;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class RoleUsController : Controller
    {
        RoleUsBLL rb = new RoleUsBLL();
        HR_DBEntities hd = new HR_DBEntities();
        // GET: RoleUs
        public ActionResult Index()
        {
            return View();
        }
        //查询全部方法
        public ActionResult Index2()
        {
            //var dt= from e in hd.Users
            //        join c in hd.Role on e.rid equals c.rid
            //        select new {e.user_password,e.user_id,e.user_true_name,e.user_name, c.rname }; ;
            // return Json(dt,JsonRequestBehavior.AllowGet);
            int curr = Convert.ToInt32(Request.QueryString["currentPage"]);
            int size = Convert.ToInt32(Request.QueryString["pageSize"]);
            int pages = 0;
            int rows = 0;
            List<RoleUs> dt = rb.FenYe(e => e.user_id, e => e.user_id > 0, out rows,out pages, curr, size);
            Dictionary<string, object> dr = new Dictionary<string, object>();
            dr["dt"] = dt;
            dr["rows"] = rows;
            dr["pages"] = pages;
            return Content(JsonConvert.SerializeObject(dr));
        }
        // GET: RoleUs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleUs/Create
        public ActionResult Create()
        {
            ViewData["dt"] = GetList();
            return View();
        }

        //查询下拉列表
        public List<Role> GetList()
        {
            var dt= hd.Set<Role>().Select(e => e).ToList();
            return dt;
        }

        // POST: RoleUs/Create
        [HttpPost]
        public ActionResult Create(Users ru)
        {
            try
            {
                int tj=rb.Add(ru);
                if (tj>0)
                {
                    return Content("ok");
                }
                else
                {
                    return RedirectToAction("Index");
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleUs/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["dt"] = GetList();
            var dt = rb.SelectWhere<Users>(e=>e.user_id==id);
            Users u = new Users
            {
                user_name = dt[0].user_name,
                user_password = dt[0].user_password,
                user_true_name = dt[0].user_true_name,
                user_id = dt[0].user_id,
                rid = dt[0].rid
            };
            return View(u);
        }

        // POST: RoleUs/Edit/5
        [HttpPost]
        public ActionResult Edit(Users u)
        {
            try
            {
               int xg=rb.Update(u);
                if (xg>0)
                {
                    return Content("ok");
                }
                else
                {
                    return RedirectToAction("Index");
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleUs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleUs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
