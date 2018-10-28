using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class U_TaskPageDetail : System.Web.UI.Page
    {
        U_User use = new U_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                use = (U_User)Session["U_USER"];
                if ((U_User)Session["U_USER"] == null)
                {
                    Response.Redirect("M_UserLogin.aspx");
                }
                ///查询 需提供tid
                int u = int.Parse(Request.QueryString["TID"]);
                BindInfo(u);
            }
        }
        /// <summary>
        /// 获取任务信息
        /// </summary>
        public void BindInfo(int u) {

            //int u = Convert.ToInt32(Request.QueryString["DID"]);
            
            DataTable dt = new ManageBll().selectDetailTaskInfo(u);
            this.lblTitle.Text = dt.Rows[0]["TaskName"].ToString();
             this.lblAuthor.Text = "发布部门：" + dt.Rows[0]["DName"].ToString();
            this.txtContent.Text = dt.Rows[0]["Content"].ToString();
            this.lblReleaseTime.Text = "发布时间" + dt.Rows[0]["ReleaseTime"].ToString();
        }
    }
}