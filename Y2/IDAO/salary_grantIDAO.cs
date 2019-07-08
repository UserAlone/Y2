using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface salary_grantIDAO
    {
        //登记
        int DengJi(salary_grant sg);

        /// <summary>
        /// 获取还没有复核的薪酬发放登记表数据
        /// </summary>
        /// <returns></returns>
        List<salary_grant> GetByCheckStatus(Page<salary_grant> p);
      
        /// <summary>
        /// 根据发放ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        salary_grant GetBysalary_grant_id(object id);

        /// <summary>
        ///根据薪酬发放编号获取薪酬标准单编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<object> Getsalary_standard_idBysalary_grant_id(object id);

       
        /// <summary>
        /// 复核
        /// </summary>
        /// <param name="sg"></param>
        /// <returns></returns>
        int FuHe(salary_grant sg);

        /// <summary>
        /// 查询复核的数据
        /// </summary>
        /// <returns></returns>
        List<salary_grant> GetByWhere(Page<salary_grant> p);
    }
}
