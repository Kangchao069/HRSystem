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
    public partial class H_SelLeaveInfo : System.Web.UI.Page
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
            //为文本赋值
            List<U_Leave> ti = new HrBll().H_selLeave();
            CollectionPager1.DataSource = ti;
            CollectionPager1.BindToControl = RLeave;
            this.RLeave.DataSource = CollectionPager1.DataSourcePaged;
            this.RLeave.DataBind();


            //为部门赋值
            this.DdlD.DataSource = new UserBll().U_SelDepartment();
            this.DdlD.DataTextField = "DName";
            this.DdlD.DataValueField = "DID";
            this.DdlD.DataBind();
        }
        /// <summary>
        /// 根据员工id进行模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByID_Click(object sender, EventArgs e)
        {

            int uid =int.Parse( this.TbNumber.Value.Trim());
            if (string.IsNullOrEmpty(this.TbNumber.Value))
            {
                JsMessage.jsAlert("员工编号不能为空！");
                return;
            }
            Regex idcard = new Regex("^[0-9]*$");
            if (!idcard.IsMatch(this.TbNumber.Value))
            {
                JsMessage.jsAlert("编号只能为数字！");
                return;
            }
            List<U_Leave> le = new HrBll().H_selLeaveByUid(uid);
            CollectionPager1.DataSource = le;
            CollectionPager1.BindToControl = RLeave;
            this.RLeave.DataSource = CollectionPager1.DataSourcePaged;
            this.RLeave.DataBind();
        }
        /// <summary>
        /// 根据员工名字进行模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByName_Click(object sender, EventArgs e)
        {
            string name = this.TbName.Value.Trim();
            List<U_Leave> le = new HrBll().H_selLeaveByName(name);
            CollectionPager1.DataSource = le;
            CollectionPager1.BindToControl = RLeave;
            this.RLeave.DataSource = CollectionPager1.DataSourcePaged;
            this.RLeave.DataBind();
        }
        /// <summary>
        /// 通过部门进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByD_Click(object sender, EventArgs e)
        {
            int did = int.Parse(this.DdlD.SelectedValue.ToString());
            if (string.IsNullOrEmpty(this.TbName.Value))
            {
                JsMessage.jsAlert("用户名字信息不能为空!");
                return;
            }
            List<U_Leave> le = new HrBll().H_selLeaveByDID(did);
            CollectionPager1.DataSource = le;
            CollectionPager1.BindToControl = RLeave;
            this.RLeave.DataSource = CollectionPager1.DataSourcePaged;
            this.RLeave.DataBind();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            List<HtmlInputCheckBox> hicb = Utils.ReadAllControls<HtmlInputCheckBox>(this.RLeave);
            foreach (HtmlInputCheckBox item in hicb)
            {
                if (item.ID == "chkItem" && item.Checked)
                {
                    new HrBll().H_DelLeaveInfo(Convert.ToInt32(item.Value));
                    JsMessage.jsAlert("删除成功！");
                }
            }

            use = (U_User)Session["U_USER"];
            Model.M_JournalInfo ji = new Model.M_JournalInfo();
            ji.Content = use.UserName + "发布任务！";
            ji.ReleaseTime = DateTime.Now.ToLocalTime();
            ji.LoginName = use.LoginName;
            new UserBll().AddJournalInfo(ji);
            bind();
        }
    }
}