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
    class salary_grant_detailsBLL : salary_grant_detailsIBLL
    {
        salary_grant_detailsIDAO sgdDAO = IocCreate.CreateProductTypeDao<salary_grant_detailsIDAO>("salary_grant_details", "salary_grant_detailsDAO");
        /// <summary>
        /// 登记薪酬发放详细信息
        /// </summary>
        /// <param name="sgd"></param>
        /// <returns></returns>
        public int DengJi(salary_grant_details sgd)
        {
            return sgdDAO.DengJi(sgd);
        }


        /// <summary>
        /// 根据薪酬发放编号获取薪酬发放详细信息数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<salary_grant_details> GetBysalary_grant_id(object id)
        {
            return sgdDAO.GetBysalary_grant_id(id);
        }

        /// <summary>
        /// 复核
        /// </summary>
        /// <param name="sgd"></param>
        /// <returns></returns>
        public int Update(salary_grant_details sgd)
        {
            return sgdDAO.Update(sgd);
        }
    }
}
