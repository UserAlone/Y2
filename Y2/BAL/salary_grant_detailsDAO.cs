using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using System.Data.SqlClient;

namespace BAL
{
    class salary_grant_detailsDAO : salary_grant_detailsIDAO
    {
        /// <summary>
        /// 登记薪酬发放详细信息
        /// </summary>
        /// <param name="sgd"></param>
        /// <returns></returns>
        public int DengJi(salary_grant_details sgd)
        {
            //insert into salary_grant_details(salary_grant_id, human_id, human_name, bouns_sum, sale_sum, deduct_sum, salary_standard_sum, salary_paid_sum)values('HS4178128634822','bt201211190644250035','杨幂',100,200,100,2000.0000,250)
            //string sql = string.Format("insert into salary_standard_details(salary_grant_id, human_id, human_name, bouns_sum, sale_sum, deduct_sum, salary_standard_sum, salary_paid_sum)values('{0}','{1}','{2}',{3},{4},{5},{6},{7})", sgd.salary_grant_id,sgd.human_id,sgd.human_name,sgd.bouns_sum,sgd.sale_sum,sgd.deduct_sum,sgd.salary_standard_sum,sgd.salary_paid_sum);
            string sql = string.Format("insert into salary_grant_details(salary_grant_id, human_id, human_name, bouns_sum, sale_sum, deduct_sum, salary_standard_sum, salary_paid_sum)values('{0}','{1}','{2}',{3},{4},{5},{6},{7})",sgd.salary_grant_id,sgd.human_id,sgd.human_name,sgd.bouns_sum,sgd.sale_sum,sgd.deduct_sum,sgd.salary_standard_sum,sgd.salary_paid_sum);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        public List<salary_grant_details> GetBysalary_grant_id(object id)
        {
            string sql = string.Format("select * from dbo.salary_grant_details where salary_grant_id='{0}'", id);
            List<salary_grant_details> list = new List<salary_grant_details>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    //grd_id, salary_grant_id, human_id, human_name, bouns_sum, sale_sum, deduct_sum, salary_standard_sum, salary_paid_sum
                    salary_grant_details sgd = new salary_grant_details();
                    sgd.grd_id = (short)reader["grd_id"];
                    sgd.salary_grant_id = reader["salary_grant_id"].ToString();
                    sgd.human_id = reader["human_id"].ToString();
                    sgd.human_name = reader["human_name"].ToString();
                    sgd.bouns_sum = Convert.ToDecimal(reader["bouns_sum"]);
                    sgd.sale_sum = Convert.ToDecimal(reader["sale_sum"]);
                    sgd.deduct_sum = Convert.ToDecimal(reader["deduct_sum"]);
                    sgd.salary_standard_sum = Convert.ToDecimal(reader["salary_standard_sum"]);
                    sgd.salary_paid_sum = Convert.ToDecimal(reader["salary_paid_sum"]);
                    list.Add(sgd);
                }
            }
            return list;
        }

        /// <summary>
        /// 复核
        /// </summary>
        /// <param name="sgd"></param>
        /// <returns></returns>
        public int Update(salary_grant_details sgd)
        {
            string sql = string.Format("update dbo.salary_grant_details set bouns_sum={0},sale_sum={1},deduct_sum={2},salary_paid_sum={3} where salary_grant_id='{4}'", sgd.bouns_sum, sgd.sale_sum, sgd.deduct_sum, sgd.salary_paid_sum, sgd.salary_grant_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }
    }
}
