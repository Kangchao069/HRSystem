using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Users
{
    public partial class U_UserLeaveAdd : System.Web.UI.Page
    {
        U_User use = new U_User();
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                if ((U_User)Session["U_USER"] == null)
                {
                    Response.Redirect("../M_UserLogin.aspx");
                }
                bind();
            }
        }
        /// <summary>
        /// 位部门类型赋值
        /// </summary>
        public void bind()
        {
            use = (U_User)Session["U_USER"];
            this.LbUserName.Text = use.UserName;
            this.LbDid.Text = use.DID.DName.ToString();
            //this.DdlDepartment.DataSource = new UserBll().U_SelDepartment();
            //this.DdlDepartment.DataTextField = "DName";
            //this.DdlDepartment.DataValueField = "DID";
            //this.DdlDepartment.DataBind();
        }
        /// <summary>
        /// 编辑请假信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmission_Click(object sender, EventArgs e)
        {
            use = (U_User)Session["U_USER"];
            int i = use.UID;
            int dp = use.DID.DID;
            U_Leave le = new U_Leave();
            U_User u = new U_User();
            u.UID = i;
            le.UID = u;
            U_Department d = new U_Department();
            d.DID = dp;
            le.DID = d;
            le.LReason = this.TbReason.Text.Trim();
            le.BeginTime = this.TbAoginTime.Text.Trim();
            le.EndTime = this.TbEndTime.Text.Trim();
            le.Remark = this.TbRemark.Text.Trim();
            if (string.IsNullOrEmpty(this.TbReason.Text)||string.IsNullOrEmpty(TbAoginTime.Text)||string.IsNullOrEmpty(this.TbEndTime.Text)||string.IsNullOrEmpty(this.TbRemark.Text))
            {
                JsMessage.jsAlert("请假信息不能为空，请填写完整！");
                return;
            }
            if (new UserBll().AddUserLeave(le)>0)
            {
                JsMessage.jsAlert("添加成功！");
               
            }
            this.TbReason.Text = "";
            this.TbAoginTime.Text = "";
            this.TbEndTime.Text = "";
            this.TbRemark.Text = "";
        }
        /// <summary>
        /// 重置请假信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnClous_Click(object sender, EventArgs e)
        {
            this.TbReason.Text = "";
            this.TbAoginTime.Text = "";
            this.TbEndTime.Text = "";
            this.TbRemark.Text = "";
        }
    }
}