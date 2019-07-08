using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace BAL
{
    public class SalaryStandardDAO : BaseDao, SalaryStandardIDAO
    {
        public int AddSalaryStandard(salary_standard ss)
        {
            string sql = "insert into salary_standard(standard_id,standard_name,designer,register,salary_sum,remark,regist_time,check_status)values(@standard_id,@standard_name,@designer,@register,@salary_sum,@remark,@regist_time,@check_status);";
            List<SqlParameter> para = new List<SqlParameter>();
            para.Add(new SqlParameter("@standard_id", ss.standard_id));
            para.Add(new SqlParameter("@standard_name", ss.standard_name));
            para.Add(new SqlParameter("@designer", ss.designer));
            para.Add(new SqlParameter("@register", ss.register));
            para.Add(new SqlParameter("@salary_sum", ss.salary_sum));
            para.Add(new SqlParameter("@remark", ss.remark));
            para.Add(new SqlParameter("@regist_time", ss.regist_time));
            para.Add(new SqlParameter("@check_status", ss.check_status));
            return SqlHelper.MyExecuteNonQuery(sql, para.ToArray());
        }

        //根据薪酬标准单编号变更
        public int ChangeByStandardId(salary_standard ss)
        {
            string sql = string.Format("update salary_standard set standard_name='{0}',salary_sum={1},designer='{2}',changer='{3}',change_time='{4}',remark='{5}',change_status={6}  where standard_id='{7}'", ss.standard_name, ss.salary_sum, ss.designer, ss.changer, ss.change_time, ss.remark,ss.change_status,ss.standard_id);
            return SqlHelper.MyExecuteNonQuery(sql,null);
        }

        //查询没有复核的薪酬标准
        public List<salary_standard> FindByCheckStatus(Page<salary_standard> p)
        {
            List<salary_standard> list = new List<salary_standard>();
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
                    salary_standard ss = new salary_standard();
                    ss.ssd_id = (short)reader["ssd_id"];
                    ss.standard_id = reader["standard_id"].ToString();
                    ss.standard_name = reader["standard_name"].ToString();
                    ss.designer = reader["designer"].ToString();
                    ss.regist_time = (DateTime)reader["regist_time"];
                    ss.salary_sum = (decimal)reader["salary_sum"];
                    ss.check_status = (short)reader["check_status"];
                    list.Add(ss);
                }
            }
            p.TotalCount = (int)para[5].Value;
            p.TotalPage = (int)para[6].Value;
            return list;
        }

        public List<salary_standard> FindByPage(Page<salary_standard> p)
        {
            List<salary_standard> list = new List<salary_standard>();
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
                    salary_standard ss = new salary_standard();
                    ss.ssd_id = (short)reader["ssd_id"];
                    ss.standard_id = reader["standard_id"].ToString();
                    ss.standard_name = reader["standard_name"].ToString();
                    ss.designer = reader["designer"].ToString();
                    ss.regist_time = (DateTime)reader["regist_time"];
                    ss.salary_sum = (decimal)reader["salary_sum"];
                    ss.check_status = (short)reader["check_status"];
                    list.Add(ss);
                }
            }
            p.TotalCount = (int)para[5].Value;
            p.TotalPage = (int)para[6].Value;
            return list;
        }
        //根据ssd_id 查询薪酬标准
        public salary_standard FindByssd_id(object ssd_id)
        {
            salary_standard ss = new salary_standard();
            string sql = string.Format("select * from dbo.salary_standard where ssd_id={0}", ssd_id);
            using (SqlDataReader reader = SqlHelper.MyReader(sql, null))
            {
                if (reader.Read())
                {
                    ss.ssd_id = (short)reader["ssd_id"];
                    ss.standard_id = reader["standard_id"].ToString();
                    ss.standard_name = reader["standard_name"].ToString();
                    ss.designer = reader["designer"].ToString();
                    ss.regist_time = (DateTime)reader["regist_time"];
                    ss.salary_sum = (decimal)reader["salary_sum"];
                    ss.check_status = (short)reader["check_status"];
                    ss.remark = reader["remark"].ToString();
                }
            }
            return ss;
        }

        public salary_standard FindByStandardId(string standardId)
        {
            salary_standard ss = new salary_standard();
            string sql = string.Format("select * from dbo.salary_standard where standard_id='{0}'", standardId);
            using (SqlDataReader reader = SqlHelper.MyReader(sql, null))
            {
                //ssd_id, standard_id, standard_name, designer, register, checker, changer, regist_time, check_time, change_time, salary_sum, check_status, change_status, check_comment, remark
                if (reader.Read())
                {
                    ss.ssd_id = (short)reader["ssd_id"];
                    ss.standard_id = reader["standard_id"].ToString();
                    ss.standard_name = reader["standard_name"].ToString();
                    ss.designer = reader["designer"].ToString();
                    ss.regist_time = (DateTime)reader["regist_time"];
                    ss.salary_sum = (decimal)reader["salary_sum"];
                    ss.check_status = (short)reader["check_status"];
                    ss.remark = reader["remark"].ToString();
                    ss.checker = reader["checker"].ToString();
                    ss.check_time = reader["check_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["check_time"];
                }
            }
            return ss;
        }

        //根据条件查询薪酬标准登记还没变更的数据
        public List<salary_standard> FindByWhereAndChangeStaus(Page<salary_standard> p)
        {
            List<salary_standard> list = new List<salary_standard>();
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
                    salary_standard ss = new salary_standard();
                    ss.ssd_id = (short)reader["ssd_id"];
                    ss.standard_id = reader["standard_id"].ToString();
                    ss.standard_name = reader["standard_name"].ToString();
                    ss.designer = reader["designer"].ToString();
                    ss.regist_time = (DateTime)reader["regist_time"];
                    ss.salary_sum = (decimal)reader["salary_sum"];                 
                    list.Add(ss);
                }
            }
            p.TotalCount = (int)para[5].Value;
            p.TotalPage = (int)para[6].Value;
            return list;
        }

        //带条件获取薪酬标准登记查询数据
        public List<salary_standard> GetByWhere(Page<salary_standard> p)
        {
            List<salary_standard> list = new List<salary_standard>();
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
                    salary_standard ss = new salary_standard();
                    ss.ssd_id = (short)reader["ssd_id"];
                    ss.standard_id = reader["standard_id"].ToString();
                    ss.standard_name = reader["standard_name"].ToString();
                    ss.designer = reader["designer"].ToString();
                    ss.regist_time = (DateTime)reader["regist_time"];
                    ss.salary_sum = (decimal)reader["salary_sum"];
                    //ss.check_status = (short)reader["check_status"];
                    list.Add(ss);
                }
            }
            p.TotalCount = (int)para[5].Value;
            p.TotalPage = (int)para[6].Value;
            return list;
        }

        public object IsContainer(string danhao)
        {
            string sql = string.Format("select COUNT(*) from dbo.salary_standard where standard_id='{0}'", danhao);
            return SqlHelper.MyScalar(sql, null);
        }

        //根据ssd_id复核薪酬标准
        public int ReviewByssd_id(salary_standard ss)
        {
            string sql = string.Format(@"update dbo.salary_standard set check_status=1,check_comment='{0}',check_time='{1}',checker='{2}' where ssd_id={3}",ss.check_comment,ss.check_time,ss.checker,ss.ssd_id);
            return SqlHelper.MyExecuteNonQuery(sql, null);
        }
    }
}
