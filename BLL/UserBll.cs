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
    public class UserBll
    {
        UserDal ud = new UserDal();//实例化dal
        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <returns></returns>
        public DataTable selUserTypeInfor()
        {
            return ud.selUserTypeInfor();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="us"></param>
        public U_User GetInfoByNameAndPswAndType(string name, string psw, int utid)
        {
            return ud.GetInfoByNameAndPswAndType(name,psw,utid);
        }
        /// <summary>
        /// 系统日志
        /// </summary>
        /// <param name="ji"></param>
        public void AddJournalInfo(M_JournalInfo ji)
        {
            ud.AddJournalInfo(ji);
        }
        /// <summary>
        /// 用户查询个人信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public U_User selAllUserInfoByID(int uid)
        {
            return ud.selAllUserInfoByID(uid);
        }
        /// <summary>
        /// 查询用户学历信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelEductaionInfo()
        {
            return ud.SelEductaionInfo();
        }
        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public int UpdUserInfor(U_User us)
        {
            return ud.UpdUserInfor(us);
        }
        /// <summary>
        /// 查询用户部门
        /// </summary>
        /// <returns></returns>
        public DataTable U_SelDepartment()
        {
            return ud.U_SelDepartment();
        }
        /// <summary>
        /// 查询用户所有信息
        /// </summary>
        /// <returns></returns>
        public List<U_User> U_SelAllUserInfo()
        {
            return ud.U_SelAllUserInfo();
        }
        /// <summary>
        /// 通过用户ID模糊查询用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_User> U_SelAllUserInfoByIDs(int uid)
        {
            return ud.U_SelAllUserInfoByIDs(uid);
        }
        /// <summary>
        /// 通过用户名模糊查询用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_User> U_SelAllUserInfoByNames(string name)
        {
            return ud.U_SelAllUserInfoByNames(name);
        }
        /// <summary>
        /// 通过部门查询用户数据
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_User> U_selAllUserInfoByDID(int did)
        {
            return ud.U_selAllUserInfoByDID(did);
        }
        /// <summary>
        /// 查询用户职位信息
        /// </summary>
        /// <returns></returns>
        public DataTable U_SelUserPostInfo()
        {
            return ud.U_SelUserPostInfo();
        }
        /// <summary>
        /// 添加请假信息
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int AddUserLeave(U_Leave l)
        {
            return ud.AddUserLeave(l);
        }
        /// <summary>
        /// 添加辞职信息
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        public int U_AddResigntion(U_Resignation re)
        {
            return ud.U_AddResigntion(re);
        }
    }
}
