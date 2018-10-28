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

namespace WebUI
{
    public partial class M_UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bind();
            }
        }
        public void bind()
        {
            this.ddlUserType.DataSource = new UserBll().selUserTypeInfor();
            this.ddlUserType.DataTextField = "TName";
            this.ddlUserType.DataValueField = "UTID";
            this.ddlUserType.DataBind();
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            U_User user = new U_User();
            user.LoginName = this.TtbName.Value.ToString();
            user.LoginPassword = this.TtbPswd.Value.ToString();
            if (string.IsNullOrEmpty(TtbName.Value) || string.IsNullOrEmpty(TtbPswd.Value))
            {
                JsMessage.jsAlert("登录信息不能为空");
                return;
            }
            int type = int.Parse(ddlUserType.SelectedValue.ToString());
            U_UserType ut = new U_UserType();
            ut.UTID = type;
            user.UTID = ut;
            user = new UserBll().GetInfoByNameAndPswAndType(user.LoginName, user.LoginPassword,type);
            if (user.UID>0)
            {
                M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = user.UserName + "登录进入系统！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = user.LoginName;
                new UserBll().AddJournalInfo(ji);
                Session["U_USER"] = user;
                Response.Redirect("M_Index.aspx");
            }
            else
            {
                Common.JsMessage.jsAlert("登录失败！请检查信息输入是否正确！");
                return;
            }
        }
        /// <summary>
        /// 重置登录信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCZ_Click(object sender, EventArgs e)
        {
            this.TtbName.Value = "";
            this.TtbPswd.Value = "";
        }
    }
}