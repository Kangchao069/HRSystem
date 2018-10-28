<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_TaskInfoAdd.aspx.cs" Inherits="WebUI.admin.M_TaskInfoAdd" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="stylesheet" href="../Css/U_UserLeaveAdd.css" />

    <script src="../kindeditor/kindeditor-all-min.js" type="text/javascript" charset="utf-8"></script>
    <script src="../kindeditor/lang/zh-CN.js" type="text/javascript" charset="utf-8"></script>
    <script src="../kindeditor/plugins/code/prettify.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">

        KindEditor.ready(function (K) {

            var editor1 = K.create('#TbContent', {//注意此处的ID和上一步的ID保持一致

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
    <div align="center">
            <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
       <table class="tabless">
           <tr>
               <td colspan="4" align="center">
                   <h2>任务发布</h2>
               </td>
           </tr>
           <tr>
               <td class="td">
                   任务名称:
               </td>
               <td width="360">
                   <asp:TextBox runat="server" ID="TbTaskName" CssClass="texts" onblur="clic(this.id)"></asp:TextBox>
                   <asp:Label runat="server" ID="LbTaskName" CssClass="lblshow"><img src="../Image/false.gif" />任务名称不能为空！</asp:Label>
               </td>
               <td class="td">
                   任务类型:
               </td>
               <td>
                  <asp:DropDownList runat="server" ID="DdlDID" CssClass="text"></asp:DropDownList>
                   
               </td>
           </tr>
           
           <tr>
               <td class="td">
                   任务内容:
               </td>
               <td colspan="3">
                   <asp:TextBox runat="server" ID="TbContent" TextMode="MultiLine" Width="750" Height="200"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="td">
                  备注:
               </td>
               <td colspan="3">
                   <asp:TextBox runat="server" ID="TbRemark" Width="750" Height="70" TextMode="MultiLine"></asp:TextBox>
                   
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
