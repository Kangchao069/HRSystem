using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class Index : System.Web.UI.Page
    {
        U_User use = new U_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                use = (U_User)Session["U_USER"];
                if ((U_User)Session["U_USER"]==null)
                {
                    Response.Redirect("M_UserLogin.aspx");
                }
                string time= DateTime.Now.ToString();
                string week= DateTime.Now.DayOfWeek.ToString();
                this.lblTime.InnerText = time;
                this.lblWeek.InnerText = week;
                int utid = use.UTID.UTID;
                this.lblUserName.Text = use.UserName; 
                this.literal.Text = this.BindLtr(utid);
            }
        }
        /// <summary>
        /// 用于绑定左侧菜单栏
        /// </summary>
        public string BindLtr(int utid) {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new ManageBll().GetLeftMeauByUTID(utid);
            //获得一级菜单
            DataRow[] first = dt.Select("ParentID=0");
            sb.Append("<ul id='oneUl'>");
            for (int i = 0; i < first.Length; i++)
            {
                sb.Append("<li onclick='changeDiv(this);'  id='li" + first[i]["MID"] + "'>" + "<img src=\"lujing\" width='15px' height='15px' > &nbsp;" + first[i]["MenuName"]);

                //绑定二级菜单
                DataRow[] two = dt.Select("ParentID=" + first[i]["MID"]);
                sb.Append("<ul  onclick='changeDiv2(this);' style='display:none;' id='ul" + first[i]["MID"] + "'>");
                for (int j = 0; j < two.Length; j++)
                {
                    sb.Append("<a  href='" + two[j]["WebUrl"] + "' target=\"iframe\"><li>" + two[j]["MenuName"]);
                    sb.Append("</li></a>");
                }
                sb.Append("</ul></li>");
            }
            sb.Append("</ul>");

            return sb.ToString();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLoginOut_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('退出成功！');location='../login.aspx';", true);
            //删除session及from身份验证票证
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }
}