using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.HR
{
    public partial class H_AddUser : System.Web.UI.Page
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
        /// 定义方法为下拉框赋值
        /// </summary>
        public void bind()
        {
            //为部门赋值
            this.DdlDeparment.DataSource = new UserBll().U_SelDepartment();
            this.DdlDeparment.DataTextField = "DName";
            this.DdlDeparment.DataValueField = "DID";
            this.DdlDeparment.DataBind();

            //为职位赋值
            this.DdlPost.DataSource = new UserBll().U_SelUserPostInfo();
            this.DdlPost.DataTextField = "PName";
            this.DdlPost.DataValueField = "PID";
            this.DdlPost.DataBind();

            //为学历赋值
            this.DdlEducation.DataSource = new UserBll().SelEductaionInfo();
            this.DdlEducation.DataTextField = "Education";
            this.DdlEducation.DataValueField = "EID";
            this.DdlEducation.DataBind();
            //用户类型
            this.DdlType.DataSource = new UserBll().selUserTypeInfor();
            this.DdlType.DataTextField = "TName";
            this.DdlType.DataValueField = "UTID";
            this.DdlType.DataBind();
        }
        /// <summary>
        /// 确认添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            U_User user = new U_User();
            user.UserName = this.TbUserName.Value.Trim();
            user.LoginName = this.TbLoginName.Value.Trim();
            user.LoginPassword = "123456";
            U_UserType ut = new U_UserType();
            ut.UTID = int.Parse(this.DdlType.SelectedValue.ToString());
            user.UTID = ut;
            U_Department d = new U_Department();
            d.DID = int.Parse(this.DdlDeparment.SelectedValue.ToString());
            user.DID = d;
            U_Post p = new U_Post();
            p.PID = int.Parse(this.DdlPost.SelectedValue.ToString());
            user.PID = p;
            U_EducationInfo ed = new U_EducationInfo();
            ed.EID = int.Parse(this.DdlEducation.SelectedValue.ToString());
            user.EID = ed;
            user.IDCard = this.TbIdCard.Value.Trim();
            user.Phone = this.TbPhone.Value.Trim();
            user.Address = this.TbAddress.Value.Trim();
            user.Email = this.TbEmail.Value.Trim();
            user.Academy = this.TbAcademy.Value.Trim();
            user.Sex = this.DdlSex.Text.Trim();
            user.Details = this.TbDetail.Text.Trim();
            user.Remark = this.TbRemark.Value.Trim();
            user.State = "0";
            if (string.IsNullOrEmpty(TbUserName.Value) || string.IsNullOrEmpty(TbLoginName.Value) || string.IsNullOrEmpty(TbIdCard.Value) || string.IsNullOrEmpty(TbPhone.Value) || string.IsNullOrEmpty(TbAddress.Value) || string.IsNullOrEmpty(TbEmail.Value) || string.IsNullOrEmpty(TbDetail.Text) || string.IsNullOrEmpty(TbRemark.Value)||string.IsNullOrEmpty(this.TbAcademy.Value))
            {
                JsMessage.jsAlert("用户信息不能为空");
                return;
            }
            Regex email = new Regex("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+\\.[a-zA-Z0-9_-]+$");
            if (!email.IsMatch(this.TbEmail.Value))
            {
                JsMessage.jsAlert("邮箱格式不正确！");
                return;
            }
            Regex mobileReg = new Regex("[0-9]{11,11}");
            if (!mobileReg.IsMatch(this.TbPhone.Value))
            {
                JsMessage.jsAlert("电话号码格式输入错误！");
                return;
            }
            Regex idcard = new Regex("d{14}[[0-9],0-9xX]");
            if (!idcard.IsMatch(this.TbIdCard.Value))
            {
                JsMessage.jsAlert("身份证格式输入有误！");
                return;
            }
            if (new HrBll().AddUsers(user)>0)
            {
                JsMessage.jsAlert("添加成功");
                use = (U_User)Session["U_USER"];
                M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "添加用户！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
            }
        }
    }
}