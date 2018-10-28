using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 职务
    /// </summary>
    public class U_Post
    {
        /// <summary>
        /// id
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 职务名
        /// </summary>
        public string PName { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 薪水
        /// </summary>
        public string Salary { get; set; }
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
