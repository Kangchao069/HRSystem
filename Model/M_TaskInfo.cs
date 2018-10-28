using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 任务信息表
    /// </summary>
    public class M_TaskInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int TID { get; set; }
        /// <summary>
        /// 任务名
        /// </summary>
        public string TaskName { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }
        /// <summary>
        /// 发布内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public U_Department DID { get; set; }
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
