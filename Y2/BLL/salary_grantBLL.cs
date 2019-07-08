using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using IBLL;
using locContaniner;

namespace BLL
{
    public class salary_grantBLL : salary_grantIBLL
    {
        salary_grantIDAO sgDAO = IocCreate.CreateProductTypeDao<salary_grantIDAO>("salary_grant", "salary_grantDAO");
        //登记
        public int DengJi(salary_grant sg)
        {
            return sgDAO.DengJi(sg);
        }

        /// <summary>
        /// 复核
        /// </summary>
        /// <param name="sg"></param>
        /// <returns></returns>
        public int FuHe(salary_grant sg)
        {
            return sgDAO.FuHe(sg);
        }


        /// <summary>
        /// 获取还没有复核的薪酬发放登记表数据
        /// </summary>
        /// <returns></returns>
        public Page<salary_grant> GetByCheckStatus(Dictionary<string,object> dic)
        {
            Page<salary_grant> p = new Page<salary_grant>();
            p.CurrentPage = Convert.ToInt32(dic["currentPage"]);
            p.PageSize = Convert.ToInt32(dic["pageSize"]);
            p.TableName = "salary_grant";
            p.KeyName = "sgr_id";
            p.Where = "where check_status is null and sgr_id in (select min(sgr_id) from salary_grant group by salary_grant_id)";
            p.Data = sgDAO.GetByCheckStatus(p);
            return p;
        }


        /// <summary>
        /// 根据发放ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public salary_grant GetBysalary_grant_id(object id)
        {
            return sgDAO.GetBysalary_grant_id(id);
        }

        /// <summary>
        /// 查询复核的数据
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Page<salary_grant> GetByWhere(Dictionary<string,object> dic)
        {
            string salaryGrantId = dic["salaryGrant.salaryGrantId"].ToString();
            string primarKey = dic["utilbean.primarKey"].ToString();
            string startDate = dic["utilbean.startDate"].ToString();
            string endDate = dic["utilbean.endDate"].ToString();          
            Page<salary_grant> p = new Page<salary_grant>();
            p.CurrentPage = Convert.ToInt32(dic["currentPage"]);
            p.PageSize = Convert.ToInt32(dic["pageSize"]);
            p.TableName = "salary_grant";
            p.KeyName = "sgr_id";
            p.Where = "where 1=1 and check_status=1 and sgr_id in (select min(sgr_id) from salary_grant group by salary_grant_id)";
            if (salaryGrantId != "")
            {
                p.Where += string.Format(" and salary_grant_id='{0}'", salaryGrantId);
            }
            if (startDate!=""&& endDate!="")
            {
                p.Where += string.Format(" and regist_time between '{0}' and '{1}'", startDate, endDate);
            }
            p.Data = sgDAO.GetByCheckStatus(p);
            return p;
        }


        /// <summary>
        ///根据薪酬发放编号获取薪酬标准单编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<object> Getsalary_standard_idBysalary_grant_id(object id)
        {
            return sgDAO.Getsalary_standard_idBysalary_grant_id(id);
        }
    }
}
