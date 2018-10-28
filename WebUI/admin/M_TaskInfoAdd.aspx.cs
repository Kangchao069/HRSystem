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

namespace WebUI.admin
{
    public partial class M_TaskInfoAdd : System.Web.UI.Page
    {
        U_User use = new U_User();
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 查询用户部门
        /// </summary>
        public void bind()
        {
            DataTable dt = new UserBll().U_SelDepartment();
            this.DdlDID.DataSource = dt;
            this.DdlDID.DataTextField = "DName";
            this.DdlDID.DataValueField = "DID";
            this.DdlDID.DataBind();

    }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmission_Click(object sender, EventArgs e)
        {
            M_TaskInfo ti = new M_TaskInfo();
            ti.TaskName = this.TbTaskName.Text.Trim();
            int dd =int.Parse( this.DdlDID.SelectedValue.ToString());
            U_Department dt = new U_Department();
            dt.DID = dd;
            dt.DName = this.DdlDID.Text.ToString();
            ti.DID = dt;
            ti.ReleaseTime= DateTime.Now.ToLocalTime();
            ti.Content = this.TbContent.Text.ToString();
            ti.Remark = this.TbRemark.Text.Trim();
            if (string.IsNullOrEmpty(this.TbTaskName.Text)||string.IsNullOrEmpty(this.TbContent.Text))
            {
                JsMessage.jsAlert("任务信息不能为空!");
                return;
            }
            if (new ManageBll().AddTaskInfo(ti) > 0)
            {
                JsMessage.jsAlert("添加成功");
                use = (U_User)Session["U_USER"];
                 Model.M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "发布任务！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
                //内容清零
                this.TbTaskName.Text = "";
                this.TbContent.Text = "";
                this.TbRemark.Text = "";
                bind();
            }
        }
        /// <summary>
        /// 重置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnClous_Click(object sender, EventArgs e)
        {
            this.TbTaskName.Text = "";
            this.TbContent.Text = "";
            this.TbRemark.Text = "";
            bind();
        }
    }
}