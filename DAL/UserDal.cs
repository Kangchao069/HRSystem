using Common;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDal
    {
        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <returns></returns>
        public DataTable selUserTypeInfor()
        {
            DataTable dt = new DataTable();
            string sql = "select * from [dbo].[U_UserType]";
            dt = SqlHelper.ExecuteDataset(CommandType.Text, sql, null).Tables[0];
            return dt;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="us"></param>
        public U_User GetInfoByNameAndPswAndType(string name, string psw, int utid)
        {
            U_User us = new U_User();
            try
            {

                string sql = "select * from [dbo].[U_UserInfor]as a left join [dbo].[U_UserType] as b on a.UTID=b.UTID left join[dbo].[U_Post] as c on a.PID=c.PID left join[dbo].[U_Department] as d on a.DID=D.DID left join[dbo].[U_EducationInfo] as e on a.EID=e.EID where a.LoginName='" + name + "'and a.LoginPassword='" + psw + "'and a.UTID='" + utid + "'";
                //SqlParameter[] sql = new SqlParameter[] {
                //    new SqlParameter("@LoginName",name),
                //    new SqlParameter("@LoginPassword",psw),
                //    new SqlParameter("@UTID",utid)
                //};
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null);
                while (reader.Read())
                {
                    us.UID = int.Parse(reader["UID"].ToString());
                    us.LoginName = reader["LoginName"].ToString();
                    us.LoginPassword = reader["LoginPassword"].ToString();
                    us.UserName = reader["UserName"].ToString();
                    U_Post p = new U_Post();
                    p.PID = int.Parse(reader["PID"].ToString());
                    p.PName = reader["PName"].ToString();
                    us.PID = p;
                    U_UserType UT = new U_UserType();
                    UT.UTID = int.Parse(reader["UTID"].ToString());
                    UT.TypeName = reader["TName"].ToString();
                    us.UTID = UT;
                    U_Department dp = new U_Department();
                    dp.DID = int.Parse(reader["DID"].ToString());
                    dp.DName = reader["DName"].ToString();
                    us.DID = dp;
                    U_EducationInfo et = new U_EducationInfo();
                    et.EID = int.Parse(reader["EID"].ToString());
                    et.Education = reader["Education"].ToString();
                    us.EID = et;
                    us.Phone = reader["Phone"].ToString();
                    us.IDCard = reader["IDCard"].ToString();
                    us.Details = reader["Details"].ToString();
                    us.Address = reader["Address"].ToString();
                    us.Email = reader["Email"].ToString();
                    us.Sex = reader["Sex"].ToString();
                    us.Remark = reader["Remark"].ToString();
                    us.State = reader["State"].ToString();
                    us.Academy = reader["Academy"].ToString();

                }

            }
            catch (Exception ex)
            {

                Common.JsMessage.jsAlert(ex.Message);
            }
            return us;
        }
        /// <summary>
        /// 系统日志
        /// </summary>
        /// <param name="ji"></param>
        public void AddJournalInfo(M_JournalInfo ji)
        {
            try
            {
                SqlParameter[] sql = new SqlParameter[] {

                    new SqlParameter("@Content",ji.Content),
                    new SqlParameter("@ReleaseTime",ji.ReleaseTime),
                    new SqlParameter("@LoginName",ji.LoginName)
                };
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "AddJournalInfo", sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 用户查询个人信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public U_User selAllUserInfoByID(int uid)
        {
            U_User us = new U_User();
            try
            {
                SqlParameter[] sql = new SqlParameter[] {
                    new SqlParameter ("@UID",uid)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[dbo].[U_sleUserInforByID]", sql);
                while (reader.Read())
                {
                    us.UID = int.Parse(reader["UID"].ToString());
                    us.LoginName = reader["LoginName"].ToString();
                    us.LoginPassword = reader["LoginPassword"].ToString();
                    us.UserName = reader["UserName"].ToString();
                    U_Post p = new U_Post();
                    p.PID = int.Parse(reader["PID"].ToString());
                    p.PName = reader["PName"].ToString();
                    us.PID = p;
                    U_UserType UT = new U_UserType();
                    UT.UTID = int.Parse(reader["UTID"].ToString());
                    UT.TypeName = reader["TName"].ToString();
                    us.UTID = UT;
                    U_Department dp = new U_Department();
                    dp.DID = int.Parse(reader["DID"].ToString());
                    dp.DName = reader["DName"].ToString();
                    us.DID = dp;
                    U_EducationInfo et = new U_EducationInfo();
                    et.EID = int.Parse(reader["EID"].ToString());
                    et.Education = reader["Education"].ToString();
                    us.EID = et;
                    us.Phone = reader["Phone"].ToString();
                    us.IDCard = reader["IDCard"].ToString();
                    us.Details = reader["Details"].ToString();
                    us.Address = reader["Address"].ToString();
                    us.Email = reader["Email"].ToString();
                    us.Sex = reader["Sex"].ToString();
                    us.Remark = reader["Remark"].ToString();
                    us.State = reader["st"].ToString();
                    us.Academy = reader["Academy"].ToString();
                    // user.Add(us);


                }

            }
            catch (Exception)
            {

                throw;
            }
            return us;
        }
        /// <summary>
        /// 查询用户学历信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelEductaionInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from [dbo].[U_EducationInfo] ";
                return SqlHelper.ExecuteDataset(CommandType.Text, sql, null).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public int UpdUserInfor(U_User us)
        {
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@UID",us.UID),
                    new SqlParameter ("@UserName",us.UserName),
                    new SqlParameter ("@Phone",us.Phone),
                    new SqlParameter ("@IDCard",us.IDCard),
                    new SqlParameter ("@Address",us.Address),
                    new SqlParameter ("@Academy",us.Academy),
                    new SqlParameter ("@EID",us.EID.EID),
                    new SqlParameter ("@SEX",us.Sex),
                    new SqlParameter ("@Details",us.Details),
                    new SqlParameter ("@Remark",us.Remark)
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[U_UpdUserInfor]", mySql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 查询用户部门
        /// </summary>
        /// <returns></returns>
        public DataTable U_SelDepartment()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from [dbo].[U_Department] ";
                return SqlHelper.ExecuteDataset(CommandType.Text, sql, null).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 查询用户所有信息
        /// </summary>
        /// <returns></returns>
        public List<U_User> U_SelAllUserInfo()
        {
            List<U_User> user = new List<U_User>();
            try
            {
                SqlParameter[] sql = new SqlParameter[] {

                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "U_SelAllUserInfos", sql);
                while (reader.Read())
                {
                    U_User us = new U_User();
                    us.UID = int.Parse(reader["UID"].ToString());
                    us.LoginName = reader["LoginName"].ToString();
                    us.LoginPassword = reader["LoginPassword"].ToString();
                    us.UserName = reader["UserName"].ToString();
                    U_Post p = new U_Post();
                    p.PID = int.Parse(reader["PID"].ToString());
                    p.PName = reader["PName"].ToString();
                    us.PID = p;
                    U_UserType UT = new U_UserType();
                    UT.UTID = int.Parse(reader["UTID"].ToString());
                    UT.TypeName = reader["TName"].ToString();
                    us.UTID = UT;
                    U_Department dp = new U_Department();
                    dp.DID = int.Parse(reader["DID"].ToString());
                    dp.DName = reader["DName"].ToString();
                    us.DID = dp;
                    U_EducationInfo et = new U_EducationInfo();
                    et.EID = int.Parse(reader["EID"].ToString());
                    et.Education = reader["Education"].ToString();
                    us.EID = et;
                    us.Phone = reader["Phone"].ToString();
                    us.IDCard = reader["IDCard"].ToString();
                    us.Details = reader["Details"].ToString();
                    us.Address = reader["Address"].ToString();
                    us.Email = reader["Email"].ToString();
                    us.Sex = reader["Sex"].ToString();
                    us.Remark = reader["Remark"].ToString();
                    us.State = reader["State"].ToString();
                    us.Academy = reader["Academy"].ToString();
                    user.Add(us);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return user;
        }
        /// <summary>
        /// 通过用户ID模糊查询用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_User> U_SelAllUserInfoByIDs(int uid)
        {
            List<U_User> user = new List<U_User>();

            try
            {
                SqlParameter[] sql = new SqlParameter[] {
                    new SqlParameter ("@UID",uid)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[dbo].[U_SelAllUserInfoByUID]", sql);
                while (reader.Read())
                {
                    U_User us = new U_User();
                    us.UID = int.Parse(reader["UID"].ToString());
                    us.LoginName = reader["LoginName"].ToString();
                    us.LoginPassword = reader["LoginPassword"].ToString();
                    us.UserName = reader["UserName"].ToString();
                    U_Post p = new U_Post();
                    p.PID = int.Parse(reader["PID"].ToString());
                    p.PName = reader["PName"].ToString();
                    us.PID = p;
                    U_UserType UT = new U_UserType();
                    UT.UTID = int.Parse(reader["UTID"].ToString());
                    UT.TypeName = reader["TName"].ToString();
                    us.UTID = UT;
                    U_Department dp = new U_Department();
                    dp.DID = int.Parse(reader["DID"].ToString());
                    dp.DName = reader["DName"].ToString();
                    us.DID = dp;
                    U_EducationInfo et = new U_EducationInfo();
                    et.EID = int.Parse(reader["EID"].ToString());
                    et.Education = reader["Education"].ToString();
                    us.EID = et;
                    us.Phone = reader["Phone"].ToString();
                    us.IDCard = reader["IDCard"].ToString();
                    us.Details = reader["Details"].ToString();
                    us.Address = reader["Address"].ToString();
                    us.Email = reader["Email"].ToString();
                    us.Sex = reader["Sex"].ToString();
                    us.Remark = reader["Remark"].ToString();
                    us.State = reader["State"].ToString();
                    us.Academy = reader["Academy"].ToString();
                    user.Add(us);


                }

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
        /// <summary>
        /// 通过用户名模糊查询用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<U_User> U_SelAllUserInfoByNames(string name)
        {
            List<U_User> user = new List<U_User>();
            try
            {
                SqlParameter[] sql = new SqlParameter[] {
                    new SqlParameter ("@UserName",name)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "U_SelAllUserInfoByNames", sql);
                while (reader.Read())
                {
                    U_User us = new U_User();
                    us.UID = int.Parse(reader["UID"].ToString());
                    us.LoginName = reader["LoginName"].ToString();
                    us.LoginPassword = reader["LoginPassword"].ToString();
                    us.UserName = reader["UserName"].ToString();
                    U_Post p = new U_Post();
                    p.PID = int.Parse(reader["PID"].ToString());
                    p.PName = reader["PName"].ToString();
                    us.PID = p;
                    U_UserType UT = new U_UserType();
                    UT.UTID = int.Parse(reader["UTID"].ToString());
                    UT.TypeName = reader["TName"].ToString();
                    us.UTID = UT;
                    U_Department dp = new U_Department();
                    dp.DID = int.Parse(reader["DID"].ToString());
                    dp.DName = reader["DName"].ToString();
                    us.DID = dp;
                    U_EducationInfo et = new U_EducationInfo();
                    et.EID = int.Parse(reader["EID"].ToString());
                    et.Education = reader["Education"].ToString();
                    us.EID = et;
                    us.Phone = reader["Phone"].ToString();
                    us.IDCard = reader["IDCard"].ToString();
                    us.Details = reader["Details"].ToString();
                    us.Address = reader["Address"].ToString();
                    us.Email = reader["Email"].ToString();
                    us.Sex = reader["Sex"].ToString();
                    us.Remark = reader["Remark"].ToString();
                    us.State = reader["State"].ToString();
                    us.Academy = reader["Academy"].ToString();
                    user.Add(us);


                }

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
        /// <summary>
        /// 通过部门查询用户数据
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_User> U_selAllUserInfoByDID(int did)
        {
            List<U_User> user = new List<U_User>();

            try
            {
                string sql = "select * from [dbo].[U_UserInfor] as a left join [dbo].[U_UserType] as b on a.UTID=b.UTID left join[dbo].[U_Post] as c on a.PID=c.PID left join[dbo].[U_Department] as d on a.DID=D.DID left join[dbo].[U_EducationInfo] as e on a.EID=e.EID WHERE a.DID='" + did + "'";
                //SqlParameter[] sql = new SqlParameter[] {
                //    new SqlParameter ("@UID",did)
                //};
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null);
                while (reader.Read())
                {
                    U_User us = new U_User();
                    us.UID = int.Parse(reader["UID"].ToString());
                    us.LoginName = reader["LoginName"].ToString();
                    us.LoginPassword = reader["LoginPassword"].ToString();
                    us.UserName = reader["UserName"].ToString();
                    U_Post p = new U_Post();
                    p.PID = int.Parse(reader["PID"].ToString());
                    p.PName = reader["PName"].ToString();
                    us.PID = p;
                    U_UserType UT = new U_UserType();
                    UT.UTID = int.Parse(reader["UTID"].ToString());
                    UT.TypeName = reader["TName"].ToString();
                    us.UTID = UT;
                    U_Department dp = new U_Department();
                    dp.DID = int.Parse(reader["DID"].ToString());
                    dp.DName = reader["DName"].ToString();
                    us.DID = dp;
                    U_EducationInfo et = new U_EducationInfo();
                    et.EID = int.Parse(reader["EID"].ToString());
                    et.Education = reader["Education"].ToString();
                    us.EID = et;
                    us.Phone = reader["Phone"].ToString();
                    us.IDCard = reader["IDCard"].ToString();
                    us.Details = reader["Details"].ToString();
                    us.Address = reader["Address"].ToString();
                    us.Email = reader["Email"].ToString();
                    us.Sex = reader["Sex"].ToString();
                    us.Remark = reader["Remark"].ToString();
                    us.State = reader["State"].ToString();
                    us.Academy = reader["Academy"].ToString();
                    user.Add(us);


                }

            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
        /// <summary>
        /// 查询用户职位信息
        /// </summary>
        /// <returns></returns>
        public DataTable U_SelUserPostInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from [dbo].[U_Post] ";
                return SqlHelper.ExecuteDataset(CommandType.Text, sql, null).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 添加请假信息
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int AddUserLeave(U_Leave l)
        {
            try
            {
                SqlParameter[] sql = new SqlParameter[]
                {
                    new SqlParameter ("@UID",l.UID.UID),
                    new SqlParameter ("@DID",l.DID.DID),
                    new SqlParameter ("@LReason",l.LReason),
                    new SqlParameter ("@BeginTime",l.BeginTime),
                    new SqlParameter ("@EndTime",l.EndTime),
                    new SqlParameter ("@Remark",l.Remark)
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "AddUserLeave", sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 添加辞职信息
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        public int U_AddResigntion(U_Resignation re)
        {
            try
            {
                SqlParameter[] sql = new SqlParameter[]
                {
                    new SqlParameter ("@UID",re.UID.UID),
                    new SqlParameter ("@DID",re.DID.DID),
                    new SqlParameter ("@Reason",re.Reason),
                    new SqlParameter ("@Time",re.Time),
                    new SqlParameter ("@Remark",re.Remark),
                    new SqlParameter ("@State",re.State)
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "U_AddResigntion", sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
