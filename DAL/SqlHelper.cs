using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{

    /// <summary>
    /// 执行Sql 命令的通用方法
    /// </summary>
    public class SqlHelper
    {

        //Database connection strings
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        #region ExecuteNonQuery


        /// <summary>
        /// 执行Sql Server存储过程
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues"></param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(CommandType mommandtype, string text, params SqlParameter[] parameter)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, mommandtype, conn, text, parameter);
                int val = cmd.ExecuteNonQuery();

                return val;
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        ///  执行sql命令
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>SqlDataReader 对象</returns>
        public static SqlDataReader ExecuteReader( CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region ExecuteDataset


        public static DataSet ExecuteDataset(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    return ds;
                }
            }
        }


        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行Sql 语句
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">Sql 语句/参数化的sql语句</param>
        /// <param name="parameterValues">参数</param>
        /// <returns>执行结果对象</returns>
        public static object ExecuteScalar( CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                object val = cmd.ExecuteScalar();

                return val;
            }
        }
        #endregion


        #region Private Method
        /// <summary>
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>

        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, SqlParameter[] cmdParms)
        {
            //打开连接
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //设置SqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion


    }
}