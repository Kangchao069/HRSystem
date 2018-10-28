using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.admin
{
    public partial class M_UpdateBasicWages1 : System.Web.UI.Page
    {
        U_User use = new U_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((U_User)Session["U_USER"] == null)
                {
                    Response.Redirect("../M_UserLogin.aspx");
                }
                BindData();
            }
        }
        /// <summary>
        /// 页面赋值
        /// </summary>
        public void BindData() {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            // int PID=Convert.ToInt32( Server.UrlDecode(Request.QueryString["PID"]));

            U_Post up = new ManageBll().getPostInfo(PID);
            this.lblPName.Text = up.PName;
            this.txtSalary.Text = up.Salary;
        }
        /// <summary>
        /// 修改基本薪资
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSure_Click(object sender, EventArgs e)
        {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);

            U_Post info = new U_Post();
            info.Salary = this.txtSalary.Text.Trim();

            if (new ManageBll().updateBasicSalary(PID,info)>0)
            {
                Common.JsMessage.jsAlert("修改成功！");
                use = (U_User)Session["U_USER"];
                Model.M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "修改员工基本工资！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
            }
            else
            {
                Common.JsMessage.jsAlert("修改失败！");
            }
        }
    }
}