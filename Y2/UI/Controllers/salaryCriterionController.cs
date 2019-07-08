using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using IBLL;
using BLL;
using locContaniner;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class salaryCriterionController : Controller
    {
        SalaryStandardIBLL ssBll = IocCreate.CreateProductTypeBLL<SalaryStandardIBLL>("SalaryStandard", "SalaryStandardBLL");
        SalaryStandardDetailsIBLL ssdBLL = IocCreate.CreateProductTypeBLL<SalaryStandardDetailsIBLL>("SalaryStandardDetails", "SalaryStandardDetailsBLL");
        // GET: salaryCriterion
        //薪酬标准登记页面
        public ActionResult SalaryStandardRegPage()
        {
            return View();
        }
        //增加薪酬标准登记
        public ActionResult AddSalaryStandard(string jdata, string list)
        {
            string flag = "false";
            List<salary_standard_details> ssList = JsonConvert.DeserializeObject<List<salary_standard_details>>(list);
            salary_standard ss = JsonConvert.DeserializeObject<salary_standard>(jdata);
            ss.check_status = 0;
            int res = ssBll.AddSalaryStandard(ss);
            if (res > 0)
            {
                flag = "true";
                for (int i = 0; i < ssList.Count; i++)
                {
                    if (ssList[i].salary.ToString().Equals("0.00"))
                    {                      
                        continue;
                    }
                    int num = ssdBLL.AddSalaryStandardDetails(ssList[i]);
                    if (num > 0)
                    {
                        flag = "true";
                    }
                    else
                    {
                        flag = "false";
                    }                 
                }
            }
            return Content(flag);
        }
        //增加薪酬标准登记成功页面
        public ActionResult salarystandard_register_success()
        {
            return View();
        }
        //生成薪酬标准单编号
        public ActionResult CreateStandardId()
        {
            string standardID = "15533" + DateTime.Now.Year.ToString() + DateTime.Now.GetHashCode().ToString().Substring(5, 4);
            bool flag = true;
            while (flag)
            {
                int res = (int)ssBll.IsContainer(standardID);
                if (res > 0)
                {
                    standardID = "15533" + DateTime.Now.Year.ToString() + DateTime.Now.GetHashCode().ToString().Substring(5, 4);
                }
                else
                {
                    flag = false;
                }
            }
            return Content(standardID);
        }     
        //获取薪酬标准基本信息
        public ActionResult GetSalaryStandard()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("CurrentPage", Request.QueryString["CurrentPage"]);
            dic.Add("PageSize", 3);
            Page<salary_standard> p = ssBll.FindByPage(dic);
            return Content(JsonConvert.SerializeObject(p));
        }     
        //薪酬标准登记复核查询页面
        public ActionResult salarystandard_check_list()
        {
            return View();
        }
        //查询没有复核的薪酬标准
        public ActionResult FindByCheckStatus()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("CurrentPage", Request.QueryString["CurrentPage"]);
            dic.Add("PageSize", 1);
            Page<salary_standard> p = ssBll.FindByCheckStatus(dic);
            return Content(JsonConvert.SerializeObject(p));
        }
        //薪酬标准登记复核页面
        public ActionResult salarystandard_check(object id)
        {
            salary_standard ss = ssBll.FindByssd_id(id);
            List<salary_standard_details> list = ssdBLL.FindByStandardID(ss.standard_id);
            ViewData["ss"] = ss;
            ViewData["list"] = list;
            return View();
        }
        //提交薪酬标准登记复核
        public ActionResult ReviewByssd_id(salary_standard ss)
        {
            int res = ssBll.ReviewByssd_id(ss);
            if (res>0)
            {
                return Content("<script>alert('复核成功');window.location.href='/salaryCriterion/salarystandard_check_success'</script>");
            }
            return Content("<script>alert('复核成功');window.location.href='/salaryCriterion/salarystandard_check'</script>");
        }
        //复核成功页面
        public ActionResult salarystandard_check_success()
        {
            return View();
        }
        //薪酬标准查询页面
        public ActionResult salarystandard_query_locate()
        {
            return View();
        }
        //薪酬标准登记查询页面
        public ActionResult salarystandard_query_list()
        {
            if (!TempData.ContainsKey("dic1"))
            {
                Dictionary<string, object> dic1 = new Dictionary<string, object>();
                dic1.Add("standardId", Request.Form["standard.standardId"]);
                dic1.Add("primarKey", Request.Form["utilbean.primarKey"]);
                dic1.Add("startDate", Request.Form["utilbean.startDate"]);
                dic1.Add("endDate", Request.Form["utilbean.endDate"]);
                TempData["dic1"] = dic1;
            }     
            return View();
        }     
        //带条件获取薪酬标准登记查询数据
        public ActionResult GetByWhere()
        {
            Dictionary<string, object> dic = TempData["dic1"] as Dictionary<string, object>;
            if (!dic.ContainsKey("CurrentPage"))
            {
                dic.Add("CurrentPage", Request.QueryString["CurrentPage"]);         
            }
            if (!dic.ContainsKey("PageSize"))
            {
                dic.Add("PageSize", Request.QueryString["PageSize"]);              
            }
            dic["CurrentPage"] = Request.QueryString["CurrentPage"];
            dic["PageSize"] = Request.QueryString["PageSize"];
            Page<salary_standard> p = ssBll.GetByWhere(dic);
            TempData.Keep("dic1");
            return Content(JsonConvert.SerializeObject(p));
        }      
        //薪酬标准变更添加查询条件页面
        public ActionResult salarystandard_change_locate()
        {        
            return View();
        }
        //显示薪酬标准登记变更页面
        public ActionResult salarystandard_change_list()
        {
            if (!TempData.ContainsKey("dic2"))
            {
                Dictionary<string, object> dic2 = new Dictionary<string, object>();
                dic2.Add("standardId", Request.Form["standard.standardId"]);
                dic2.Add("primarKey", Request.Form["utilbean.primarKey"]);
                dic2.Add("startDate", Request.Form["utilbean.startDate"]);
                dic2.Add("endDate", Request.Form["utilbean.endDate"]);
                TempData["dic2"] = dic2;
            }          
            return View();
        }
        //根据条件查询薪酬标准登记还没变更的数据
        public ActionResult FindByWhereAndChangeStaus()
        {
            Dictionary<string, object> dic = TempData["dic2"] as Dictionary<string, object>;
            if (!dic.ContainsKey("CurrentPage"))
            {
                dic.Add("CurrentPage", Request.QueryString["CurrentPage"]);
            }
            if (!dic.ContainsKey("PageSize"))
            {
                dic.Add("PageSize", Request.QueryString["PageSize"]);
            }
            dic["CurrentPage"] = Request.QueryString["CurrentPage"];
            dic["PageSize"] = Request.QueryString["PageSize"];
            Page<salary_standard> p = ssBll.FindByWhereAndChangeStaus(dic);          
            TempData.Keep("dic2");
            return Content(JsonConvert.SerializeObject(p));
        }
        //变更薪酬标准页面
        public ActionResult salarystandard_change(object id)
        {
            salary_standard ss = ssBll.FindByStandardId(id.ToString());
            List<salary_standard_details> list = ssdBLL.FindByStandardID(id.ToString());
            ViewData["ss"] = ss;
            ViewData["list"] = list;
            return View();
        }
        //根据薪酬标准单编号变更
        public ActionResult ChangeByStandardId(salary_standard ss)
        {
            int itemCount =int.Parse(Request.Form["itemCount"]);
            ss.change_status = 1;
            int res1 = ssBll.ChangeByStandardId(ss);
            if (res1>0)
            {           
                //循坏获取薪酬标准单详细信息
                for (int i = 0; i <itemCount; i++)
                {
                    salary_standard_details ssd = new salary_standard_details();                    
                    ssd.salary = Convert.ToDecimal(Request.Form["details[" + i + "].salary"]);
                    ssd.sdt_id = short.Parse(Request.Form["details[" + i + "].sdtId"]);
                    ssd.standard_id = ss.standard_id;
                    ssd.standard_name = ss.standard_name;
                    ssd.item_name = Request.Form["details[" + i + "].itemName"];
                    int num = ssdBLL.ChangeByStandardID(ssd);
                }
            }
            return Content("<script>alert('变更成功!!!');window.location.href='/salaryCriterion/salarystandard_change_success'</script>");
        }
        //变更成功页面
        public ActionResult salarystandard_change_success()
        {
            return View();
        }
        //薪酬标准登记查询详细页面
        public ActionResult salarystandard_query(object id)
        {
            salary_standard ss= ssBll.FindByStandardId(id.ToString());
            List<salary_standard_details> list = ssdBLL.FindByStandardID(id.ToString());
             ViewData["ss"] = ss;
            ViewData["list"] = list;
            return View();
        }

      
    }
}