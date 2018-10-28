using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public class U_UserType
    {
        /// <summary>
        /// id
        /// </summary>
        public int UTID { get; set; }
        /// <summary>
        /// 用户类型名
        /// </summary>
        public string TypeName { get; set; }
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
