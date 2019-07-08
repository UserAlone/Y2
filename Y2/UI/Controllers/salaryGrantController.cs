using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using locContaniner;
using BLL;
using IBLL;
using Model;
using BAL;
using System.Reflection;

namespace UI.Controllers
{
    public class salaryGrantController : Controller
    {
        config_file_first_kindIBLL cffkBLL = IocCreate.CreateProductTypeBLL<config_file_first_kindIBLL>("config_file_first_kind", "config_file_first_kindBLL");
        human_fileIBLL hfBLL = IocCreate.CreateProductTypeBLL<human_fileIBLL>("human_file", "human_fileBLL");
        config_file_second_kindIBLL cfskBLL = IocCreate.CreateProductTypeBLL<config_file_second_kindIBLL>("config_file_second_kind", "config_file_second_kindBLL");
        config_file_third_kindIBLL cftkBLL = IocCreate.CreateProductTypeBLL<config_file_third_kindIBLL>("config_file_third_kind", "config_file_third_kindBLL");
        SalaryStandardDetailsIBLL ssdBLL = IocCreate.CreateProductTypeBLL<SalaryStandardDetailsIBLL>("SalaryStandardDetails", "SalaryStandardDetailsBLL");
        salary_grantIBLL sgBLL = IocCreate.CreateProductTypeBLL<salary_grantIBLL>("salary_grant", "salary_grantBLL");
        salary_grant_detailsIBLL sgdBLL = IocCreate.CreateProductTypeBLL<salary_grant_detailsIBLL>("salary_grant_details", "salary_grant_detailsBLL");
        //薪酬发放登记页面带条件
        public ActionResult register_locate()
        {
            return View();
        }

        //薪酬发放登记(负责人控制)页面
        public ActionResult register_list()
        {
            string submitType = Request.Form["submitType"]; //获取要查询的机构等级
            if ("1".Equals(submitType))  //获取一级机构的数据
            {
                List<Dictionary<string, object>> list = cffkBLL.GetByFirst();
                ViewData["list"] = list;
            }
            else if ("2".Equals(submitType)) //获取二级机构的数据
            {
                List<Dictionary<string, object>> list = cfskBLL.GetByTwo();
                ViewData["list"] = list;
            }
            else if ("3".Equals(submitType)) //获取三级机构的数据
            {
                List<Dictionary<string, object>> list = cftkBLL.GetByThird();
                ViewData["list"] = list;
            }
            return View();
        }

        //薪酬发放登记提交页面
        public ActionResult register_commit()
        {
            string config_id = Request.QueryString["id"];
            string level = Request.QueryString["level"];
            List<human_file> list = new List<human_file>();
            if ("I结构".Equals(level))
            {
                list = hfBLL.GetFirstConfigByID(config_id);
                //list = Getsalary_standard_details(hfBLL.GetFirstConfigByID(config_id));
            }
            else if ("II结构".Equals(level))
            {
                list = hfBLL.GetTwoConfigByID(config_id);
                //list = Getsalary_standard_details(hfBLL.GetTwoConfigByID(config_id));
            }
            else if ("III结构".Equals(level))
            {
                list = hfBLL.GetThridConfigByID(config_id);
                //list = Getsalary_standard_details(hfBLL.GetThridConfigByID(config_id));
            }
            //其余信息封装
            //salary_grant sg = new salary_grant();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("level", level);
            dic.Add("config_id", config_id);
            dic.Add("config_name", Request.QueryString["configName"]);
            dic.Add("salary_grant_id", Createsalary_grant_id());          
            ViewData["dic"] = dic;
            ViewData["list"] = list;
            return View();
        }        //创建薪酬发放编号
        public string Createsalary_grant_id()
        {
            string bianhao = "HS";
            Random r = new Random();
            string str = "0123456789";
            for (int i = 1; i <= 13; i++)
            {
                int num = r.Next(0, str.Length - 1);
                bianhao += num;
            }
            return bianhao;
        }     
        //薪酬发放登记提交操作
        public ActionResult DengJi(salary_grant sg)
        {
            string level = Request.Form["level"];
            string id = Request.Form["configID"];
            string configName = Request.Form["configName"];
            if ("I结构".Equals(level))
            {
                sg.first_kind_id = id;
                sg.first_kind_name = configName;
            }
            else if ("II结构".Equals(level))
            {
                sg.second_kind_id = id;
                sg.second_kind_name = configName;
            }
            else if ("III结构".Equals(level))
            {
                sg.third_kind_id = id;
                sg.third_kind_name = configName;
            }
            for (int i = 0; i < sg.human_amount; i++)
            {              
                sg.salary_standard_id = Request.Form["salary_standard_id[" + i + "]"];
                int num1 = sgBLL.DengJi(sg);
                salary_grant_details sgd = new salary_grant_details();
                sgd.salary_grant_id = sg.salary_grant_id;
                sgd.human_id = Request.Form["grantDetails["+i+"].humanId"];
                sgd.human_name = Request.Form["grantDetails["+i+"].humanName"];
                sgd.bouns_sum = Convert.ToDecimal(Request.Form["grantDetails["+i+"].bounsSum"]);
                sgd.sale_sum = Convert.ToDecimal(Request.Form["grantDetails[" + i + "].saleSum"]);
                sgd.deduct_sum = Convert.ToDecimal(Request.Form["grantDetails[" + i + "].deductSum"]);
                sgd.salary_paid_sum = Convert.ToDecimal(Request.Form["grantDetails[" + i + "].salaryPaidSum"]);
                sgd.salary_standard_sum = sg.salary_standard_sum;
                int num2 = sgdBLL.DengJi(sgd);
            }

            return RedirectToAction("register_success", "salaryGrant");
        }
        //薪酬发放登记提交成功页面
        public ActionResult register_success()
        {
            return View();
        }

