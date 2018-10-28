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

namespace WebUI.HR
{
    public partial class H_UpdUserInfo : System.Web.UI.Page
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
                bind();
            }
        }

        /// <summary>
        /// 创建一个方法查询用户数据
        /// </summary>
        public void bind()
        {
            List<U_User> user = new UserBll().U_SelAllUserInfo();
            CollectionPager1.DataSource = user;
            CollectionPager1.BindToControl = GvUserInfo;
            this.GvUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.GvUserInfo.DataBind();

            //为部门下拉框赋值
            this.DdlDepartements.DataSource = new UserBll().U_SelDepartment();
            this.DdlDepartements.DataTextField = "DName";
            this.DdlDepartements.DataValueField = "DID";
            this.DdlDepartements.DataBind();
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList post = e.Row.FindControl("DdlPost") as DropDownList;
            if (post != null)
            {

                post.DataSource = new UserBll().U_SelUserPostInfo();
                post.DataTextField = "PName";
                post.DataValueField = "PID";
                post.DataBind();
            }
            DropDownList department = e.Row.FindControl("DdlDepartment") as DropDownList;
            if (department != null)
            {

                department.DataSource = new UserBll().U_SelDepartment();
                department.DataTextField = "DName";
                department.DataValueField = "DID";
                department.DataBind();
            }
            DropDownList type = e.Row.FindControl("DdlType") as DropDownList;
            if (type !=null)
            {
                type.DataSource = new UserBll().selUserTypeInfor();
                type.DataTextField = "TName";
                type.DataValueField = "UTID";
                type.DataBind();
            }
           
        }
        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvUserInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GvUserInfo.EditIndex = e.NewEditIndex;
            this.bind();
        }
        /// <summary>
        /// 编辑取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvUserInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GvUserInfo.EditIndex = -1;
            this.bind();
        }
        /// <summary>
        /// 更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvUserInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                U_User us = new U_User();
                us.UID = Convert.ToInt32((this.GvUserInfo.Rows[e.RowIndex].FindControl("ID") as HiddenField).Value);
                U_UserType ut = new U_UserType();
                ut.UTID= (this.GvUserInfo.Rows[e.RowIndex].FindControl("DdlType") as DropDownList).SelectedValue == "" ? 0 : Convert.ToInt32((this.GvUserInfo.Rows[e.RowIndex].FindControl("DdlType") as DropDownList).SelectedValue);
                us.UTID = ut;
                U_Post post = new U_Post();
                post.PID = (this.GvUserInfo.Rows[e.RowIndex].FindControl("DdlPost") as DropDownList).SelectedValue == "" ? 0 : Convert.ToInt32((this.GvUserInfo.Rows[e.RowIndex].FindControl("DdlPost") as DropDownList).SelectedValue);
                us.PID = post;
                U_Department dp = new U_Department();
                dp.DID = (this.GvUserInfo.Rows[e.RowIndex].FindControl("DdlDepartment") as DropDownList).SelectedValue == "" ? 0 : Convert.ToInt32((this.GvUserInfo.Rows[e.RowIndex].FindControl("DdlDepartment") as DropDownList).SelectedValue);
                us.DID = dp;
                if (new HrBll().H_UpdUserInfoByPidAndDid(us) > 0)
                {
                    JsMessage.jsAlert("修改成功");
                    this.GvUserInfo.EditIndex = -1;
                    use = (U_User)Session["U_USER"];
                    M_JournalInfo ji = new Model.M_JournalInfo();
                    ji.Content = use.UserName + "修改用户信息！";
                    ji.ReleaseTime = DateTime.Now.ToLocalTime();
                    ji.LoginName = use.LoginName;
                    new UserBll().AddJournalInfo(ji);
                    //数据绑定
                    this.bind();
                }
            }
            catch (Exception ex)
            {

                JsMessage.jsAlert(ex.Message);
            }
            
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvUserInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int UID = Convert.ToInt32((this.GvUserInfo.Rows[e.RowIndex].FindControl("IDs") as HiddenField).Value);
            if (new HrBll().H_DelUserInfoByUID(UID) > 0)
            {
                JsMessage.jsAlert("删除成功");
                //数据刷新
                use = (U_User)Session["U_USER"];
                M_JournalInfo ji = new Model.M_JournalInfo();
                ji.Content = use.UserName + "删除用户信息！";
                ji.ReleaseTime = DateTime.Now.ToLocalTime();
                ji.LoginName = use.LoginName;
                new UserBll().AddJournalInfo(ji);
                this.bind();
            }
            
        }

       
        /// <summary>
        /// 根据工号进行模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSel_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.TbID.Value.Trim());
            if (string.IsNullOrEmpty(this.TbID.Value))
            {
                JsMessage.jsAlert("员工编号不能为空！");
                return;
            }
            Regex idcard = new Regex("^[0-9]*$");
            if (!idcard.IsMatch(this.TbID.Value))
            {
                JsMessage.jsAlert("编号只能为数字！");
                return;
            }
            List<U_User> user = new UserBll().U_SelAllUserInfoByIDs(id);
            CollectionPager1.DataSource = user;
            CollectionPager1.BindToControl = GvUserInfo;
            this.GvUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.GvUserInfo.DataBind();
            this.TbID.Value = "";
        }
        /// <summary>
        /// 通过部门信息进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDdl_Click(object sender, EventArgs e)
        {
            int did = int.Parse(this.DdlDepartements.SelectedValue.ToString());
            List<U_User> user = new UserBll().U_selAllUserInfoByDID(did);
            CollectionPager1.DataSource = user;
            CollectionPager1.BindToControl = GvUserInfo;
            this.GvUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.GvUserInfo.DataBind();
        }
        /// <summary>
        /// 通过员工名字进行模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByName_Click(object sender, EventArgs e)
        {
            string name = this.TbName.Value.Trim();
            if (string.IsNullOrEmpty(this.TbName.Value))
            {
                JsMessage.jsAlert("用户名信息不能为空!");
                return;
            }
            List<U_User> user = new UserBll().U_SelAllUserInfoByNames(name);
            CollectionPager1.DataSource = user;
            CollectionPager1.BindToControl = GvUserInfo;
            this.GvUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.GvUserInfo.DataBind();
            this.TbName.Value = "";
        }
    }
}