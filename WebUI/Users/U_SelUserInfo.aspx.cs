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

namespace WebUI
{
    public partial class U_SelUserInfo : System.Web.UI.Page
    {
        U_User use = new U_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                use = (U_User)Session["U_USER"];
                if ((U_User)Session["U_USER"] == null)
                {
                    Response.Redirect("../M_UserLogin.aspx");
                }
                bind();
                UPD();
                Education();

            }
        }
        public void bind()
        {
            int i = use.UID;
            U_User us = new UserBll().selAllUserInfoByID(i);
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


        }
        public void UPD()
        {
            int i = use.UID;
            U_User us = new UserBll().selAllUserInfoByID(i);

            this.TTbName.Text = us.UserName;
            //U_Post p = new U_Post();
            this.TTbPhone.Text = us.Phone;
            this.TTbIDCard.Text = us.IDCard;
            this.TTbAcademy.Text = us.Academy;
            this.TbSex.Text = us.Sex;
            this.TTbDetails.Text = us.Details;
            this.TTbEmail.Text = us.Email;
            this.TTbAddress.Text = us.Address;
            this.TbRemark.Text = us.Remark;
        }
        public void Education()
        {
            this.TbEducation.DataSource = new UserBll().SelEductaionInfo();
            this.TbEducation.DataValueField = "EID";
            this.TbEducation.DataTextField = "Education";
            this.TbEducation.DataBind();
        }
        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                use = (U_User)Session["U_USER"];
                int i = use.UID;
                U_User user = new U_User();
                user.UID = i;
                user.UserName = this.TTbName.Text.Trim();
                user.Sex = this.TbSex.Text.ToString();
                user.Phone = this.TTbPhone.Text.Trim();
                user.IDCard = this.TTbIDCard.Text.Trim();
                user.Address = this.TTbAddress.Text.Trim();
                U_EducationInfo et = new U_EducationInfo();
                et.EID = int.Parse(this.TbEducation.SelectedValue.ToString());
                user.EID = et;
                user.Academy = this.TTbAcademy.Text.Trim();
                user.Details = this.TTbDetails.Text.Trim();
                user.Remark = this.TbRemark.Text.Trim();
                if (string.IsNullOrEmpty(TTbName.Text) || string.IsNullOrEmpty(TTbPhone.Text) || string.IsNullOrEmpty(TTbIDCard.Text) || string.IsNullOrEmpty(TTbAddress.Text) || string.IsNullOrEmpty(TTbAcademy.Text) || string.IsNullOrEmpty(TTbDetails.Text) || string.IsNullOrEmpty(TTbEmail.Text) || string.IsNullOrEmpty(TbRemark.Text))
                {
                    JsMessage.jsAlert("登录信息不能为空");
                    return;
                }
                Regex email = new Regex("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+\\.[a-zA-Z0-9_-]+$");
                if (!email.IsMatch(this.TTbEmail.Text))
                {
                    JsMessage.jsAlert("邮箱格式不正确！");
                    return;
                }
                Regex mobileReg = new Regex("[0-9]{11,11}");
                if (!mobileReg.IsMatch(this.TTbPhone.Text))
                {
                    JsMessage.jsAlert("电话号码格式输入错误！");
                    return;
                }
                //Regex idcard = new Regex("d{14}[[0-9],0-9xX]");
                //if (!idcard.IsMatch(this.TTbIDCard.Text))
                //{
                //    JsMessage.jsAlert("身份证格式输入有误！");
                //    return;
                //}

                if (new UserBll().UpdUserInfor(user) > 0)
                {
                    Common.JsMessage.jsAlert("修改成功！");
                    M_JournalInfo ji = new Model.M_JournalInfo();
                    ji.Content = use.UserName + "修改个人信息！";
                    ji.ReleaseTime = DateTime.Now.ToLocalTime();
                    ji.LoginName = use.LoginName;
                    new UserBll().AddJournalInfo(ji);
                    this.bind();

                }
                
            }
            catch (Exception ex)
            {

                Common.JsMessage.jsAlert(ex.Message);
            }
            
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCols_Click(object sender, EventArgs e)
        {
            this.TTbName.Text = "";
            this.TTbPhone.Text = "";
            this.TTbAddress.Text = "";
            this.TTbAcademy.Text = "";
            this.TTbDetails.Text = "";
            this.TTbEmail.Text = "";
            this.TbRemark.Text = "";
        }
    }
}