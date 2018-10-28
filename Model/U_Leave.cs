using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 请假表
    /// </summary>
    public class U_Leave
    {
        /// <summary>
        /// id
        /// </summary>
        public int LID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public U_User UID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public U_Department DID { get; set; }
        /// <summary>
        /// 原因
        /// </summary>

        public string LReason { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public string Month { get; set; }

    }
}
