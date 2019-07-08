using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface salary_grant_detailsIBLL
    {
        /// <summary>
        /// 登记薪酬发放详细信息
        /// </summary>
        /// <param name="sgd"></param>
        /// <returns></returns>
        int DengJi(salary_grant_details sgd);

        /// <summary>
        /// 根据薪酬发放编号获取薪酬发放详细信息数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<salary_grant_details> GetBysalary_grant_id(object id);


        /// <summary>
        /// 复核
        /// </summary>
        /// <param name="sgd"></param>
        /// <returns></returns>
        int Update(salary_grant_details sgd);
    }
}
