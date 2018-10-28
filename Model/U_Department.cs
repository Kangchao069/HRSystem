using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class U_Department
    {
        /// <summary>
        /// id
        /// </summary>
        public int DID { get; set; }
        /// <summary>
        /// 部门名
        /// </summary>
        public string DName { get; set; }
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
