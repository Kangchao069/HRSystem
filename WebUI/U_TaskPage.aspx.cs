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
    public partial class U_TaskPage : System.Web.UI.Page
    {
        U_User use = new U_User();
        //U_Department de = new U_Department();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                use = (U_User)Session["U_USER"];
                int did = use.DID.DID;
                bindRepLeave(did);





            }
        }

        public void bindRepLeave(int did)
        {
            this.repLeaveInfo.DataSource = new ManageBll().getUserTaskInfo(did);
            this.repLeaveInfo.DataBind();



           //分页
            DataTable ti=new ManageBll().getUserTaskInfo(did);
            CollectionPager1.DataSource = ti.DefaultView;///强转
            CollectionPager1.BindToControl = repLeaveInfo;
            this.repLeaveInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.repLeaveInfo.DataBind();
        }
    }
}