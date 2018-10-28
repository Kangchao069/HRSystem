using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 出勤表
    /// </summary>
    public class U_Attendance
    {
        /// <summary>
        /// id
        /// </summary>
        public int AID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public U_User UID { get; set; }
        /// <summary>
        /// 出勤天数
        /// </summary>
        public int AttendDays { get; set; }
        /// <summary>
        /// 加班天数
        /// </summary>
        public int OverTimeDays { get; set; }
        /// <summary>
        /// 奖金
        /// </summary>
        public float Bonus { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public string Month { get; set; }
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
