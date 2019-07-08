using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;
using System.Data.SqlClient;

namespace BAL
{
    public class SalaryStandardDetailsDAO : BaseDao, SalaryStandardDetailsIDAO
    {
        public int AddSalaryStandardDetails(salary_standard_details ssd)
        {
            string sql = string.Format("insert into dbo.salary_standard_details(standard_id, standard_name, item_id, item_name, salary)values('{0}','{1}',{2},'{3}',{4});",ssd.standard_id,ssd.standard_name,ssd.item_id,ssd.item_name,ssd.salary);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        //变更薪酬标准单详细信息
        public int ChangeByStandardID(salary_standard_details ssd)
        {
            string sql = string.Format("update dbo.salary_standard_details set standard_name='{0}',salary={1} where standard_id='{2}' and item_name='{3}'",ssd.standard_name,ssd.salary,ssd.standard_id,ssd.item_name);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        public List<salary_standard_details> FindAll()
        {
            string sql = "select* from salary_standard_details";
            List<salary_standard_details> list = new List<salary_standard_details>();
            using (SqlDataReader reader = SqlHelper.MyReader(sql, null))
            {
                while (reader.Read())
                {
                    //sdt_id, standard_id, standard_name, item_id, item_name, salary
                    salary_standard_details ssd = new salary_standard_details();
                    ssd.sdt_id = (short)reader["sdt_id"];
                    ssd.standard_id = reader["standard_id"].ToString();
                    ssd.standard_name = reader["standard_name"].ToString();
                    ssd.item_id = (short)reader["item_id"];
                    ssd.item_name = reader["item_name"].ToString();
                    ssd.salary = (decimal)reader["salary"];
                    list.Add(ssd);
                }
            }
            return list;
        }

        public List<salary_standard_details> FindByStandardID(string standardID)
        {
            List<salary_standard_details> list = new List<salary_standard_details>();
            string sql = string.Format("select * from dbo.salary_standard_details where standard_id='{0}'",standardID);
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    //sdt_id, standard_id, standard_name, item_id, item_name, salary
                    salary_standard_details ssd = new salary_standard_details();
                    ssd.sdt_id = (short)reader["sdt_id"];
                    ssd.standard_id = reader["standard_id"].ToString();
                    ssd.standard_name = reader["standard_name"].ToString();
                    ssd.item_id = (short)reader["item_id"];
                    ssd.item_name = reader["item_name"].ToString();
                    ssd.salary = (decimal)reader["salary"];
                    list.Add(ssd);
                }
            }
            return list;
        }

        //根据ssd_id复核薪酬标准单详细信息
        public int ReviewBystandard_id(salary_standard_details ssd)
        {
            string sql = string.Format("update dbo.salary_standard_details set standard_id='{0}',standard_name='{1}',salary={2} where sdt_id={3}", ssd.standard_id,ssd.standard_name,ssd.salary,ssd.sdt_id);
            return SqlHelper.MyExecuteNonQuery(sql,null);
        }
    }
}
