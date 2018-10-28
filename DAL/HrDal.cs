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
   public  class HrDal
    {
        /// <summary>
        /// 修改用户的职位和部门
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int H_UpdUserInfoByPidAndDid(U_User user)
        {
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@UID",user.UID),
                    new SqlParameter ("@UTID",user.UTID.UTID),
                    new SqlParameter ("@PID",user.PID.PID),
                    new SqlParameter ("@DID",user.DID.DID)
                    
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "H_UpdUserInfoByPidAndDid", mySql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 通过用户ID删除用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int H_DelUserInfoByUID(int uid)
        {
            try
            {
                string sql = "delete from [dbo].[U_UserInfor] where UID=" + uid;
                return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public int AddUsers(U_User us)
        {
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@LoginName",us.LoginName),
                    new SqlParameter ("@LoginPassword",us.LoginPassword),
                    new SqlParameter ("@UserName",us.UserName),
                    new SqlParameter ("@UTID",us.UTID.UTID),
                    new SqlParameter ("@DID",us.DID.DID),
                    new SqlParameter ("@PID",us.PID.PID),
                    new SqlParameter ("@EID",us.EID.EID),
                    new SqlParameter ("@IDCard",us.IDCard),
                    new SqlParameter ("@Phone",us.Phone),
                    new SqlParameter ("@Address",us.Address),
                    new SqlParameter ("@Email",us.Email),
                    new SqlParameter ("@Academy",us.Academy),
                    new SqlParameter ("@Sex",us.Sex),
                    new SqlParameter ("@Details",us.Details),
                    new SqlParameter ("@Remark",us.Remark),
                    new SqlParameter ("@State",us.State)
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "addUsers", mySql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 查询所有请假信息
        /// </summary>
        /// <returns></returns>
        public List<U_Leave> H_selLeave()
        {
            List<U_Leave> le = new List<U_Leave>();
            try
            {
                string sql = "select * from [dbo].[U_Leave] as a left join [dbo].[U_UserInfor] as b on a.UID=b.UID left join [dbo].[U_Department] as c on a.DID=c.DID order by a.BeginTime desc";
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null);
                while (reader.Read())
                {
                    U_Leave l = new U_Leave();
                    l.LID = int.Parse(reader["LID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    l.UID = user;
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    l.DID = d;
                    l.LReason = reader["LReason"].ToString();
                    l.BeginTime = reader["BeginTime"].ToString();
                    l.EndTime = reader["EndTime"].ToString();
                    l.Month = reader["Month"].ToString();
                    l.Remark = reader["Remark"].ToString();
                    l.State = reader["State"].ToString();
                    le.Add(l);
                }
            }
            catch (Exception ex)
            {
                JsMessage.jsAlert(ex.Message);
               
            }
            return le;
        }
        /// <summary>
        /// 通过员工编号模糊查询请假信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_Leave> H_selLeaveByUid(int uid)
        {
            List<U_Leave> le = new List<U_Leave>();
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@UID",uid)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "H_selLeaveByUid", mySql);
                while (reader.Read())
                {
                    U_Leave l = new U_Leave();
                    l.LID = int.Parse(reader["LID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    l.UID = user;
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    l.DID = d;
                    l.LReason = reader["LReason"].ToString();
                    l.BeginTime = reader["BeginTime"].ToString();
                    l.EndTime = reader["EndTime"].ToString();
                    l.Month = reader["Month"].ToString();
                    l.Remark = reader["Remark"].ToString();
                    l.State = reader["State"].ToString();
                    le.Add(l);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return le;
        }
        /// <summary>
        /// 通过员工名字进行模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<U_Leave> H_selLeaveByName(string name)
        {
            List<U_Leave> le = new List<U_Leave>();
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@UserName",name)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "H_selLeaveByName", mySql);
                while (reader.Read())
                {
                    U_Leave l = new U_Leave();
                    l.LID = int.Parse(reader["LID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    l.UID = user;
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    l.DID = d;
                    l.LReason = reader["LReason"].ToString();
                    l.BeginTime = reader["BeginTime"].ToString();
                    l.EndTime = reader["EndTime"].ToString();
                    l.Month = reader["Month"].ToString();
                    l.Remark = reader["Remark"].ToString();
                    l.State = reader["State"].ToString();
                    le.Add(l);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return le;
        }
        /// <summary>
        /// 通过部门id查询请假信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<U_Leave> H_selLeaveByDID(int did)
        {
            List<U_Leave> le = new List<U_Leave>();
            try
            {
                string sql = "select a.*,b.UID,b.UserName,c.DID,c.DName from[dbo].[U_Leave] as a left join [dbo].[U_UserInfor] as b on a.UID=b.UID left join[dbo].[U_Department] as c on a.DID=c.DID where a.DID='"+did+ "' order by a.BeginTime desc";
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null);
                while (reader.Read())
                {
                    U_Leave l = new U_Leave();
                    l.LID = int.Parse(reader["LID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    l.UID = user;
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    l.DID = d;
                    l.LReason = reader["LReason"].ToString();
                    l.BeginTime = reader["BeginTime"].ToString();
                    l.EndTime = reader["EndTime"].ToString();
                    l.Month = reader["Month"].ToString();
                    l.Remark = reader["Remark"].ToString();
                    l.State = reader["State"].ToString();
                    le.Add(l);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return le;
        }
        /// <summary>
        /// 删除请假信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int H_DelLeaveInfo(int id)
        {
            try
            {
                string sql = "delete from [dbo].[U_Leave] where LID in ('"+id+"')";
                return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 查询所有辞职信息
        /// </summary>
        /// <returns></returns>
        public List<U_Resignation> H_selResignation()
        {
            List<U_Resignation> re = new List<U_Resignation>();
            try
            {
                string sql = "select a.RID,a.UID,a.DID,a.Reason,a.Time,a.Remark,b.UserName,b.DID,case when b.State=0 then '正常' else '停用'end as st ,c.* from [dbo].[U_ResignationInfo] as a left join [dbo].[U_UserInfor] as b on a.UID=b.UID left join [dbo].[U_Department] as c on a.DID=c.DID order by Time desc";
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null);
                while (reader.Read())
                {
                    U_Resignation r = new U_Resignation();
                    r.RID = int.Parse(reader["RID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.State = reader["st"].ToString();
                    //user.DID = int.Parse(reader["DID"].ToString());
                    r.UID = user;
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    r.DID = d;
                    r.Reason = reader["Reason"].ToString();
                    r.Time =DateTime.Parse(reader["Time"].ToString());
                    r.Remark = reader["Remark"].ToString();
                    r.State = reader["Remark"].ToString();
                    re.Add(r);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return re;
        }
        /// <summary>
        /// 停用用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int H_TYUser(int uid ,string state)
        {
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@UID",uid),
                    new SqlParameter ("@State",state)
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "H_TYuser", mySql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 根据用户ID模糊查询辞职信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_Resignation> H_SelReasontionByUID(int uid)
        {
            List<U_Resignation> re = new List<U_Resignation>();
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@UID",uid)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "H_SelResigntionByUid", mySql);
                while (reader.Read())
                {
                    U_Resignation r = new U_Resignation();
                    r.RID = int.Parse(reader["RID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.State = reader["st"].ToString();
                    //user.DID = int.Parse(reader["DID"].ToString());
                    r.UID = user;
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    r.DID = d;
                    r.Reason = reader["Reason"].ToString();
                    r.Time = DateTime.Parse(reader["Time"].ToString());
                    r.Remark = reader["Remark"].ToString();
                    r.State = reader["Remark"].ToString();
                    re.Add(r);
                }

            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return re;
        }
        /// <summary>
        /// 根据名字模糊查询辞职信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<U_Resignation> H_SelReasontionByName(string  name)
        {
            List<U_Resignation> re = new List<U_Resignation>();
            try
            {
                SqlParameter[] mySql = new SqlParameter[]
                {
                    new SqlParameter ("@UserName",name)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "H_SelResignationByName", mySql);
                while (reader.Read())
                {
                    U_Resignation r = new U_Resignation();
                    r.RID = int.Parse(reader["RID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.State = reader["st"].ToString();
                    //user.DID = int.Parse(reader["DID"].ToString());
                    r.UID = user;
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    r.DID = d;
                    r.Reason = reader["Reason"].ToString();
                    r.Time = DateTime.Parse(reader["Time"].ToString());
                    r.Remark = reader["Remark"].ToString();
                    r.State = reader["Remark"].ToString();
                    re.Add(r);
                }

            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return re;
        }
        /// <summary>
        /// 通过部门id查询信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<U_Resignation> H_SelReasontionByDID(int did)
        {
            List<U_Resignation> re = new List<U_Resignation>();
            try
            {
                string sql = "select a.RID,a.UID,a.DID,a.Reason,a.Time,a.Remark,b.UserName,b.DID,case when b.State=0 then '正常' else '停用'end as st ,c.* from [dbo].[U_ResignationInfo] as a left join [dbo].[U_UserInfor] as b on a.UID=b.UID left join [dbo].[U_Department] as c on a.DID=c.DID where c.DID='"+did+ "' order by Time desc";
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text,sql, null);
                while (reader.Read())
                {
                    U_Resignation r = new U_Resignation();
                    r.RID = int.Parse(reader["RID"].ToString());
                    U_User user = new U_User();
                    user.UID = int.Parse(reader["UID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.State = reader["st"].ToString();
                    //user.DID = int.Parse(reader["DID"].ToString());
                    r.UID = user;
                    U_Department d = new U_Department();
                    //d.DID = int.Parse(reader["DID"].ToString());
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    r.DID = d;
                    r.Reason = reader["Reason"].ToString();
                    r.Time = DateTime.Parse(reader["Time"].ToString());
                    r.Remark = reader["Remark"].ToString();
                    r.State = reader["Remark"].ToString();
                    re.Add(r);
                }

            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return re;
        }
        /// <summary>
        /// 删除所选辞职信息数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int H_DelResignations(int id)
        {
            try
            {
                String sql = "delete from [dbo].[U_ResignationInfo] where RID in('" + id + "')";
                return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 通过uid查询辞职信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable H_SelResignations(int uid)
        {
            DataTable  r = new DataTable ();
            try
            {
                string sql = "select * from U_ResignationInfo where UID='" + uid + "'";
                r = SqlHelper.ExecuteDataset(CommandType.Text, sql, null).Tables[0];
                //while (reader.Read())
                //{
                    
                //    r.RID = int.Parse(reader["RID"].ToString());
                //    U_User user = new U_User();
                //    user.UID = int.Parse(reader["UID"].ToString());
                //    user.UserName = reader["UserName"].ToString();
                //    user.State = reader["st"].ToString();
                //    //user.DID = int.Parse(reader["DID"].ToString());
                //    r.UID = user;
                //    U_Department d = new U_Department();
                //    d.DID = int.Parse(reader["DID"].ToString());
                //    d.DName = reader["DName"].ToString();
                //    r.DID = d;
                //    r.Reason = reader["Reason"].ToString();
                //    r.Time = DateTime.Parse(reader["Time"].ToString());
                //    r.Remark = reader["Remark"].ToString();
                //    r.State = reader["Remark"].ToString();

                //}
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return r;
        } 
    }

}