        //薪酬发放登记审核页面
        public ActionResult check_list()
        {
            return View();
        }

        //获取还没有复核的薪酬发放登记表数据
        public ActionResult GetByCheckStatus()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("currentPage", Request.QueryString["currentPage"]);
            dic.Add("pageSize", Request.QueryString["pageSize"]);
            Page<salary_grant> p = sgBLL.GetByCheckStatus(dic);            
            return Json(p, JsonRequestBehavior.AllowGet);
        }

        //复核提交页面
        public ActionResult check(string id)
        {
            salary_grant sg = sgBLL.GetBysalary_grant_id(id);
            List<salary_grant_details> list = sgdBLL.GetBysalary_grant_id(id);
            List<object> salary_grant_ids = sgBLL.Getsalary_standard_idBysalary_grant_id(id);
            ViewData["sg"] = sg;
            ViewData["list"] = list;
            ViewData["salary_grant_ids"] = salary_grant_ids;
            return View();
        }

        //复核操作
        public ActionResult FuHe(salary_grant sg)
        {          
            int res1 = sgBLL.FuHe(sg);
            //循环获取提交传过来的薪酬发放详细信息然后进行复核
            for (int i = 0; i < sg.human_amount; i++)
            {
                salary_grant_details sgd = new salary_grant_details();
                sgd.bouns_sum = Convert.ToDecimal(Request.Form["grantDetails["+i+"].bounsSum"]);
                sgd.sale_sum = Convert.ToDecimal(Request.Form["grantDetails["+i+"].saleSum"]);
                sgd.deduct_sum = Convert.ToDecimal(Request.Form["grantDetails["+i+"].deductSum"]);
                sgd.salary_paid_sum = Convert.ToDecimal(Request.Form["grantDetails[" + i + "].salaryPaidSum"]);
                sgd.salary_grant_id = sg.salary_grant_id;
                int res2 = sgdBLL.Update(sgd);
            }            
            return Content("<script>alert('复核成功');window.location.href='/salaryGrant/query_locate'</script>");
        }

        //薪酬发放查询条件页面
        public ActionResult query_locate()
        {
            return View();
        }

        //薪酬发放查询
        public ActionResult query_list()
        {
            //保存查询条件
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("salaryGrant.salaryGrantId", Request.Form["salaryGrant.salaryGrantId"]);
            dic.Add("utilbean.primarKey", Request.Form["utilbean.primarKey"]);
            dic.Add("utilbean.startDate", Request.Form["utilbean.startDate"]);
            dic.Add("utilbean.endDate", Request.Form["utilbean.endDate"]);
            TempData["where"] = dic;
            return View();
        }

        //查询复核的数据
        public ActionResult GetByWhere()
        {
            Dictionary<string, object> dic = (Dictionary<string, object>)TempData["where"];
            if (!dic.ContainsKey("currentPage"))
            {
                dic.Add("currentPage", Request.QueryString["currentPage"]);
            }
            if (!dic.ContainsKey("pageSize"))
            {
                dic.Add("pageSize", Request.QueryString["pageSize"]);
            }
            dic["currentPage"] = Request.QueryString["currentPage"];
            dic["pageSize"] = Request.QueryString["pageSize"];
            TempData.Keep("where");
            Page<salary_grant> p = sgBLL.GetByWhere(dic);
            return Json(p, JsonRequestBehavior.AllowGet);
        }

        //查看数据
        public ActionResult query(string id)
        {
            ViewData["sg"] = sgBLL.GetBysalary_grant_id(id);
            ViewData["list"] = sgdBLL.GetBysalary_grant_id(id);
            ViewData["list2"] = sgBLL.Getsalary_standard_idBysalary_grant_id(id);
            return View();
        }

        public ActionResult Getsalary_grant_details(string id)
        {
            List<salary_standard_details> list = ssdBLL.FindByStandardID(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }

}