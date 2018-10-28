using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class M_SetPermission : System.Web.UI.Page
    {
        U_User use = new U_User();
        //加载

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if ((U_User)Session["U_USER"] == null)
                {
                    Response.Redirect("../M_UserLogin.aspx");
                }
                DataFuzhi();
                BindCheckBoxState();
                
            }
        }
    public void BindCheckBoxState()
        {
            //获取所有checkBox
            List<HtmlInputCheckBox> hicb = Utils.ReadAllControls<HtmlInputCheckBox>(this.oneRepeater);



            int UTID = Convert.ToInt32(Request.QueryString["UTID"]);
            //遍历所有的CheckBox
            foreach (HtmlInputCheckBox item in hicb)
            {
                //获取被选中数据
                List<M_Permission> cc = new ManageBll().getCheckState(UTID);
                foreach (var yll in cc)
                {
                    if (yll.MID.MID == Convert.ToInt32(item.Value))
                    {
                        item.Checked = true;
                    }
                }
            }
        }
        /// <summary>
        /// 为一级Repeater赋值
        /// </summary>
        public void DataFuzhi()
        {
            DataTable dt = new ManageBll().BindPageName();

            this.oneRepeater.DataSource = dt;
            this.oneRepeater.DataBind();

        }
        /// <summary>
        /// 为二级Repeater赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void oneRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            try
            {
                int pid = Convert.ToInt32((e.Item.FindControl("hfPID") as HiddenField).Value);
                
                DataTable dt = new ManageBll().BindTwoPageName(pid);

                Repeater r = e.Item.FindControl("twoRepeater") as Repeater;

                r.DataSource = dt;
                r.DataBind();


            }
            catch
            {


            }
        }

        /// <summary>
        /// 关闭页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNo_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            
            //获取所有checkBox
            List<HtmlInputCheckBox> hicb = Utils.ReadAllControls<HtmlInputCheckBox>(this.oneRepeater);
            int UTID = Convert.ToInt32(Request.QueryString["UTID"]);


            //delete权限分配表UTD
            if (new ManageBll().DeletePageManageInfoByMTID(UTID) > 0)
                {

                    //遍历所有checkBox
                    foreach (HtmlInputCheckBox item in hicb)
                    {
                        if (item.ID == "cbPageName" && item.Checked)
                        {
                            //添加权限
                            new ManageBll().AddPageManageInfoByPIDMTID(UTID, Convert.ToInt32(item.Value));
                        }

                        if (item.Value == new ManageBll().getCheckState(UTID).ToString())
                        {
                            item.Checked.ToString();

                        }
                    }
                    use = (U_User)Session["U_USER"];
                    Model.M_JournalInfo ji = new Model.M_JournalInfo();
                    ji.Content = use.UserName + "进行权限分配！";
                    ji.ReleaseTime = DateTime.Now.ToLocalTime();
                    ji.LoginName = use.LoginName;
                    new UserBll().AddJournalInfo(ji);
                    Common.JsMessage.jsAlert("操作成功！请重新登录");
                }
                else
                {
                    Common.JsMessage.jsAlert("操作有误");
                }
            }
            //else
            //{
            //    Common.JsMessage.jsAlert("操作有误");
            //}



        }
    }
