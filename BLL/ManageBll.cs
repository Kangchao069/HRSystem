using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class ManageBll
    {
        ManageDal md = new ManageDal();
        /// <summary>
        /// 查询任务信息
        /// </summary>
        /// <returns></returns>
        public List<M_TaskInfo> SelTaskInfo()
        {
            return md.SelTaskInfo();
        }
        /// <summary>
        /// 查询任务详细信息
        /// </summary>
        /// <returns></returns>
        public M_TaskInfo SelTaskInfox(int tid)
        {
            return md.SelTaskInfox(tid);
        }
        /// <summary>
        /// 发布任务信息
        /// </summary>
        /// <param name="ti"></param>
        /// <returns></returns>
        public int AddTaskInfo(M_TaskInfo ti)
        {
            return md.AddTaskInfo(ti);
        }
        /// <summary>
        /// 查询日志信息
        /// </summary>
        /// <returns></returns>
        public List<M_JournalInfo> SelJournal()
        {
            return md.SelJournal();
        }
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelJournal(int id)
        {
            return md.DelJournal(id);
        }
        /// <summary>
        /// 根据名字模糊查询日志
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<M_JournalInfo> selJournalInfoByName(string name)
        {
            return md.selJournalInfoByName(name);
        }
        /// <summary>
        /// 根据时间查询日志
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<M_JournalInfo> selJournalInfoByTimes(string time)
        {
            return md.selJournalInfoByTimes(time);
        }
        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="jid"></param>
        /// <returns></returns>
        public int M_DelJournals(int jid)
        {
            return md.M_DelJournals(jid);
        }
        /// <summary>
        /// 批量删除任务
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int M_DelTasks(int  tid)
        {
            return md.M_DelTasks(tid);
        }
        /// <summary>
        /// 通过DID查询任务信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<M_TaskInfo> M_SelTaskByDID(int did)
        {
            return md.M_SelTaskByDID(did);
        }
        /// <summary>
        /// 修改任务信息
        /// </summary>
        /// <param name="ta"></param>
        /// <returns></returns>
        public int M_UpdTaskInfos(M_TaskInfo ta)
        {
            return md.M_UpdTaskInfos(ta);
        }
        /// <summary>
        /// 通过用户类型获取菜单栏
        /// </summary>
        /// <param name="utid"></param>
        /// <returns></returns>
        public DataTable GetLeftMeauByUTID(int utid)
        {
            return md.GetLeftMeauByUTID(utid);
        }
        /// <summary>
        /// 绑定用户考勤信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserAttendInfo(int uid)
        {
            return md.getUserAttendInfo(uid);
        }
        /// <summary>
        /// 绑定用户请假信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable getUserLeaveInfo(int uid)
        {
            return md.getUserLeaveInfo(uid);
        }
        /// <summary>
        /// 绑定任务标题信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable getUserTaskInfo(int did)
        {
            return md.getUserTaskInfo(did);
        }
        /// <summary>
        /// 获取详细任务内容
        /// </summary>
        /// <returns></returns>
        public DataTable selectDetailTaskInfo(int did)
        {
            return md.selectDetailTaskInfo(did);
        }
        /// <summary>
        /// 工资查询
        /// </summary>
        /// <returns></returns>
        public DataTable getUserSalary()
        {
            return md.getUserSalary();
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable getDepartment()
        {
            return md.getDepartment();
        }
        /// <summary>
        /// 按部门查询员工工资
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public DataTable getUserSalaryInfoByDID(int did)
        {
            return md.getUserSalaryInfoByDID(did);
        }
        /// <summary>
        /// 按姓名查询员工工资
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public DataTable getUserSalaryInfoByUserName(string UserName)
        {
            return md.getUserSalaryInfoByUserName(UserName);
        }
        /// <summary>
        /// 绑定一级repiter信息
        /// </summary>
        /// <returns></returns>
        public DataTable BindPageName()
        {
            return md.BindPageName();
        }
        /// <summary>
        /// 绑定二级repiter信息
        /// </summary>
        /// <returns></returns>
        public DataTable BindTwoPageName(int pid)
        {
            return md.BindTwoPageName(pid);
        }
        /// <summary>
        /// 根据管理员类型删除页面权限信息
        /// </summary>
        /// <returns></returns>
        public int DeletePageManageInfoByMTID(int MTID)
        {
            return md.DeletePageManageInfoByMTID(MTID);
        }
        /// <summary>
        /// 根据页面PID和类型MTID向数据库插入一条信息
        /// </summary>
        /// <param name="pm"></param>
        public void AddPageManageInfoByPIDMTID(int mtid, int pid)
        {
            md.AddPageManageInfoByPIDMTID(mtid, pid);
        }
        /// <summary>
        /// 查询原始密码
        /// </summary>
        /// <returns></returns>
        public DataTable selectbeginPwd(int uid, string pwd)
        {
            return md.selectbeginPwd(uid, pwd);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="upid"></param>
        /// <param name="zhi"></param>
        /// <returns></returns>
        public int updatePasswordByUID(int uid, string pwd)
        {
            return md.updatePasswordByUID(uid, pwd);
        }
        /// <summary>
        /// 获取薪资明细
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="month"></param>
        /// <returns></returns>

        public DataTable getSalaryInfo(int uid, string month)
        {
            return md.getSalaryInfo(uid, month);
        }
        /// <summary>
        /// 获取基本工资明细
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable getBasicWages()
        {
            return md.getBasicWages();
        }
        /// <summary>
        /// 获取基本工资去赋值
        /// </summary>
        /// <param name="upid"></param>
        /// <returns></returns>
        public U_Post getPostInfo(int Pid)
        {
            return md.getPostInfo(Pid);
        }
        /// <summary>
        /// 修改基本薪资
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int updateBasicSalary(int pid, U_Post info)
        {
            return md.updateBasicSalary(pid, info);
        }
        public List<M_Permission> getCheckState(int UTID)
        {
            return md.getCheckState(UTID);
        }
        /// <summary>
        /// 查询用户类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetManageType()
        {
            return md.GetManageType();
        }
    }
}
