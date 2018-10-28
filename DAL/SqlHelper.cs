using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{

    /// <summary>
    /// ִ��Sql �����ͨ�÷���
    /// </summary>
    public class SqlHelper
    {

        //Database connection strings
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        #region ExecuteNonQuery


        /// <summary>
        /// ִ��Sql Server�洢����
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="spName">�洢������</param>
        /// <param name="parameterValues"></param>
        /// <returns>��Ӱ�������</returns>
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
        ///  ִ��sql����
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>SqlDataReader ����</returns>
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
        /// ִ��Sql ���
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="spName">Sql ���/��������sql���</param>
        /// <param name="parameterValues">����</param>
        /// <returns>ִ�н������</returns>
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
        /// ����һ���ȴ�ִ�е�SqlCommand����
        /// </summary>

        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, SqlParameter[] cmdParms)
        {
            //������
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //����SqlCommand����
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