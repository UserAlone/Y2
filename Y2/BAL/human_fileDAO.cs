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
    public class human_fileDAO : human_fileIDAO
    {
        //获取一级机构的数根据机构id查询
        public List<human_file> GetFirstConfigByID(object id)
        {
            string sql = string.Format("select * from dbo.human_file where first_kind_id = {0}", id);
            List<human_file> list = new List<human_file>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    //Dictionary<string, object> dic = new Dictionary<string, object>();
                    human_file hf = new human_file();
                    hf.human_id = reader["human_id"] == DBNull.Value ? "" : reader["human_id"].ToString();
                    hf.human_name = reader["human_name"] == DBNull.Value ? "" : reader["human_name"].ToString();
                    hf.paid_salary_sum = reader["paid_salary_sum"] == DBNull.Value ? 0 : (decimal)reader["paid_salary_sum"];
                    hf.salary_standard_id = reader["salary_standard_id"] == DBNull.Value ? "" : reader["salary_standard_id"].ToString();
                    hf.salary_sum = reader["salary_sum"] == DBNull.Value ? 0 : (decimal)reader["salary_sum"];
                    //dic.Add("hf", hu);
                    list.Add(hf);
                }
            }
            return list;
        }

        //获取三级级机构的数根据机构id查询
        public List<human_file> GetThridConfigByID(object id)
        {
            string sql = string.Format("select * from human_file where third_kind_id={0}",id);
            List<human_file> list = new List<human_file>();
            using (SqlDataReader reader = SqlHelper.MyReader(sql, null))
            {
                while (reader.Read())
                {
                    //Dictionary<string, object> dic = new Dictionary<string, object>();
                    human_file hu = new human_file();
                    hu.human_id = reader["human_id"] == DBNull.Value ? "" : reader["human_id"].ToString();
                    hu.human_name = reader["human_name"] == DBNull.Value ? "" : reader["human_name"].ToString();
                    hu.paid_salary_sum = reader["paid_salary_sum"] == DBNull.Value ? 0 : (decimal)reader["paid_salary_sum"];
                    hu.salary_standard_id = reader["salary_standard_id"] == DBNull.Value ? "" : reader["salary_standard_id"].ToString();
                    hu.salary_sum = reader["salary_sum"] == DBNull.Value ? 0 : (decimal)reader["salary_sum"];
                    //dic.Add("hf", hu);
                    list.Add(hu);
                }
            }
            return list;
        }

        //获取二级级机构的数根据机构id查询
        public List<human_file> GetTwoConfigByID(object id)
        {
            string sql = string.Format("select * from human_file where second_kind_id={0}", id);
            List<human_file> list = new List<human_file>();
            using (SqlDataReader reader = SqlHelper.MyReader(sql, null))
            {
                while (reader.Read())
                {
                    //Dictionary<string, object> dic = new Dictionary<string, object>();
                    human_file hu = new human_file();
                    hu.human_id = reader["human_id"]==DBNull.Value?"":reader["human_id"].ToString();
                    hu.human_name = reader["human_name"]==DBNull.Value?"":reader["human_name"].ToString();
                    hu.paid_salary_sum = reader["paid_salary_sum"] == DBNull.Value ? 0 : (decimal)reader["paid_salary_sum"];
                    hu.salary_standard_id = reader["salary_standard_id"] == DBNull.Value ? "" : reader["salary_standard_id"].ToString();
                    hu.salary_sum = reader["salary_sum"] == DBNull.Value ? 0 : (decimal)reader["salary_sum"];
                    //dic.Add("hf", hu);
                    list.Add(hu);
                }
            }
            return list;
        }
    }
}
