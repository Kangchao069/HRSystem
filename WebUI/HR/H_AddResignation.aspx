<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H_AddResignation.aspx.cs" Inherits="WebUI.HR.H_AddResignation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="stylesheet" href="../Css/U_UserLeaveAdd.css" />
    <link  type="text/css" rel="stylesheet" href="../Js/jqueryui/jquery-ui.css"/>
    <script src="../Js/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../Js/jqueryui/jquery-ui.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    
            <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <div align="center">
      <table class="tables">
           <tr>
               <td colspan="4" align="center">
                   <h2>编写辞职信息</h2>
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
                   辞职原因:
               </td>
               <td colspan="3">
                   <asp:TextBox runat="server" ID="TbReason" TextMode="MultiLine" Width="628" Height="160" onblur="clic(this.id)"></asp:TextBox>
                   <asp:Label runat="server" ID="LbReason" CssClass="lblshow"><img src="../Image/false.gif" />请假原因不能为空！</asp:Label>
               </td>
           </tr>
           <tr width="200">
               <td class="td">
                   辞职时间:
               </td>
               <td height="60" width="251">
                   <asp:TextBox runat="server" ID="TbTime" CssClass="text" onblur="clic(this.id)"></asp:TextBox>
                   
                   <script type="text/javascript">
                            $(function () {
                                $("#<%= TbTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
                            });
                        </script>
                   <%--<asp:Label runat="server" ID="LbAoginTime" CssClass="lblshow" ><img src="../Image/false.gif" />时间不能为空!</asp:Label>--%>
               </td>
               <td class="td">
                   备注
               </td>
               <td>
                   <asp:TextBox runat="server" ID="TbRemark" CssClass="text"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td colspan="4" align="center" height="80">
                   <asp:Button runat="server" ID="BtnSubmission" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" Text="确认提交" OnClick="BtnSubmission_Click"  />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button  runat="server" ID="BtnClous" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" Text="重置信息" OnClick="BtnClous_Click" />
               </td>
           </tr>
       </table>
    </div>
    </form>
</body>
</html>
