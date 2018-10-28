using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.admin
{
    public partial class M_PerssionUserType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindtt();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void bindtt()
        {
            DataTable dt = new ManageBll().GetManageType();
            this.gvManageType.DataSource = dt;
            this.gvManageType.DataBind();
        }

    }
}