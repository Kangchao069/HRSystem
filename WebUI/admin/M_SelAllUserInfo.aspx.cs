using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.admin
{
    public partial class M_SelAllUserInfo : System.Web.UI.Page
    {
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                if ((U_User)Session["U_USER"] == null)
                {
                    Response.Redirect("../M_UserLogin.aspx");
                }
                bind();
                Department();
                
            }
        }
        /// <summary>
        /// 创建一个方法查询用户数据
        /// </summary>
        public void bind()
        {
            List<U_User> user = new UserBll().U_SelAllUserInfo();
            CollectionPager1.DataSource = user;
            CollectionPager1.BindToControl = RpUserInfo;
            this.RpUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.RpUserInfo.DataBind();            
        }
        /// <summary>
        /// 为部门名称赋值
        /// </summary>
        public void Department()
        {
            //绑定部门名称
            this.DdlDepartement.DataSource = new UserBll().U_SelDepartment();
            this.DdlDepartement.DataTextField = "DName";
            this.DdlDepartement.DataValueField = "DID";
            this.DdlDepartement.DataBind();

        }
       
        /// <summary>
        /// 模糊查询用户数据
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
            CollectionPager1.BindToControl = RpUserInfo;
            this.RpUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.RpUserInfo.DataBind();
            this.TbID.Value = "";
        }
        /// <summary>
        /// 根据员工名字信息进行迷糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSelByName_Click(object sender, EventArgs e)
        {
            string name = this.TbName.Value.Trim();
            if (string.IsNullOrEmpty(this.TbName.Value))
            {
                JsMessage.jsAlert("员工名字信息不能为空!");
                return;
            }
            List<U_User> user = new UserBll().U_SelAllUserInfoByNames(name);
            CollectionPager1.DataSource = user;
            CollectionPager1.BindToControl = RpUserInfo;
            this.RpUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.RpUserInfo.DataBind();
            this.TbName.Value = "";
        }
       
        /// <summary>
        /// 通过部门查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDdl_Click(object sender, EventArgs e)
        {
            int did = int.Parse(this.DdlDepartement.SelectedValue.ToString());
            List<U_User> user = new UserBll().U_selAllUserInfoByDID(did);
            CollectionPager1.DataSource = user;
            CollectionPager1.BindToControl = RpUserInfo;
            this.RpUserInfo.DataSource = CollectionPager1.DataSourcePaged;
            this.RpUserInfo.DataBind();
        }
    }
}