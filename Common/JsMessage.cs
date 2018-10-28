using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class JsMessage
    {
        /// <summary>
        /// 弹出对话框
        /// </summary>
        public static void jsAlert(string zhi)
        {
            HttpContext.Current.Response.Write("<script>alert('" + zhi + "');</script>");

        }
    }
}
