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
    public partial class M_JournalInfo : System.Web.UI.Page
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
                    Response.Redirect("M_UserLogin.aspx");
                }
                bind();
            }
        }
        /// <summary>
        /// 创建一个查询日志的方法
        /// </summary>
        public void bind()
        {
            List<Model.M_JournalInfo> mj = new ManageBll().SelJournal();
            CollectionPager1.DataSource = mj;
            CollectionPager1.BindToControl = GvJournal;
            this.GvJournal.DataSource = CollectionPager1.DataSourcePaged;
            this.GvJournal.DataBind();
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvJournal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int JID = Convert.ToInt32((this.GvJournal.Rows[e.RowIndex].FindControl("LbNumber") as Label).Text);
            if (new ManageBll().DelJournal(JID) > 0)
            {
                JsMessage.jsAlert("删除成功");
                use = (U_User)Session["U_USER"];
                Model.M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "删除了日志信息！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
                //数据刷新
                this.bind();
            }
        }
        /// <summary>
        /// 根据名字进行迷糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnName_Click(object sender, EventArgs e)
        {
            string name = this.TbName.Value.Trim();
            List<Model.M_JournalInfo> mj = new ManageBll().selJournalInfoByName(name);
            CollectionPager1.DataSource = mj;
            CollectionPager1.BindToControl = GvJournal;
            this.GvJournal.DataSource = CollectionPager1.DataSourcePaged;
            this.GvJournal.DataBind();
        }
        ///// <summary>
        ///// 根据时间查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void BtnTime_Click(object sender, EventArgs e)
        //{
        //    string time = this.TbTime.Value.Trim();
        //    List<Model.M_JournalInfo> mj = new ManageBll().selJournalInfoByTimes(time);
        //    CollectionPager1.DataSource = mj;
        //    CollectionPager1.BindToControl = GvJournal;
        //    this.GvJournal.DataSource = CollectionPager1.DataSourcePaged;
        //    this.GvJournal.DataBind();
        //}
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            List<HtmlInputCheckBox> hicb = Utils.ReadAllControls<HtmlInputCheckBox>(this.GvJournal);
            foreach (HtmlInputCheckBox item in hicb)
            {
                if (item.ID == "ctlName" && item.Checked)
                {
                    new ManageBll().M_DelJournals(Convert.ToInt32(item.Value));
                    
                }
                
                }
            JsMessage.jsAlert("删除成功");
            use = (U_User)Session["U_USER"];
            Model.M_JournalInfo ji = new Model.M_JournalInfo();
            ji.Content = use.UserName + "删除了日志信息！";
            ji.ReleaseTime = DateTime.Now.ToLocalTime();
            ji.LoginName = use.LoginName;
            new UserBll().AddJournalInfo(ji);
            bind();
        }
    }
}