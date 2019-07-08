using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BAL
{
    public class SqlHelper
    {
        //获取连接对象
        public static SqlConnection GetSqlconnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["HR_DB "].ConnectionString);
        }
        //增删改
        public static int MyExecuteNonQuery(string sql, SqlParameter[] sps)
        {
            using (SqlConnection sqlconn = GetSqlconnection())
            {
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.CommandType = CommandType.Text;
                if (sps != null)
                {
                    sqlcmd.Parameters.AddRange(sps);
                }
                sqlconn.Open();
                 return sqlcmd.ExecuteNonQuery();
            }
        }
        //读取器
        public static SqlDataReader MyReader(string sql, SqlParameter[] sps)
        {
            SqlConnection sqlconn = GetSqlconnection();

            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqlcmd.CommandType = CommandType.Text;
            if (sps != null)
            {
                sqlcmd.Parameters.AddRange(sps);
            }
            sqlconn.Open();
            return sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

        }

        //适配器
        public static DataTable MyAdapter(string sql, SqlParameter[] sps)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlconn = GetSqlconnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand.CommandType = CommandType.Text;
                if (sps != null)
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
        }

        //返回单个值
        public static object MyScalar(string sql, SqlParameter[] sps)
        {
            using (SqlConnection sqlconn = GetSqlconnection())
            {
                SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
                sqlcmd.CommandType = CommandType.Text;
                if (sps != null)
                {
                    sqlcmd.Parameters.AddRange(sps);
                }
                sqlconn.Open();
                return sqlcmd.ExecuteScalar();
            }
        }
        //存储过程查询
        public static SqlDataReader SelectProc(string sql, List<SqlParameter> para)
        {
            SqlConnection sqlconn = GetSqlconnection();
            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
            {
                sqlcmd.Parameters.AddRange(para.ToArray());
            }
            sqlconn.Open();
            return sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
