using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.HR
{
    public partial class H_AddResignation : System.Web.UI.Page
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
        /// 为用户名称和部门赋值
        /// </summary>
        public void bind()
        {
            use = (U_User)Session["U_USER"];
            this.LbUserName.Text = use.UserName;//为用户名赋值
            
            this.LbDid.Text = use.DID.DName.ToString();//为部门赋值
            
        }
        /// <summary>
        /// 确认提交信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmission_Click(object sender, EventArgs e)
        {
            U_Resignation re = new U_Resignation();
            if (string.IsNullOrEmpty(this.TbReason.Text) || string.IsNullOrEmpty(this.TbTime.Text))
            {
                JsMessage.jsAlert("辞职信息不能为空！");
                return;
            }
            use = (U_User)Session["U_USER"];
            int i = use.UID;
            int dp = use.DID.DID;
            U_User u = new U_User();
            u.UID = i;
            re.UID = u;
            U_Department d = new U_Department();
            d.DID = dp;
            re.DID = d;
            re.Reason = this.TbReason.Text.ToString();
            re.Time = Convert.ToDateTime( this.TbTime.Text.ToString());
            re.Remark = this.TbRemark.Text.Trim();
            re.State = "null";
            if (string.IsNullOrEmpty(this.TbReason.Text)||string.IsNullOrEmpty(this.TbTime.Text))
            {
                JsMessage.jsAlert("辞职信息不能为空！");
                return;
            }
            DataTable  r = new HrBll().H_SelResignations(i);
            //U_User us = new U_User();
            //us.UID=
            //int uid = r.UID.UID;
            if (r.Rows.Count==1)
            {
                JsMessage.jsAlert("你已经发送过辞职信息了,不能反复发送！");
                return;
            }
            if (new UserBll().U_AddResigntion(re)>0)
            {
                JsMessage.jsAlert("编辑成功！");
                use = (U_User)Session["U_USER"];
                M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "编辑辞职信息！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
                return;
            }

            //清空所有信息
            this.TbReason.Text = "";
            this.TbRemark.Text = "";
            this.TbTime.Text = "";
        }
        /// <summary>
        /// 重置所有信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnClous_Click(object sender, EventArgs e)
        {
            this.TbReason.Text = "";
            this.TbRemark.Text = "";
            this.TbTime.Text = "";
        }
    }
}