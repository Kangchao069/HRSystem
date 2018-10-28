using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebUI.admin
{
    public partial class M_SelTaskInfo : System.Web.UI.Page
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
            List<M_TaskInfo> ti = new ManageBll().SelTaskInfo();
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = RTaskInfo;
            this.RTaskInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.RTaskInfo.DataBind();
            //为部门信息赋值
            this.DdlDid.DataSource = new UserBll().U_SelDepartment();
            this.DdlDid.DataTextField = "DName";
            this.DdlDid.DataValueField = "DID";
            this.DdlDid.DataBind();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            List<HtmlInputCheckBox> hicb = Utils.ReadAllControls<HtmlInputCheckBox>(this.RTaskInfo);
            foreach (HtmlInputCheckBox item in hicb)
            {
                if (item.ID == "chkItem" && item.Checked)
                {
                    new ManageBll().M_DelTasks(Convert.ToInt32(item.Value));

                }
            }
            JsMessage.jsAlert("删除成功！");

            use = (U_User)Session["U_USER"];
            Model.M_JournalInfo ji = new Model.M_JournalInfo();
            ji.Content = use.UserName + "发布任务！";
            ji.ReleaseTime = DateTime.Now.ToLocalTime();
            ji.LoginName = use.LoginName;
            new UserBll().AddJournalInfo(ji);
            bind();
        }
        /// <summary>
        /// 通过部门进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByDid_Click(object sender, EventArgs e)
        {
            int did = int.Parse(this.DdlDid.SelectedValue.ToString());
            List<M_TaskInfo> ti = new ManageBll().M_SelTaskByDID(did);
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = RTaskInfo;
            this.RTaskInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.RTaskInfo.DataBind();
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnALL_Click(object sender, EventArgs e)
        {
            List<M_TaskInfo> ti = new ManageBll().SelTaskInfo();
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = RTaskInfo;
            this.RTaskInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.RTaskInfo.DataBind();
        }
    }
}