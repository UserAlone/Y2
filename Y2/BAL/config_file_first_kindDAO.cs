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
    class config_file_first_kindDAO : config_file_first_kindIDAO
    {
        /// <summary>
        /// 增加一级结构数据
        /// </summary>
        /// <param name="cffk"></param>
        /// <returns></returns>
        public int Add(config_file_first_kind cffk)
        {
            string sql = string.Format("insert into dbo.config_file_first_kind(first_kind_id, first_kind_name, first_kind_salary_id, first_kind_sale_id)values('{0}','{1}','{2}','{3}')", cffk.first_kind_id, cffk.first_kind_name, cffk.first_kind_salary_id, cffk.first_kind_sale_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        /// <summary>
        /// 根据主键，自动增长列删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelByffk_id(object id)
        {
            string sql = string.Format("delete from dbo.config_file_first_kind where ffk_id={0}", id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        /// <summary>
        /// 获取所有一级机构的数据
        /// </summary>
        /// <returns></returns>
        public List<config_file_first_kind> GetAll()
        {
            string sql = "select * from dbo.config_file_first_kind";
            List<config_file_first_kind> list = new List<config_file_first_kind>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    config_file_first_kind cffk = new config_file_first_kind();
                    cffk.ffk_id = (int)reader["ffk_id"];
                    cffk.first_kind_id = reader["first_kind_id"].ToString();
                    cffk.first_kind_name = reader["first_kind_name"].ToString();
                    cffk.first_kind_salary_id = reader["first_kind_salary_id"].ToString();
                    cffk.first_kind_sale_id = reader["first_kind_sale_id"].ToString();
                    list.Add(cffk);
                }
            }
            return list;
        }

        public config_file_first_kind GetByffk_id(object id)
        {
            string sql = string.Format("select * from dbo.config_file_first_kind where ffk_id={0}",id);
            config_file_first_kind cffk = new config_file_first_kind();
            using (SqlDataReader reader = SqlHelper.MyReader(sql, null))
            {
                if (reader.Read())
                {
                    cffk.ffk_id = (int)reader["ffk_id"];
                    cffk.first_kind_id = reader["first_kind_id"].ToString();
                    cffk.first_kind_name = reader["first_kind_name"].ToString();
                    cffk.first_kind_salary_id = reader["first_kind_salary_id"].ToString();
                    cffk.first_kind_sale_id = reader["first_kind_sale_id"].ToString();
                }
            }
            return cffk;
        }

        //获取一级机构的基本总金额和人数
        public List<Dictionary<string, object>> GetByFirst()
        {
            string sql = string.Format("select *,(select COUNT(*) from human_file where cffk.first_kind_id=first_kind_id) as 'count',(select SUM(salary_sum) from human_file where cffk.first_kind_id=first_kind_id) as 'sum',(select SUM(paid_salary_sum) from human_file where cffk.first_kind_id=first_kind_id) as '实发总金额' from dbo.config_file_first_kind cffk");
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {                 
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("id", reader["ffk_id"]);
                    dic.Add("config_id", reader["first_kind_id"]);
                    dic.Add("config_name", reader["first_kind_name"]);
                    dic.Add("count", reader["count"]);
                    dic.Add("sum", reader["sum"]==DBNull.Value?0:reader["sum"]);
                    dic.Add("level", "I结构");
                    dic.Add("实发总金额", reader["实发总金额"] == DBNull.Value ? 0 : reader["实发总金额"]);
                    list.Add(dic);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取最大的一级机构编号
        /// </summary>
        /// <returns></returns>
        public object GetMaxfirst_kind_id()
        {
            string sql = "select MAX(first_kind_id) from dbo.config_file_first_kind";
            return SqlHelper.MyScalar(sql, null);
        }

        public int Update(config_file_first_kind cffk)
        {
            string sql = string.Format("update dbo.config_file_first_kind set first_kind_id='{0}',first_kind_name='{1}',first_kind_salary_id='{2}',first_kind_sale_id='{3}' where ffk_id={4}", cffk.first_kind_id, cffk.first_kind_name, cffk.first_kind_salary_id, cffk.first_kind_sale_id, cffk.ffk_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }
    }
}
