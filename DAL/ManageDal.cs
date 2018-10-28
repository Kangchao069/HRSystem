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
   public  class ManageDal
    {
        /// <summary>
        /// 查询任务信息
        /// </summary>
        /// <returns></returns>
        public List<M_TaskInfo> SelTaskInfo()
        {
            List<M_TaskInfo> mts = new List<M_TaskInfo>();
            
            try
            {
                string sql = "select * from M_TaskInfo as a left join [dbo].[U_Department] as b on a.DID=b.DID order by ReleaseTime desc";
                //SqlParameter[] sql = new SqlParameter[] {

                //};
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text,sql, null);
                while (reader.Read())
                {
                    M_TaskInfo ti = new M_TaskInfo();
                    ti.TID = string.IsNullOrEmpty(reader["TID"].ToString()) ? 0 : (int)reader["TID"];
                    ti.TaskName = reader["TaskName"].ToString();
                    U_Department de = new U_Department();
                    de.DID = int.Parse(reader["DID"].ToString());
                    de.DName = reader["DName"].ToString();
                    ti.DID =de;
                    ti.ReleaseTime =(DateTime)reader["ReleaseTime"];
                    ti.Remark = reader["Remark"].ToString();
                    ti.State = reader["State"].ToString();
                    ti.Content = reader["Content"].ToString();
                    mts.Add(ti);
                }
            }
            catch (Exception ex)
            {

                Common.JsMessage.jsAlert(ex.Message);
            }
            return mts;
        }
        /// <summary>
        /// 查询任务详细信息
        /// </summary>
        /// <returns></returns>
        public M_TaskInfo SelTaskInfox( int tid)
        {
            
            M_TaskInfo ti = new M_TaskInfo();
            try
            {
                SqlParameter[] sql = new SqlParameter[] {
                    new SqlParameter ("@TID",tid)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "[dbo].[M_SelTaskInfo]", sql);
                while (reader.Read())
                {
                    ti.TID = int.Parse(reader["TID"].ToString());
                    ti.TaskName = reader["TaskName"].ToString();
                    U_Department d = new U_Department();
                    d.DID = int.Parse(reader["DID"].ToString());
                    d.DName = reader["DName"].ToString();
                    ti.DID = d;
                    ti.ReleaseTime =(DateTime) reader["ReleaseTime"];
                    ti.Remark = reader["Remark"].ToString();
                    ti.State = reader["State"].ToString();
                    ti.Content = reader["Content"].ToString();               
                }
            }
            catch (Exception ex)
            {

                Common.JsMessage.jsAlert(ex.Message);
            }
            return ti;
        }
        /// <summary>
        /// 发布任务信息
        /// </summary>
        /// <param name="ti"></param>
        /// <returns></returns>
        public int AddTaskInfo(M_TaskInfo ti)
        {
           
            try
            {
                SqlParameter[] mysql = new SqlParameter[]
                        {
                   new SqlParameter ("@TaskName",ti.TaskName),
                   new SqlParameter ("@ReleaseTime",ti.ReleaseTime),
                   new SqlParameter ("@DID",ti.DID.DID),
                   new SqlParameter ("@Content",ti.Content),
                   new SqlParameter ("@Remark",ti.Remark)
                        };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "M_TaskInfoAdd", mysql);
            }
            catch (Exception)
            {

                throw;
            
            }

        }
        /// <summary>
        /// 查询日志信息
        /// </summary>
        /// <returns></returns>
        public List<M_JournalInfo> SelJournal()
        {
            List<M_JournalInfo> mj = new List<M_JournalInfo>();
            string sql = "select * from M_JournalInfo order by ReleaseTime desc";
            SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text,sql, null);
            while (reader.Read())
            {
                M_JournalInfo j = new M_JournalInfo();
                j.LoginName = reader["LoginName"].ToString();
                j.ReleaseTime = (DateTime)reader["ReleaseTime"];
                j.Content = reader["Content"].ToString();
                j.JID = int.Parse(reader["JID"].ToString());
                j.Remark = reader["Remark"].ToString();
                j.State = reader["State"].ToString();
                mj.Add(j);
            }
            return mj;
        }
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelJournal(int id)
        {
            try
            {
                string sql = "delete from [dbo].[M_JournalInfo] where JID=" + id;
                return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 根据名字模糊查询日志
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<M_JournalInfo> selJournalInfoByName(string name)
        {
            List<M_JournalInfo> mj = new List<M_JournalInfo>();
            try
            {
                SqlParameter[] mysql = new SqlParameter[]
                {
                    new SqlParameter ("@LoginName",name)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "selJournalByName", mysql);
                while (reader.Read())
                {
                    M_JournalInfo j = new M_JournalInfo();
                    j.LoginName = reader["LoginName"].ToString();
                    j.ReleaseTime = (DateTime)reader["ReleaseTime"];
                    j.Content = reader["Content"].ToString();
                    j.JID = int.Parse(reader["JID"].ToString());
                    j.Remark = reader["Remark"].ToString();
                    j.State = reader["State"].ToString();
                    mj.Add(j);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return mj;
        }
        /// <summary>
        /// 根据时间查询日志
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<M_JournalInfo> selJournalInfoByTimes(string time)
        {
            List<M_JournalInfo> mj = new List<M_JournalInfo>();
            try
            {
                //string sql = "select * from [dbo].[M_JournalInfo] where ReleaseTime='"+time+ "' order by ReleaseTime";
                SqlParameter[] mysql = new SqlParameter[]
                {
                    new SqlParameter ("@ReleaseTime",time)
                };
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, "selJournalByTime", mysql);
                while (reader.Read())
                {
                    M_JournalInfo j = new M_JournalInfo();
                    j.LoginName = reader["LoginName"].ToString();
                    j.ReleaseTime = (DateTime)reader["ReleaseTime"];
                    j.Content = reader["Content"].ToString();
                    j.JID = int.Parse(reader["JID"].ToString());
                    j.Remark = reader["Remark"].ToString();
                    j.State = reader["State"].ToString();
                    mj.Add(j);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return mj;
        }
        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="jid"></param>
        /// <returns></returns>
        public int M_DelJournals(int jid)
        {
            try
            {
                string sql = "delete from [dbo].[M_JournalInfo] where JID in ('"+jid+"')";
                return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 批量删除任务
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int M_DelTasks(int  tid)
        {
            try
            {
                string sql = "delete from [dbo].[M_TaskInfo] where TID in ('" + tid + "')";
                return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 通过DID查询任务信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<M_TaskInfo> M_SelTaskByDID(int did)
        {
            List<M_TaskInfo> ta = new List<M_TaskInfo>();
            try
            {
                string sql = "select * from M_TaskInfo as a left join [dbo].[U_Department] as b on a.DID=b.DID where a.DID='" + did + "' order by ReleaseTime desc";
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null);
                while (reader.Read())
                {
                    M_TaskInfo ti = new M_TaskInfo();
                    ti.TID = string.IsNullOrEmpty(reader["TID"].ToString()) ? 0 : (int)reader["TID"];
                    ti.TaskName = reader["TaskName"].ToString();
                    U_Department de = new U_Department();
                    de.DID = int.Parse(reader["DID"].ToString());
                    de.DName = reader["DName"].ToString();
                    ti.DID = de;
                    ti.ReleaseTime = (DateTime)reader["ReleaseTime"];
                    ti.Remark = reader["Remark"].ToString();
                    ti.State = reader["State"].ToString();
                    ti.Content = reader["Content"].ToString();
                    ta.Add(ti);
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return ta;
        }
        /// <summary>
        /// 修改任务信息
        /// </summary>
        /// <param name="ta"></param>
        /// <returns></returns>
        public int M_UpdTaskInfos(M_TaskInfo ta)
        {
            try
            {
                SqlParameter[] mysql = new SqlParameter[]
                {
                    new SqlParameter ("@TID",ta.TID),
                    new SqlParameter ("@TaskName",ta.TaskName),
                    new SqlParameter ("@ReleaseTime",ta.ReleaseTime),
                    new SqlParameter ("@Content",ta.Content),
                    new SqlParameter ("@DID",ta.DID.DID),
                    new SqlParameter ("@Remark",ta.Remark)
                };
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "M_UpdTaskInfo", mysql);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 通过用户类型获取菜单栏
        /// </summary>
        /// <param name="utid"></param>
        /// <returns></returns>
        public DataTable GetLeftMeauByUTID(int utid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@UTID",utid)
                };
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "M_Permission_selectAll", para).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        /// <summary>
        /// 绑定用户考勤信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserAttendInfo(int uid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@UID",uid)
                };
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "U_Attendance_selectUserInfo", para).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        /// <summary>
        /// 绑定用户请假信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable getUserLeaveInfo(int uid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@UID",uid)
                };
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "U_Leave_selectLeaveInfo", para).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        /// <summary>
        /// 绑定任务标题信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable getUserTaskInfo(int did)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                    new SqlParameter("@DID",did)
                };
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "M_TaskInfo_selectTaskInfo", para).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        /// <summary>
        /// 获取详细任务内容
        /// </summary>
        /// <returns></returns>
        public DataTable selectDetailTaskInfo(int did)
        {
            DataTable dt = new DataTable();
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@TID",did)
            };
            try
            {
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "M_TaskInfo_selectDetailTaskInfo", para).Tables[0];
            }
            catch (Exception ex)
            {
                Common.JsMessage.jsAlert(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 工资查询
        /// </summary>
        /// <returns></returns>
        public DataTable getUserSalary()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "View_SalaryInfo_SelectAll").Tables[0];
            }
            catch (Exception ex)
            {
                Common.JsMessage.jsAlert(ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable getDepartment()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select DID,DName from U_Department";
                dt = SqlHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
            }
            catch (Exception ex)
            {
                Common.JsMessage.jsAlert(ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// 按部门查询员工工资
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public DataTable getUserSalaryInfoByDID(int did)
        {
            DataTable dt = new DataTable();
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@DID",did)

            };
            try
            {
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "View_SalaryInfo_SelectAllByDID", para).Tables[0];
            }
            catch (Exception ex)
            {
                Common.JsMessage.jsAlert(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 按姓名查询员工工资
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public DataTable getUserSalaryInfoByUserName(string UserName)
        {
            DataTable dt = new DataTable();
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@UserName",UserName)

            };
            try
            {
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "View_SalaryInfo_SelectAllByUserName", para).Tables[0];
            }
            catch (Exception ex)
            {
                Common.JsMessage.jsAlert(ex.Message);
            }
            return dt;
        }
        /// <summary>
        /// 绑定一级repiter信息
        /// </summary>
        /// <returns></returns>
        public DataTable BindPageName()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "[dbo].[M_MenuInfo_selectPageName]", null).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        /// <summary>
        /// 绑定二级repiter信息
        /// </summary>
        /// <returns></returns>
        public DataTable BindTwoPageName(int pid)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] mySql = new SqlParameter[] {
                    new SqlParameter("@PID",pid),
                };
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "[dbo].[M_MenuInfo_selectTwoPageName]", mySql).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        /// <summary>
        /// 根据管理员类型删除页面权限信息
        /// </summary>
        /// <returns></returns>
        public int DeletePageManageInfoByMTID(int MTID)
        {

            int result = 0;
            try
            {
                SqlParameter[] para = new SqlParameter[]
                        {
                   new SqlParameter("@UTID",MTID)
                        };

                result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "M_Permission_DeletePageByMTID", para);

            }
            catch (Exception ex)
            {

                Common.JsMessage.jsAlert(ex.Message);
            }

            return result;
        }
        /// <summary>
        /// 根据页面PID和类型MTID向数据库插入一条信息
        /// </summary>
        /// <param name="pm"></param>
        public void AddPageManageInfoByPIDMTID(int mtid, int pid)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[]
                    {
                        new SqlParameter("@MID",pid),
                        new SqlParameter("@UTID",mtid)
                    };
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "M_Permission_AddPageByPIDAndMTID", para);
            }
            catch (Exception ex)
            {
                Common.JsMessage.jsAlert(ex.Message);
            }
        }
        /// <summary>
        /// 查询原始密码
        /// </summary>
        /// <returns></returns>
        public DataTable selectbeginPwd(int uid, string pwd)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[] {

                    new SqlParameter("@UID",uid),
                    new SqlParameter("@Password",pwd)
                };
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "U_UserInfor_selectbeginPwd", para).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="upid"></param>
        /// <param name="zhi"></param>
        /// <returns></returns>
        public int updatePasswordByUID(int uid, string pwd)
        {

            int result = 0;
            try
            {
                SqlParameter[] para = new SqlParameter[]
                        {
                   new SqlParameter("@UID",uid),
                   new SqlParameter("@Password",pwd)
                        };

                result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "U_UserInfor_updatePasswordByUID", para);

            }
            catch (Exception ex)
            {

                Common.JsMessage.jsAlert(ex.Message);
            }

            return result;
        }
        /// <summary>
        /// 获取薪资明细
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable getSalaryInfo(int uid, string month)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[] {

                    new SqlParameter("@UID",uid),
                    new SqlParameter("@Month",month)
                };
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "M_Salary_selectDetailInfo", para).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        /// <summary>
        /// 获取基本工资明细
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable getBasicWages()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select PID,PName,Salary from U_Post";
                dt = SqlHelper.ExecuteDataset(CommandType.Text, sql, null).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        /// <summary>
        /// 获取基本工资去赋值
        /// </summary>
        /// <param name="upid"></param>
        /// <returns></returns>
        public U_Post getPostInfo(int Pid)
        {
            U_Post u = new U_Post();
            try
            {
                SqlParameter[] mySql = new SqlParameter[] {
                 new SqlParameter("@PID",Pid),
                };
                SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "U_Post_selectPostInfo", mySql);

                while (sdr.Read())
                {
                    u.PID = (int)sdr["PID"];
                    u.PName = sdr["PName"].ToString();
                    u.Salary = sdr["Salary"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return u;
        }

        /// <summary>
        /// 修改基本薪资
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int updateBasicSalary(int pid, U_Post info)
        {
            int result = 0;
            try
            {
                SqlParameter[] para = new SqlParameter[]
                        {
                   new SqlParameter("@PID",pid),
                   new SqlParameter("@Salary",info.Salary),
                        };

                result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "U_Post_updateBasicSalary", para);

            }
            catch (Exception ex)
            {

                Common.JsMessage.jsAlert(ex.Message);
            }

            return result;
        }


        public List<M_Permission> getCheckState(int UTID)
        {
            List<M_Permission> d = new List<M_Permission>();
            try
            {
                string sql = "select MID,UTID from M_Permission  where UTID=" + UTID + "";
                SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, null);
                while (reader.Read())
                {
                    M_Permission mp = new M_Permission();
                    //mp.PID = (int)reader["PID"];
                    U_UserType ut = new U_UserType();
                    ut.UTID = (int)reader["UTID"];
                    mp.UTID = ut;
                    M_MeauInfo mm = new M_MeauInfo();
                    mm.MID = (int)reader["MID"];
                    mp.MID = mm;
                    d.Add(mp);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return d;
        }
        /// <summary>
        /// 查询用户类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetManageType()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from [dbo].[U_UserType]";
                dt = SqlHelper.ExecuteDataset(CommandType.Text, sql, null).Tables[0];
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            return dt;
        }
    }
}
