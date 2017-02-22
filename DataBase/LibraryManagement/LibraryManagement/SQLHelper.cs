using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class SQLHelper
    {
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;
        private static SqlDataReader sdr = null;

        static SQLHelper()
        {
            conn = new SqlConnection(Properties.Resources.strSQL);
        }

        private static SqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        ///<summary>  
        ///执行不带参数的增删改SQL语句或存储过程  
        /// </summary>  
        /// <param name="cmdText">增删改SQL语句或存储过程</param>  
        /// <param name="ct">命令类型</param>  
        /// <returns></returns>  
        public static int ExecuteNonQuery(string cmdText)
        {
            int res;
            using (cmd = new SqlCommand(cmdText, GetConn()))
            {
                //cmd.CommandType = ct;
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        ///<summary>  
        ///执行不带参数的查询SQL语句或存储过程  
        /// </summary>  
        /// <param name="cmdText">查询SQL语句或存储过程</param>  
        /// <param name="ct">命令类型</param>  
        /// <returns></returns>  
        public static DataTable ExecuteQuery(string cmdText)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmdText, GetConn());
            //cmd.CommandType = ct;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }

        ///<summary>  
        ///执行带参数的增删改SQL语句或存储过程  
        /// </summary>  
        /// <param name="cmdText">增删改SQL语句或存储过程</param>  
        /// <param name="ct">命令类型</param>  
        /// <returns></returns>  
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] paras)
        {
            int res;
            using (cmd = new SqlCommand(cmdText, GetConn()))
            {
                //cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        ///<summary>  
        ///执行带参数的查询SQL语句或存储过程  
        /// </summary>  
        /// <param name="cmdText">查询SQL语句或存储过程</param>  
        /// <param name="paras">参数集合</param>  
        /// <param name="ct">命令类型</param>  
        /// <returns></returns>  
        public static DataTable ExecuteQuery(string cmdText, params SqlParameter[] paras)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmdText, GetConn());
            //cmd.CommandType = ct;
            cmd.Parameters.AddRange(paras);
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
    }
}
