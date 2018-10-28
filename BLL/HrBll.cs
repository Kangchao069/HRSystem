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
   public  class HrBll
    {
        HrDal hd = new HrDal();
        /// <summary>
        /// 修改用户的职位和部门
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int H_UpdUserInfoByPidAndDid(U_User user)
        {
            return hd.H_UpdUserInfoByPidAndDid(user);
        }
        /// <summary>
        /// 通过用户ID删除用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int H_DelUserInfoByUID(int uid)
        {
            return hd.H_DelUserInfoByUID(uid);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public int AddUsers(U_User us)
        {
            return hd.AddUsers(us);
        }
        /// <summary>
        /// 查询所有请假信息
        /// </summary>
        /// <returns></returns>
        public List<U_Leave> H_selLeave()
        {
            return hd.H_selLeave();
        }
        /// <summary>
        /// 通过员工编号模糊查询请假信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_Leave> H_selLeaveByUid(int uid)
        {
            return hd.H_selLeaveByUid(uid);
        }
        /// <summary>
        /// 通过员工名字进行模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<U_Leave> H_selLeaveByName(string name)
        {
            return hd.H_selLeaveByName(name);
        }
        /// <summary>
        /// 通过部门id查询请假信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<U_Leave> H_selLeaveByDID(int did)
        {
            return hd.H_selLeaveByDID(did);
        }
        /// <summary>
        /// 删除请假信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int H_DelLeaveInfo(int id)
        {
            return hd.H_DelLeaveInfo(id);
        }
        /// <summary>
        /// 查询所有辞职信息
        /// </summary>
        /// <returns></returns>
        public List<U_Resignation> H_selResignation()
        {
            return hd.H_selResignation();
        }
        /// <summary>
        /// 停用用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int H_TYUser(int uid, string state)
        {
            return hd.H_TYUser(uid,state);
        }
        /// <summary>
        /// 根据用户ID模糊查询辞职信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<U_Resignation> H_SelReasontionByUID(int uid)
        {
            return hd.H_SelReasontionByUID(uid);
        }
        /// <summary>
        /// 根据名字模糊查询辞职信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<U_Resignation> H_SelReasontionByName(string name)
        {
            return hd.H_SelReasontionByName(name);
        }
        /// <summary>
        /// 通过部门id查询信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<U_Resignation> H_SelReasontionByDID(int did)
        {
            return hd.H_SelReasontionByDID(did);
        }
        /// <summary>
        /// 删除所选辞职信息数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int H_DelResignations(int id)
        {
            return hd.H_DelResignations(id);
        }
        /// <summary>
        /// 通过uid查询辞职信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable H_SelResignations(int uid)
        {
            return hd.H_SelResignations(uid);
        }
    }
}
