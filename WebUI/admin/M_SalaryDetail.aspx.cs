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
    public partial class M_SalaryDetail : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uid = int.Parse(Request.QueryString["UID"]);
                string month =Request.QueryString["Month"] ;
                //转化时间格式
               string dd= DateTime.Parse(month).ToString("yyyy-MM-dd").Replace('/', '-');
               string mm= dd.Substring(0, 7);

                this.repBind.DataSource = new ManageBll().getSalaryInfo(uid,mm);
               this.repBind.DataBind();

            }

        }
        ///// <summary>
        ///// 查询事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{

        //    int uid = int.Parse(Request.QueryString["UID"]);
        //    string month = this.ipTime.Value.ToString();
        //    this.repBind.DataSource = new ManageBll().getSalaryInfo(uid,month);
        //    this.repBind.DataBind();
        //}
    }
}