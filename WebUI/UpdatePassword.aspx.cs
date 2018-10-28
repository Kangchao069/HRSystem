using BLL;
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
    public partial class UpdatePassword : System.Web.UI.Page
    {
        U_User use = new U_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((U_User)Session["U_USER"] == null)
                {
                    Response.Redirect("M_UserLogin.aspx");
                }
            }
        }
        /// <summary>
        /// 保存用户修改的密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            use = (U_User)Session["U_USER"];
            int uid = use.UID;




            ///获取输入内容
            string pwd = this.iptRePwd.Value.Trim();
            string rePwd = this.iptNewPwd.Value.Trim();
            string surePwd = this.iptSurePwd.Value.Trim();

            if (rePwd != surePwd)
            {
                Common.JsMessage.jsAlert("两次新密码输入不一致！");
                return;
            }
            if (pwd.Length == 0 || rePwd.Length == 0 || surePwd.Length == 0)
            {
                Common.JsMessage.jsAlert("输入不能为空！");
                return;
            }
            if (pwd.Length < 6 || rePwd.Length < 6 || surePwd.Length < 6)
            {
                Common.JsMessage.jsAlert("密码至少为6位！");
                return;
            }
            DataTable dt = new ManageBll().selectbeginPwd(uid, pwd);
            if (dt.Rows.Count > 0)
            {
                if (new ManageBll().updatePasswordByUID(uid, rePwd) > 0)
                {
                    Common.JsMessage.jsAlert("修改成功!");
                }
                else
                {
                    Common.JsMessage.jsAlert("修改失败!");
                }
            }
            else
            {
                Common.JsMessage.jsAlert("原密码不正确!");
            }
        }
    }
}