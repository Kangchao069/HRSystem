using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.admin
{
    public partial class M_SalaryDetailByUser : System.Web.UI.Page
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
            }

        }
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            use = (U_User)Session["U_USER"];
            int uid = use.UID;
            string month = this.ipTime.Value.ToString();
            //string mmmm =Convert.ToDateTime( month).ToString("yyyy-MM");

            this.repBind.DataSource = new ManageBll().getSalaryInfo(uid, month);
            this.repBind.DataBind();
        }
    }
}