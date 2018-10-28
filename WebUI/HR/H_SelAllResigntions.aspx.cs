using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebUI.HR
{
    public partial class H_SelAllResigntions : System.Web.UI.Page
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
                if ((U_User)Session["U_USER"]==null)
                {
                    Response.Redirect("../M_UserLogin.aspx");
                }
                bind();
            }
        }
        public void bind()
        {
            //查询辞职信息
            List<U_Resignation> ti = new HrBll().H_selResignation();
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = GvResignation;
            this.GvResignation.DataSource = CollectionPager1.DataSourcePaged;
            this.GvResignation.DataBind();

            //查询部门信息
            this.DdlDid.DataSource = new UserBll().U_SelDepartment();
            this.DdlDid.DataTextField = "DName";
            this.DdlDid.DataValueField = "DID";
            this.DdlDid.DataBind();
        }
        

        /// <summary>
        /// 停用用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvResignation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int uid= Convert.ToInt32((this.GvResignation.Rows[e.RowIndex].FindControl("LbUid") as Label).Text);
            string states = (this.GvResignation.Rows[e.RowIndex].FindControl("LbState") as Label).Text;
            string  state = "1";
            if (states=="停用")
            {
                JsMessage.jsAlert("已经停用该用户！");
                use = (U_User)Session["U_USER"];
                M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "停用用户！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
                return;
            }
            if (new HrBll().H_TYUser(uid,state)>0)
            {
                JsMessage.jsAlert("停用成功！");   
            }
            bind();

        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            List<HtmlInputCheckBox> hicb = Utils.ReadAllControls<HtmlInputCheckBox>(this.GvResignation);
            foreach (HtmlInputCheckBox item in hicb)
            {
                if (item.ID == "ctlName" && item.Checked)
                {
                    new HrBll().H_DelResignations(Convert.ToInt32(item.Value));
                    JsMessage.jsAlert("删除成功！");
                    
                }
            }
            use = (U_User)Session["U_USER"];
            M_JournalInfo ji = new Model.M_JournalInfo();
            ji.Content = use.UserName + "删除辞职信息！";
            ji.ReleaseTime = DateTime.Now.ToLocalTime();
            ji.LoginName = use.LoginName;
            new UserBll().AddJournalInfo(ji);
            bind();

        }
        /// <summary>
        /// 根据id进行模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.TbUid.Value.Trim());
            if (string.IsNullOrEmpty(this.TbUid.Value))
            {
                JsMessage.jsAlert("员工编号不能为空！");
                return;
            }
            Regex idcard = new Regex("^[0-9]*$");
            if (!idcard.IsMatch(this.TbUid.Value))
            {
                JsMessage.jsAlert("编号只能为数字！");
                return;
            }
            List<U_Resignation> ti = new HrBll().H_SelReasontionByUID(id);
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = GvResignation;
            this.GvResignation.DataSource = CollectionPager1.DataSourcePaged;
            this.GvResignation.DataBind();
            this.TbUid.Value = "";
        }
        /// <summary>
        /// 根据部门进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByDid_Click(object sender, EventArgs e)
        {
            int did = int.Parse(this.DdlDid.SelectedValue.ToString());
            List<U_Resignation> ti = new HrBll().H_SelReasontionByDID(did);
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = GvResignation;
            this.GvResignation.DataSource = CollectionPager1.DataSourcePaged;
            this.GvResignation.DataBind();
            
        }
        /// <summary>
        /// 根据名字进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByName_Click(object sender, EventArgs e)
        {
            string name = this.TbName.Value.Trim();
            if (string.IsNullOrEmpty(this.TbName.Value))
            {
                JsMessage.jsAlert("员工名字信息不能为空！");
                return;
            }
            List<U_Resignation> ti = new HrBll().H_SelReasontionByName(name);
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = GvResignation;
            this.GvResignation.DataSource = CollectionPager1.DataSourcePaged;
            this.GvResignation.DataBind();
            this.TbName.Value = "";
        }
    }
}