using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class U_Attendance : System.Web.UI.Page
    {
        U_User use = new U_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                use = (U_User)Session["U_USER"];
                ///klksdjiasjfijaifjaijiofjaj
                int UID = use.UID;

                repBindAttendDate(UID);
                repbindLeaveDate(UID);
            }
        }
        /// <summary>
        /// 获取员工出勤信息
        /// </summary>
        public void repBindAttendDate(int UID) {
            this.gvPaper.DataSource = new ManageBll().getUserAttendInfo(UID);
            this.gvPaper.DataBind();
        }
        /// <summary>
        /// 获取员工请假信息
        /// </summary>
        public void repbindLeaveDate(int UID)
        {
            this.gvLeaveDate.DataSource = new ManageBll().getUserLeaveInfo(UID);
            this.gvLeaveDate.DataBind();
        }
    }
}