using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 权限分配
    /// </summary>
   public class M_Permission
    {
        /// <summary>
        /// id
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 用户类型ID
        /// </summary>
        public U_UserType UTID { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public M_MeauInfo MID { get; set; }
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
