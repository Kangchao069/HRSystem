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
    public partial class M_SalarySeach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ///默认txtUserName隐藏
                 this.txtUserName.Visible = false;

                this.dlSalary.DataSource = new ManageBll().getUserSalary();
                this.dlSalary.DataBind();

                this.ddlDepartment.DataSource = new ManageBll().getDepartment();
                this.ddlDepartment.DataValueField = "DID";
                this.ddlDepartment.DataTextField = "DName";
                this.ddlDepartment.DataBind();

                //分页
                DataTable ti = new ManageBll().getUserSalary();
                CollectionPager1.DataSource = ti.DefaultView;///强转
                CollectionPager1.BindToControl = dlSalary;
                this.dlSalary.DataSource = CollectionPager1.DataSourcePaged;
                this.dlSalary.DataBind();
            }
        }
        /// <summary>
        /// 触发下拉框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlKindUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlKindUser.SelectedValue == "1")
            {
                this.ddlDepartment.Visible = true;
                this.txtUserName.Visible = false;
            }
            if (this.ddlKindUser.SelectedValue == "2")
            {
                this.txtUserName.Visible = true;
                this.ddlDepartment.Visible = false;
            }
            if (this.ddlKindUser.SelectedValue=="3")
            {
                this.txtUserName.Visible = false;
                this.ddlDepartment.Visible = false;
            }
        }
        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeach_Click(object sender, EventArgs e)
        {
            if (ddlKindUser.SelectedValue == "1")
            {
                this.dlSalary.DataSource = new ManageBll().getUserSalaryInfoByDID(Convert.ToInt32(this.ddlDepartment.SelectedValue));
                this.dlSalary.DataBind();
            }
            if (ddlKindUser.SelectedValue == "2")
            {

                this.dlSalary.DataSource = new ManageBll().getUserSalaryInfoByUserName(this.txtUserName.Text.Trim());
                this.dlSalary.DataBind();
            }
            if (ddlKindUser.SelectedValue=="3")
            {
                this.dlSalary.DataSource = new ManageBll().getUserSalary();
                this.dlSalary.DataBind();
            }



        }
    }
}