using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    /// <summary>
    /// 学历信息表
    /// </summary>
    public class U_EducationInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int EID { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }
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
