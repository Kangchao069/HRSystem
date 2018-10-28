using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 辞职表
    /// </summary>
    public class U_Resignation
    {
        /// <summary>
        /// id
        /// </summary>
        public int RID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public U_User UID { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public U_Department DID { get; set; }
        /// <summary>
        /// 辞职时间
        /// </summary>
        public DateTime Time { get; set; }
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
