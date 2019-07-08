using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using locContaniner;
using BAL;
using Model;

namespace BLL
{
    public class SalaryStandardBLL : SalaryStandardIBLL
    {
        SalaryStandardIDAO ssdao = IocCreate.CreateProductTypeDao<SalaryStandardIDAO>("SalaryStandard", "SalaryStandardDAO");

        public int AddSalaryStandard(salary_standard ss)
        {
            return ssdao.AddSalaryStandard(ss);
        }
        //查询没有复核的薪酬标准
        public Page<salary_standard> FindByCheckStatus(Dictionary<string, object> dic)
        {        
            Page<salary_standard> p = new Page<salary_standard>();
            p.CurrentPage = Convert.ToInt32(dic["CurrentPage"]);
            p.PageSize = Convert.ToInt32(dic["PageSize"]);
            p.Where = "where 1=1 and check_status!=1 and not change_status is null";
            p.KeyName = "ssd_id";
            p.TableName = "salary_standard";          
            p.Data = ssdao.FindByCheckStatus(p);
            return p;
        }

        public Page<salary_standard> FindByPage(Dictionary<string, object> dic)
        {
            Page<salary_standard> p = new Page<salary_standard>();
            p.CurrentPage = Convert.ToInt32(dic["CurrentPage"]);
            p.PageSize = Convert.ToInt32(dic["PageSize"]);
            p.Where = "where 1=1 and check_status=0";
            p.KeyName = "ssd_id";
            p.TableName = "salary_standard";
            p.Data = ssdao.FindByPage(p);
            return p;
        }

        public salary_standard FindByssd_id(object ssd_id)
        {
            return ssdao.FindByssd_id(ssd_id);
        }

        public salary_standard FindByStandardId(string standardId)
        {
            return ssdao.FindByStandardId(standardId);
        }

        //带条件获取薪酬标准登记查询数据
        public Page<salary_standard> GetByWhere(Dictionary<string, object> dic)
        {
          
            Page<salary_standard> p = new Page<salary_standard>();
            p.CurrentPage = Convert.ToInt32(dic["CurrentPage"]);
            p.PageSize = Convert.ToInt32(dic["PageSize"]);
            p.KeyName = "ssd_id";
            p.TableName = "salary_standard";
            p.Where = "where 1=1"+ CreateWhere(dic);             
            p.Data = ssdao.GetByWhere(p);
            return p;
        }

        private string CreateWhere(Dictionary<string ,object> dic)
        {
            string standardId = dic["standardId"].ToString();
            string primarKey = dic["primarKey"].ToString();
            string startDate = dic["startDate"].ToString();
            string endDate = dic["endDate"].ToString();
            string where = "";
            if (standardId != "" && standardId != null)
            {
                where += string.Format(" and standard_id like '%{0}%'", standardId);
            }
            if (primarKey != "" && primarKey != null)
            {
                where += string.Format(" and standard_name like '%{0}%'", primarKey);
            }
            if ((startDate != "" && startDate != null) && (endDate != null && endDate != ""))
            {
                where += string.Format(" and regist_time between '{0}' and '{1}'", startDate, endDate);
            }
            return where;
        }

        public object IsContainer(string danhao)
        {
            return ssdao.IsContainer(danhao);
        }

        public int UpdateByssd_id(salary_standard ss)
        {
            return ssdao.ReviewByssd_id(ss);
        }

        //根据条件查询薪酬标准登记还没变更的数据
        public Page<salary_standard> FindByWhereAndChangeStaus(Dictionary<string, object> dic)
        {         
            Page<salary_standard> p = new Page<salary_standard>();
            p.CurrentPage = Convert.ToInt32(dic["CurrentPage"]);
            p.PageSize = Convert.ToInt32(dic["PageSize"]);
            p.KeyName = "ssd_id";
            p.TableName = "salary_standard";
            p.Where = "where 1=1 and change_status is null" + CreateWhere(dic);
            p.Data = ssdao.FindByWhereAndChangeStaus(p);
            return p;
        }

        //根据薪酬标准单编号变更
        public int ChangeByStandardId(salary_standard ss)
        {
            return ssdao.ChangeByStandardId(ss);
        }

        public int ReviewByssd_id(salary_standard ss)
        {
            return ssdao.ReviewByssd_id(ss);
        }
    }
}
