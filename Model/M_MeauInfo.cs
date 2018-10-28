using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class M_MeauInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int MID { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public string MeauName { get; set; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// 菜单级别
        /// </summary>
        public int ParentID { get; set; }
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
