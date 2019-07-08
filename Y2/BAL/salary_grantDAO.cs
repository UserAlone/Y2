using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using System.Data.SqlClient;
using System.Data;

namespace BAL
{
    public class salary_grantDAO : salary_grantIDAO
    {
        //登记
        public int DengJi(salary_grant sg)
        {
            string sql = string.Format(@"insert into salary_grant(salary_grant_id, salary_standard_id, first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, human_amount, salary_standard_sum, salary_paid_sum, register, regist_time)
                                      values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},{10},'{11}','{12}')", sg.salary_grant_id, sg.salary_standard_id, sg.first_kind_id, sg.first_kind_name, sg.second_kind_id, sg.second_kind_name, sg.third_kind_id, sg.third_kind_name, sg.human_amount, sg.salary_standard_sum, sg.salary_paid_sum, sg.register, sg.regist_time);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        /// <summary>
        /// 复核
        /// </summary>
        /// <param name="sg"></param>
        /// <returns></returns>
        public int FuHe(salary_grant sg)
        {
            string sql = string.Format("update dbo.salary_grant set salary_paid_sum={0},checker='{1}',check_time='{2}',check_status=1 where salary_grant_id='{3}'",sg.salary_paid_sum,sg.checker,sg.check_time,sg.salary_grant_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }

        /// <summary>
        /// 获取还没有复核的薪酬发放登记表数据
        /// </summary>
        /// <returns></returns>
        public List<salary_grant> GetByCheckStatus(Page<salary_grant> p)
        {
            List<salary_grant> list = new List<salary_grant>();
            List<SqlParameter> para = new List<SqlParameter>();
            string sql = "proc_FenYe";
            para.Add(new SqlParameter("@CurrentPage", p.CurrentPage));
            para.Add(new SqlParameter("@PageSize", p.PageSize));
            para.Add(new SqlParameter("@KeyName", p.KeyName));
            para.Add(new SqlParameter("@TableName", p.TableName));
            para.Add(new SqlParameter("@Where", p.Where));
            para.Add(new SqlParameter() { ParameterName = "@TotalCount", Direction = ParameterDirection.Output, DbType = DbType.Int32 });
            para.Add(new SqlParameter() { ParameterName = "@TotalPage", Direction = ParameterDirection.Output, DbType = DbType.Int32 });
            using (SqlDataReader reader=SqlHelper.SelectProc(sql,para))
            {
                while (reader.Read())
                {
                    salary_grant sg = new salary_grant();
                    sg.salary_grant_id = reader["salary_grant_id"].ToString();
                    sg.salary_standard_id = reader["salary_standard_id"].ToString();
                    sg.first_kind_id = reader["first_kind_id"] == DBNull.Value ? "" : reader["first_kind_id"].ToString();
                    sg.first_kind_name = reader["first_kind_name"] == DBNull.Value ? "" : reader["first_kind_name"].ToString();
                    sg.second_kind_id = reader["second_kind_id"] == DBNull.Value ? "" : reader["second_kind_id"].ToString();
                    sg.second_kind_name = reader["second_kind_name"] == DBNull.Value ? "" : reader["second_kind_name"].ToString();
                    sg.third_kind_id = reader["third_kind_id"] == DBNull.Value ? "" : reader["third_kind_id"].ToString();
                    sg.third_kind_name = reader["third_kind_name"] == DBNull.Value ? "" : reader["third_kind_name"].ToString();
                    sg.human_amount = (short)reader["human_amount"];
                    sg.salary_standard_sum = (decimal)reader["salary_standard_sum"];
                    sg.salary_paid_sum = (decimal)reader["salary_paid_sum"];
                    list.Add(sg);
                }
            }
            p.TotalCount = (int)para[5].Value;
            p.TotalPage = (int)para[6].Value;
            return list;
        }

        /// <summary>
        /// 根据发放编号查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public salary_grant GetBysalary_grant_id(object id)
        {
            string sql = string.Format("select * from dbo.salary_grant where salary_grant_id='{0}' and sgr_id in (select MAX(sgr_id) from salary_grant group by salary_grant_id)", id);
            salary_grant sg = new salary_grant();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                if (reader.Read())
                {
                    sg.salary_grant_id = reader["salary_grant_id"].ToString();
                    sg.salary_standard_id = reader["salary_standard_id"].ToString();
                    sg.first_kind_id = reader["first_kind_id"] == DBNull.Value ? "" : reader["first_kind_id"].ToString();
                    sg.first_kind_name = reader["first_kind_name"] == DBNull.Value ? "" : reader["first_kind_name"].ToString();
                    sg.second_kind_id = reader["second_kind_id"] == DBNull.Value ? "" : reader["second_kind_id"].ToString();
                    sg.second_kind_name = reader["second_kind_name"] == DBNull.Value ? "" : reader["second_kind_name"].ToString();
                    sg.third_kind_id = reader["third_kind_id"] == DBNull.Value ? "" : reader["third_kind_id"].ToString();
                    sg.third_kind_name = reader["third_kind_name"] == DBNull.Value ? "" : reader["third_kind_name"].ToString();
                    sg.human_amount = (short)reader["human_amount"];
                    sg.salary_standard_sum = (decimal)reader["salary_standard_sum"];
                    sg.salary_paid_sum = (decimal)reader["salary_paid_sum"];
                    sg.register = reader["register"].ToString();
                    sg.regist_time = (DateTime)reader["regist_time"];
                }
            }
            return sg;
        }

