using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.admin
{
    public partial class M_BasicWages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.repShow.DataSource = new ManageBll().getBasicWages();
                this.repShow.DataBind();
            }
        }
    }
}