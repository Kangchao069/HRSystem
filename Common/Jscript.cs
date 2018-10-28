﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    /// <summary>
    /// 一些常用的Js调用
    /// <summary>
    public class Jscript
    {

        /// 弹出JavaScript小窗口
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void Alert(string message)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    alert('" + message + "');</Script>";
            HttpContext.Current.Response.Write(js);

            #endregion
        }

        /// <summary>
        /// 弹出JavaScript小窗口,并返回上一步
        /// </summary>
        /// <param name="message">窗口信息</param>
        public static void AlertAndGoBack(string message)
        {
            string js = @"<Script language='JavaScript'>
                    alert('" + message + "');history.go(-1);</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 运行JS代码
        /// </summary>
        /// <param name="ScriptCode">脚本代码</param>
        public static void RunJs(string ScriptCode)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    " + ScriptCode + ";</Script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }

        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            #endregion
        }

        //public static void AlertForSave(string message)
        //{
        //    string RamCode = StrHelp.GetRamCode();
        //    string Url = HttpContext.Current.Request.Url.ToString();
        //    if (Url.IndexOf('?') > 0)
        //        Url = string.Format("{0}&RamCode={1}", Url, RamCode);
        //    else
        //        Url = string.Format("{0}?RamCode={1}", Url, RamCode);

        //    string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
        //    HttpContext.Current.Response.Write(string.Format(js, message, Url));
        //}

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
            #endregion
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            #region
            string js = @"<Script language='JavaScript'>
                    parent.opener=null;window.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
            #endregion
        }

        /// <summary>
        /// 关闭当前窗口并且返回值
        /// </summary>
        public static void CloseWindowReturnValues(string value)
        {
            #region

            System.Text.StringBuilder Str = new System.Text.StringBuilder();
            Str.Append("<Script language='JavaScript'type=\"text/javascript\">");
            Str.Append("var str='" + value + "';");
            Str.Append("top.returnValue=str;");
            Str.Append("top.close();</Script>");

            HttpContext.Current.Response.Write(Str.ToString());
            HttpContext.Current.Response.End();
            #endregion
        }


        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent(string url)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    window.opener.location.href='" + url + "';window.close();</Script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            #region
            string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
        {
            #region
            string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

            HttpContext.Current.Response.Write(js);
            #endregion
        }


        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">连接地址</param>
        public static void JavaScriptLocationHref(string url)
        {
            #region
            string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
            #endregion
        }

        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">连接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">距离上位置</param>
        /// <param name="left">距离左位置</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
            #endregion
        }

        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }

        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            #region
            string js = @"<script language=javascript>							
							showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
            #endregion
        }

        #region 以下函数在页面上引用AJAX组件后,调用的启动脚本
        /// <summary>
        /// Ajax启动脚本 For 引用AJAX组件的页
        /// AjaxAlert:弹出对话框
        /// </summary>
        /// <param name="page">一般是this</param>
        /// <param name="msg">对话框提示串</param>
        public static void AjaxAlert(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("alert('{0}！')", msg), true);
        }

        /// <summary>
        /// Ajax启动脚本 For 引用AJAX组件的页
        /// 弹出对话框并跳转到URL页
        /// </summary>
        /// <param name="page">一般是this</param>
        /// <param name="msg">对话框提示串</param>
        /// <param name="url">跳往的地址</param>
        public static void AjaxAlertAndLocationHref(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("alert('{0}！');location.href='{1}';", msg, url), true);

        }
        /// <summary>
        /// Ajax启动脚本 For 引用AJAX组件的页
        /// JS语句
        /// </summary>
        /// <param name="page">一般是this</param>
        /// <param name="js">如alert('test');</param>
        public static void AjaxRunJs(System.Web.UI.Page page, string js)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("{0}", js), true);
        }

        /// <summary>
        /// Ajax启动脚本 For 引用AJAX组件的页
        /// JS语句
        /// </summary>
        /// <param name="page">一般是this</param>
        /// <param name="js">如alert('test');</param>
        public static void AjaxEndRunJs(System.Web.UI.Page page, string js)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "ajaxjs", string.Format("{0}", js), true);
        }


        /// <summary>
        /// Ajax启动脚本 For 引用AJAX组件的页
        /// 转向到新的URL
        /// </summary>
        /// <param name="page">一般是this</param>
        /// <param name="toURL">连接地址</param>
        public static void AjaxRedirect(System.Web.UI.Page page, string toURL)
        {
            #region
            page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("window.location.replace('{0}');", toURL), true);
            #endregion
        }

        /// <summary>
        ///  Ajax启动脚本 For 引用AJAX组件的页
        /// 显示模态窗口
        /// </summary>
        /// <param name="page">一般是this</param>
        /// <param name="webFormUrl">弹出的页面地址</param>
        /// <param name="width">弹出页面的宽度</param>
        /// <param name="height">弹出页面的高度</param>
        public static void AjaxShowModalDialogWindow(System.Web.UI.Page page, string webFormUrl, int width, int height)
        {
            #region

            string CommandStr = "window.showModalDialog('{0}','tempdialog','dialogWidth:{1}px;dialogHeight:{2}px;center:yes;help=no;resizable:no;status:no;scroll=no')";
            CommandStr = string.Format(CommandStr, webFormUrl, width, height);
            page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", CommandStr, true);
            #endregion
        }

        #endregion


        /// <summary>
        /// 发生错误页面
        /// </summary>
        /// <param name="errStr">错误代码</param>
        public static void ToError(System.Web.UI.Page page, string errStr)
        {
            page.Response.Redirect(string.Format("Error.aspx?ErrStr={0}", errStr));
        }

        public static void BindDateCalendar(System.Web.UI.WebControls.TextBox txtDate)
        {
            txtDate.Attributes.Add("onclick", "setday(this)");
        }

        /// <summary>
        /// 设定Checkbox控制TextBox事件,
        /// </summary>
        /// <param name="ChkObj">Checkbox控件</param>
        /// <param name="HtmlObjId">控件TextBox ID,多个ID以,号分开</param>
        public static void SetChkAttrib(System.Web.UI.WebControls.CheckBox ChkObj, string HtmlObjId)
        {
            #region
            string[] StrId = HtmlObjId.Split(',');
            string JsCode = "";
            for (int i = 0; i < StrId.Length; i++)
            {
                JsCode = JsCode + string.Format("EnableCtrl(this,'{0}');", StrId[i]);
            }
            ChkObj.Attributes.Add("onclick", JsCode);
            #endregion
        }
    }
}
