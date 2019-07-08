using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using System.Data.SqlClient;
using Model;

namespace BAL
{
    public class config_file_third_kindDAO : config_file_third_kindIDAO
    {
        public int Add(config_file_third_kind cfftk)
        {
            string sql = string.Format("insert into dbo.config_file_third_kind(first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, third_kind_sale_id, third_kind_is_retail)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",cfftk.first_kind_id,cfftk.first_kind_name,cfftk.second_kind_id,cfftk.second_kind_name,cfftk.third_kind_id,cfftk.third_kind_name,cfftk.third_kind_sale_id,cfftk.third_kind_is_retail);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        public int Del(object id)
        {
            string sql = string.Format("delete from dbo.config_file_third_kind where ftk_id={0}",id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        public List<config_file_third_kind> GetAll()
        {
            string sql = "select * from dbo.config_file_third_kind";
            List<config_file_third_kind> list = new List<config_file_third_kind>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    config_file_third_kind cftk = new config_file_third_kind();
                    cftk.ftk_id = (int)reader["ftk_id"];
                    cftk.first_kind_id = reader["first_kind_id"].ToString();
                    cftk.first_kind_name = reader["first_kind_name"].ToString();
                    cftk.second_kind_id = reader["second_kind_id"].ToString();
                    cftk.second_kind_name = reader["second_kind_name"].ToString();
                    cftk.third_kind_id = reader["third_kind_id"].ToString();
                    cftk.third_kind_name = reader["third_kind_name"].ToString();
                    cftk.third_kind_sale_id = reader["third_kind_sale_id"].ToString();
                    cftk.third_kind_is_retail = reader["third_kind_is_retail"].ToString();
                    list.Add(cftk);
                }
            }
            return list;
        }

        //获取三级机构的基本总金额和人数
        public List<Dictionary<string, object>> GetByThird()
        {
            string sql = "select *,(select COUNT(*) from human_file where cftk.third_kind_id = third_kind_id) as 'count',(select SUM(salary_sum) from human_file where cftk.third_kind_id = third_kind_id) as 'sum',(select SUM(paid_salary_sum) from human_file where cftk.third_kind_id = third_kind_id) as '实发总金额' from dbo.config_file_third_kind cftk";
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("id", reader["ftk_id"]);
                    dic.Add("config_id", reader["third_kind_id"]);
                    dic.Add("config_name", reader["third_kind_name"]);
                    dic.Add("count", reader["count"]);
                    dic.Add("sum", reader["sum"]==DBNull.Value?0:reader["sum"]);
                    dic.Add("level", "III结构");
                    dic.Add("paid_salary_sum", reader["paid_salary_sum"]);
                    dic.Add("实发总金额", reader["实发总金额"]==DBNull.Value?0:reader["实发总金额"]);
                    list.Add(dic);
                }
            }
            return list;
        }

        public config_file_third_kind GetBythird_kind_id(object id)
        {
            string sql = string.Format("select * from dbo.config_file_third_kind where ftk_id={0}",id);
            config_file_third_kind cftk = new config_file_third_kind();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                if (reader.Read())
                {
                    cftk.ftk_id = (int)reader["ftk_id"];
                    cftk.first_kind_id = reader["first_kind_id"].ToString();
                    cftk.first_kind_name = reader["first_kind_name"].ToString();
                    cftk.second_kind_id = reader["second_kind_id"].ToString();
                    cftk.second_kind_name = reader["second_kind_name"].ToString();
                    cftk.third_kind_id = reader["third_kind_id"].ToString();
                    cftk.third_kind_name = reader["third_kind_name"].ToString();
                    cftk.third_kind_sale_id = reader["third_kind_sale_id"].ToString();
                    cftk.third_kind_is_retail = reader["third_kind_is_retail"].ToString();
                }
            }
            return cftk;
        }

        public object GetMaxthird_kind_id()
        {
            string sql = "select MAX(third_kind_id) from dbo.config_file_third_kind";
            return SqlHelper.MyScalar(sql, null);
        }

        public int Update(config_file_third_kind cftk)
        {
            string sql = string.Format("update dbo.config_file_third_kind set third_kind_sale_id='{0}',third_kind_is_retail='{1}' where ftk_id={2}",cftk.third_kind_sale_id,cftk.third_kind_is_retail,cftk.ftk_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }
    }
}
