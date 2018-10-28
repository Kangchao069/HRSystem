using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.admin
{
    public partial class M_SelUserInfoInformation : System.Web.UI.Page
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
                bind();
            }
        }
        public void bind()
        {
            int I = int.Parse(Request.QueryString["UID"]);
            U_User us = new UserBll().selAllUserInfoByID(I);
            this.LbNumber.Text = us.UID.ToString();
            this.LbName.Text = us.UserName;
            this.LbIDCard.Text = us.IDCard;
            U_Post p = new U_Post();
            this.LbPost.Text = us.PID.PName;
            this.LbUserType.Text = us.UTID.TypeName;
            this.LbDepartment.Text = us.DID.DName;
            this.LbPhone.Text = us.Phone;
            this.LbEducation.Text = us.EID.Education;
            this.LbAcademy.Text = us.Academy;
            this.LbSex.Text = us.Sex;
            this.LbDetails.Text = us.Details;
            this.LbEmail.Text = us.Email;
            this.LbAddress.Text = us.Address;
            this.LbRemake.Text = us.Remark;
            this.lbstate.Text = us.State;


        }
        /// <summary>
        /// 停用用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpdState_Click(object sender, EventArgs e)
        {
            int I = int.Parse(Request.QueryString["UID"]);
            string states = this.lbstate.Text;
            string state = "1";
            if (states == "停用")
            {
                JsMessage.jsAlert("已经停用该用户！");

                return;
            }
            if (new HrBll().H_TYUser(I, state) > 0)
            {
                JsMessage.jsAlert("停用成功！");
                use = (U_User)Session["U_USER"];
                Model.M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "停用用户！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
            }
            bind();
        }
        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnHf_Click(object sender, EventArgs e)
        {
            int I = int.Parse(Request.QueryString["UID"]);
            string states = this.lbstate.Text;
            string state = "0";
            if (states == "正常")
            {
                JsMessage.jsAlert("已经恢复该用户！");
                return;
            }
            if (new HrBll().H_TYUser(I, state) > 0)
            {
                JsMessage.jsAlert("恢复成功！");
                use = (U_User)Session["U_USER"];
                Model.M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "恢复用户！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
            }
            bind();
        }
    }
}