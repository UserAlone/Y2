using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
namespace UI
{
    public class DBhelper
    {
        public static DataTable Select(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();

            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            if (ps != null)
            {
                ad.SelectCommand.Parameters.AddRange(ps);
            }
            DataTable dt = new DataTable();
            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {

                throw;
            }
            return dt;
        }

        private static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
            return cn;
        }

        public static int InsertUpdateDelte(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();

            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            int result = 0;
            try
            {
                cn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return result;
        }

        public static object SelectSinger(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            object obj = null;
            try
            {
                cn.Open();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;

            }
            finally
            {
                cn.Close();
            }

            return obj;
        }

        public static SqlDataReader SelectReader(string sql, string fileName, params SqlParameter[] ps)
        {
            SqlConnection cn = GetConnection();

            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw;

            }
            return reader;
        }


        public static DataTable SelectProc(SqlParameter[] ps, string fileName)
        {
            SqlConnection cn = GetConnection();
            string sql = "FenYe";

            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            //执行的是存储过程
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            //命令对象添加参数对象
            ad.SelectCommand.Parameters.AddRange(ps);
            DataTable dt = new DataTable();
            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;

            }
            return dt;
        }
        //作业2：完成增删改；查询单个值;查询SqlDataReader
    }
}
