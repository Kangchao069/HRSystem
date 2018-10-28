using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class M_JournalInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int JID { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
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
