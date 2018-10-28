<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="U_UserLeaveAdd.aspx.cs" Inherits="WebUI.Users.U_UserLeaveAdd" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <link type="text/css" rel="stylesheet" href="../Css/U_UserLeaveAdd.css" />
    <link  type="text/css" rel="stylesheet" href="../Js/jqueryui/jquery-ui.css"/>
    <script src="../Js/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Js/jqueryui/jquery-ui.min.js" type="text/javascript"></script>

    <link href="../kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="../kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />

    <script src="../kindeditor/kindeditor-all-min.js" type="text/javascript" charset="utf-8"></script>
    <script src="../kindeditor/lang/zh-CN.js" type="text/javascript" charset="utf-8"></script>
    <script src="../kindeditor/plugins/code/prettify.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">

        KindEditor.ready(function (K) {

            var editor1 = K.create('#TbReason', {//注意此处的ID和上一步的ID保持一致

                cssPath: '../kindeditor/plugins/code/prettify.css',

                uploadJson: '../kindeditor/asp.net/upload_json.ashx',

                fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',

                allowFileManager: true,

                afterCreate: function () {

                    var self = this;

                    K.ctrl(document, 13, function () {

                        self.sync();

                        K('form[name=example]')[0].submit();

                    });

                    K.ctrl(self.edit.doc, 13, function () {

                        self.sync();

                        K('form[name=example]')[0].submit();

                    });

                }

            });

            prettyPrint();

        });
        //非空验证
        function clic(dd) {
            var T = dd.substr(1);
            var kt = document.getElementById(dd).value;

            if (kt == "") {
                var kl = "L" + T;
                document.getElementById(kl).style.display = "block";
            }
            else {
                var kl = "L" + T;
                document.getElementById(kl).style.display = "none";
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
       <table class="table">
           <tr>
               <td colspan="4" align="center">
                   <h2>编写请假信息</h2>
               </td>
           </tr>
           <tr>
               <td class="td">
                   请假人:
               </td>
               <td>
                   <asp:Label runat="server" ID="LbUserName" CssClass="text"></asp:Label>
               </td>
               <td class="td">
                   所属部门:
               </td>
               <td>
                   <%--<asp:DropDownList runat="server" ID="DdlDepartment" CssClass="text"></asp:DropDownList>--%>
                   <asp:Label runat="server" ID="LbDid"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="td">
                   请假原因:
               </td>
               <td colspan="3">
                   <asp:TextBox runat="server" ID="TbReason" TextMode="MultiLine" Width="750" Height="200" onblur="clic(this.id)"></asp:TextBox>
                   <asp:Label runat="server" ID="LbReason" CssClass="lblshow"><img src="../Image/false.gif" />请假原因不能为空！</asp:Label>
               </td>
           </tr>
           <tr width="200">
               <td class="td">
                   请假开始时间:
               </td>
               <td height="60" width="251">
                   <asp:TextBox runat="server" ID="TbAoginTime" CssClass="text" onblur="clic(this.id)"></asp:TextBox>
                   
                   <script type="text/javascript">
                            $(function () {
                                $("#<%= TbAoginTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
                            });
                        </script>
                   <%--<asp:Label runat="server" ID="LbAoginTime" CssClass="lblshow" ><img src="../Image/false.gif" />时间不能为空!</asp:Label>--%>
               </td>
               <td class="td">
                   请假结束时间:
               </td>
               <td width="251">
                   <asp:TextBox runat="server" ID="TbEndTime" CssClass="text" onblur="clic(this.id)"></asp:TextBox>
                   <%--<asp:Label runat="server" ID="LbEndTime" CssClass="lblshow" ><img src="../Image/false.gif" />时间不能为空!</asp:Label>--%>
                   <script type="text/javascript">
                            $(function () {
                                $("#<%= TbEndTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
                            });
                        </script>
               </td>
           </tr>
           <tr>
               <td class="td">
                   备注
               </td>
               <td>
                   <asp:TextBox runat="server" ID="TbRemark" CssClass="text"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td colspan="4" align="center" height="80">
                   <asp:Button runat="server" ID="BtnSubmission" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" Text="确认提交" OnClick="BtnSubmission_Click" />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button  runat="server" ID="BtnClous" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" Text="重置信息" OnClick="BtnClous_Click"/>
               </td>
           </tr>
       </table>
    </div>
    </form>
</body>
</html>
