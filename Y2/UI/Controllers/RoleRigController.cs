using BAL;
using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using BAL;

namespace UI.Controllers
{
    public class RoleRigController : Controller
    {
        HR_DBEntities hd = new HR_DBEntities();
        RoleRigBLL rb = new RoleRigBLL();
        // GET: RoleRig
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            //var dt = rb.Show<Role>();
            //List<Role> list = new List<Role>();
            //foreach (var item in dt)
            //{
            //    Role rl = new Role();
            //    rl.rid = item.rid;
            //    rl.rname = item.rname;
            //    rl.rys = item.rys;
            //    list.Add(rl);
            //}
            //return Content(JsonConvert.SerializeObject(list));

            int curr = Convert.ToInt32(Request.QueryString["currentPage"]);
            int size = Convert.ToInt32(Request.QueryString["pageSize"]);
            int rows = 0;
            int pages = 0;
            var dt = rb.FenYe(e => e.rid, e => e.rid > 0, out rows,out pages, curr, size);
            List<Role> list = new List<Role>();
            foreach (var item in dt)
            {
                Role rl = new Role();
                rl.rid = item.rid;
                rl.rname = item.rname;
                rl.rys = item.rys;
                list.Add(rl);
            }
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }

        // GET: RoleRig/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleRig/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleRig/Create
        [HttpPost]
        public ActionResult Create(Role rl)
        {
            try
            {
               int tj=rb.Add(rl);
                if (tj>0)
                {
                    return Content("ok");
                }
                else
                {
                    return RedirectToAction("Index2");
                }
            }
            catch
            {
                return View();
            }
        }


        //public List<Role> GetList()
        //{
        //    var dt = hd.Set<Role>().Select(e => e).ToList();
        //    return dt;
        //}

        // GET: RoleRig/Edit/5
        int id2 = 0;
        public ActionResult Edit(int id)
        {
            id2 = id;
            var dt = rb.SelectWhere(e=>e.rid== id2);
            Role r = new Role
            {
                rid = dt[0].rid,
                rname=dt[0].rname,
                rys=dt[0].rys
            };
            return View(r); ;
        }
        //先删除后做添加
        public ActionResult Edit2()
        {
            int id = Convert.ToInt32(Request["c"]);
            string[] sid = Request["id"].ToString().Split(',');
            string sql2 = string.Format("delete from dbo.RoleQuan where rid='{0}' ", id);
            int sc = DBhelper.InsertUpdateDelte(sql2,"");
            for (int i = 0; i < sid.Length; i++)
            {
                String cid = sid[i];
                string sql = string.Format("insert into dbo.RoleQuan (rid,qid)values('{0}','{1}') ", id, cid);
                int tj = DBhelper.InsertUpdateDelte(sql, "");

            }
            return Content("ok");
        }
        //查询出所有复选框
        public ActionResult Index3(int id2)
        {
            string sql = "";
            if (Request["id"] == null)
            {
                //根节点
                sql = string.Format(@"select [id],[text],[state],case
	when qr.qid is null then 0
	else 1
 end as checked
from [dbo].[Quan] q
left join(
select qid
from dbo.RoleQuan
where rid={0}
) qr on q.id=qr.qid
where fid=0
", Session["uid"]);
            }
            else
            {
                sql = string.Format(@"select [id],[text],[state],case
	when qr.qid is null then 0
	else 1
 end as checked
from [dbo].[Quan] q
left join(
select qid
from dbo.RoleQuan
where rid={0}
) qr on q.id=qr.qid
where fid={1}", id2, Request["id"]);
            }
            var dt = DBhelper.Select(sql,"");
            return Content(JsonConvert.SerializeObject(dt));
        }

        // POST: RoleRig/Edit/5

            //修改
        [HttpPost]
        public ActionResult Edit(Role r)
        {
            try
            {
              int xg=  rb.Update(r);
                if (xg > 0)
                {
                    return Content("ok");
                }
                else
                {
                    return RedirectToAction("Index2");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleRig/Delete/5
        //删除
        public ActionResult Delete(int id)
        {
            Role r = new Role()
            {
                rid = id
            };
           int sc= rb.Delete(r);
            if (sc>0)
            {
                return Content("<script>alert('删除成功');window.location.href='/RoleRig/Index'</script>");
            }
            else
            {
                return View();
            }
        }

        // POST: RoleRig/Delete/5
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