        /// <summary>
        /// 查询复核的数据
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<salary_grant> GetByWhere(Page<salary_grant> p)
        {
            List<salary_grant> list = new List<salary_grant>();
            List<SqlParameter> para = new List<SqlParameter>();
            string sql = "proc_FenYe";
            para.Add(new SqlParameter("@CurrentPage", p.CurrentPage));
            para.Add(new SqlParameter("@PageSize", p.PageSize));
            para.Add(new SqlParameter("@KeyName", p.KeyName));
            para.Add(new SqlParameter("@TableName", p.TableName));
            para.Add(new SqlParameter("@Where", p.Where));
            para.Add(new SqlParameter() { ParameterName = "@TotalCount", Direction = ParameterDirection.Output, DbType = DbType.Int32 });
            para.Add(new SqlParameter() { ParameterName = "@TotalPage", Direction = ParameterDirection.Output, DbType = DbType.Int32 });
            using (SqlDataReader reader = SqlHelper.SelectProc(sql, para))
            {
                while (reader.Read())
                {
                    salary_grant sg = new salary_grant();
                    sg.salary_grant_id = reader["salary_grant_id"].ToString();
                    sg.salary_standard_id = reader["salary_standard_id"].ToString();
                    sg.first_kind_id = reader["first_kind_id"] == DBNull.Value ? "" : reader["first_kind_id"].ToString();
                    sg.first_kind_name = reader["first_kind_name"] == DBNull.Value ? "" : reader["first_kind_name"].ToString();
                    sg.second_kind_id = reader["second_kind_id"] == DBNull.Value ? "" : reader["second_kind_id"].ToString();
                    sg.second_kind_name = reader["second_kind_name"] == DBNull.Value ? "" : reader["second_kind_name"].ToString();
                    sg.third_kind_id = reader["third_kind_id"] == DBNull.Value ? "" : reader["third_kind_id"].ToString();
                    sg.third_kind_name = reader["third_kind_name"] == DBNull.Value ? "" : reader["third_kind_name"].ToString();
                    sg.human_amount = (short)reader["human_amount"];
                    sg.salary_standard_sum = (decimal)reader["salary_standard_sum"];
                    sg.salary_paid_sum = (decimal)reader["salary_paid_sum"];
                    list.Add(sg);
                }
            }
            p.TotalCount = (int)para[5].Value;
            p.TotalPage = (int)para[6].Value;
            return list;
        }

        /// <summary>
        ///根据薪酬发放编号获取薪酬标准单编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<object> Getsalary_standard_idBysalary_grant_id(object id)
        {
            string sql = string.Format("select salary_standard_id from dbo.salary_grant where salary_grant_id='{0}'", id);
            List<object> list = new List<object>();
            using (SqlDataReader reader=SqlHelper.MyReader(sql,null))
            {
                while (reader.Read())
                {
                    list.Add(reader["salary_standard_id"]);
                }
            }
            return list;
        }
    }
}
