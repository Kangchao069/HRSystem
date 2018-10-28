using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class U_User
    {
        /// <summary>
        /// id
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户类型ID
        /// </summary>
        public U_UserType UTID { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 详细
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// 职务ID
        /// </summary>
        public U_Post PID { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public U_Department DID { get; set; }
        /// <summary>
        /// 学历ID
        /// </summary>
        public U_EducationInfo EID { get; set; }
        /// <summary>
        /// 院校
        /// </summary>
        public string Academy { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

    }
}
