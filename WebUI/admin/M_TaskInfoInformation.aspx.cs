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
    public partial class M_TaskInfoInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                upd();
                did();
            }
        }
        /// <summary>
        /// 详细信息 
        /// </summary>
        public void bind()
        {
           int I=int.Parse( Request.QueryString["TID"]);
           
            M_TaskInfo ti = new ManageBll().SelTaskInfox(I);
            this.LbTaskName.Text = ti.TaskName;
            this.LbDID.Text = ti.DID.DName.ToString();
            this.LbTime.Text = ti.ReleaseTime.ToString();
            this.LbContent.Text = ti.Content;
            this.LbRemark.Text = ti.Remark;
        }
        /// <summary>
        /// 给textbox赋值
        /// </summary>
        public void upd()
        {
            int I = int.Parse(Request.QueryString["TID"]);
            M_TaskInfo ti = new ManageBll().SelTaskInfox(I);
            this.TbName.Text = ti.TaskName;
            //this.DdlDids.Text = ti.DID.DName.ToString();
            this.TbContent.Text = ti.Content;
            this.TbRemark.Text = ti.Remark;
        }
        /// <summary>
        /// 为部门信息赋值
        /// </summary>
        public void did()
        {
            this.DdlDids.DataSource = new UserBll().U_SelDepartment();
            this.DdlDids.DataTextField = "DName";
            this.DdlDids.DataValueField = "DID";
            this.DdlDids.DataBind();
        }
        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                int I = int.Parse(Request.QueryString["TID"]);
                M_TaskInfo ta = new M_TaskInfo();
                ta.TID = I;
                ta.TaskName = this.TbName.Text.Trim();
                ta.ReleaseTime = DateTime.Now.ToLocalTime();
                int dd = int.Parse(this.DdlDids.SelectedValue.ToString());
                U_Department d = new U_Department();
                d.DID = dd;
                ta.DID = d;
                ta.Content = this.TbContent.Text.Trim();
                ta.Remark = this.TbRemark.Text.Trim();
                if (string.IsNullOrEmpty(this.TbName.Text) || string.IsNullOrEmpty(this.TbContent.Text))
                {
                    JsMessage.jsAlert("修改信息不能为空");
                    return;
                }
                if (new ManageBll().M_UpdTaskInfos(ta)>0)
                {
                    JsMessage.jsAlert("修改成功");
                    bind();
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
        }
    }
}