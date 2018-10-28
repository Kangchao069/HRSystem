using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 薪资表
    /// </summary>
    public class M_Salary
    {
        /// <summary>
        /// id
        /// </summary>
        public int SID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public U_User UID { get; set; }
        /// <summary>
        /// 出勤ID
        /// </summary>
        public U_Attendance AID { get; set; }
        /// <summary>
        /// 工资ID
        /// </summary>
        public U_Post PID { get; set; }
        /// <summary>
        /// 基本工资
        /// </summary>
        public float BasicSalary { get; set; }
        /// <summary>
        /// 缺勤天数
        /// </summary>
        public int AbsenteeismDays { get; set; }
        /// <summary>
        /// 奖金
        /// </summary>
        public float Bonus { get; set; }
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
