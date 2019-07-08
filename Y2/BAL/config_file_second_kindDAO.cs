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
    public class config_file_second_kindDAO : config_file_second_kindIDAO
    {
        public int Add(config_file_second_kind cfsk)
        {
            string sql = string.Format("insert into dbo.config_file_second_kind(first_kind_id, first_kind_name, second_kind_id, second_kind_name, second_salary_id, second_sale_id)values('{0}','{1}','{2}','{3}','{4}','{5}')",cfsk.first_kind_id,cfsk.first_kind_name,cfsk.second_kind_id,cfsk.second_kind_name,cfsk.second_salary_id,cfsk.second_sale_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        public int DelByfsk_id(object id)
        {
            string sql = string.Format("delete from dbo.config_file_second_kind where fsk_id={0}",id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        public List<config_file_second_kind> GetAll()
        {
            string sql = "select * from dbo.config_file_second_kind";
            List<config_file_second_kind> list = new List<config_file_second_kind>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    config_file_second_kind cfsk = new config_file_second_kind();
                    cfsk.fsk_id = (int)reader["fsk_id"];
                    cfsk.first_kind_id = reader["first_kind_id"].ToString();
                    cfsk.first_kind_name = reader["first_kind_name"].ToString();
                    cfsk.second_kind_id = reader["second_kind_id"].ToString();
                    cfsk.second_kind_name = reader["second_kind_name"].ToString();
                    cfsk.second_salary_id = reader["second_salary_id"].ToString();
                    cfsk.second_sale_id = reader["second_sale_id"].ToString();
                    list.Add(cfsk);
                }
            }
            return list;
        }

        public config_file_second_kind GetByfsk_id(object id)
        {
            string sql = string.Format("select * from dbo.config_file_second_kind where fsk_id={0}",id);
            config_file_second_kind cfsk = new config_file_second_kind();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                if (reader.Read())
                {
                    cfsk.fsk_id = (int)reader["fsk_id"];
                    cfsk.first_kind_id = reader["first_kind_id"].ToString();
                    cfsk.first_kind_name = reader["first_kind_name"].ToString();
                    cfsk.second_kind_id = reader["second_kind_id"].ToString();
                    cfsk.second_kind_name = reader["second_kind_name"].ToString();
                    cfsk.second_salary_id = reader["second_salary_id"].ToString();
                    cfsk.second_sale_id = reader["second_sale_id"].ToString();
                }
            }
            return cfsk;
        }

        //获取二级机构的基本总金额和人数
        public List<Dictionary<string, object>> GetByTwo()
        {
            string sql = "select *,(select COUNT(*) from human_file where cfsk.second_kind_id=second_kind_id) as 'count',(select SUM(salary_sum) from human_file where cfsk.second_kind_id=second_kind_id) as 'sum',(select SUM(paid_salary_sum) from human_file where cfsk.second_kind_id=second_kind_id) as '实发总金额' from dbo.config_file_second_kind cfsk";
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("id", reader["fsk_id"]);
                    dic.Add("config_id", reader["second_kind_id"]);
                    dic.Add("config_name", reader["second_kind_name"]);
                    dic.Add("count", reader["count"]);
                    dic.Add("sum", reader["sum"] == DBNull.Value ? 0 : reader["sum"]);
                    dic.Add("level", "II结构");
                    dic.Add("实发总金额", reader["实发总金额"] == DBNull.Value ? 0 : reader["实发总金额"]);
                    list.Add(dic);
                }
            }
            return list;
        }

        public object GetMaxsecond_kind_id()
        {
            string sql = "select MAX(second_kind_id) from dbo.config_file_second_kind";
            return SqlHelper.MyScalar(sql, null);
        }

        public int Update(config_file_second_kind cfsk)
        {
            string sql = string.Format("update dbo.config_file_second_kind set second_salary_id='{0}',second_sale_id='{1}' where fsk_id={2}",cfsk.second_salary_id,cfsk.second_sale_id,cfsk.fsk_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }
    }
}
