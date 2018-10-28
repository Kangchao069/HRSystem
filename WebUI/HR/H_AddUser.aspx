<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H_AddUser.aspx.cs" Inherits="WebUI.HR.H_AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/U_UserLeaveAdd.css" />
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
            <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
       <table style="border:1px solid #808080" class="table">
           <tr>
               <td colspan="4">
                   <h2 align="center">用户添加</h2>
               </td>
           </tr>
           <tr>
               <td class="td">
                   用户姓名:
               </td>
               <td>
                   <input type="text" runat="server" id="TbUserName" class="text" placeholder="请输入用户姓名" />
               </td>
               <td class="td">
                   登录名
               </td>
               <td>
                   <input type="text" runat="server" id="TbLoginName" class="text" placeholder="请输入用户登录名" />
               </td>
           </tr>
           <tr>
               <td class="td">
                   部门
               </td>
               <td>
                   <%--<input type="text" runat="server" id="TbDeparment" />--%>
                   <asp:DropDownList runat="server" ID="DdlDeparment" CssClass="text"></asp:DropDownList>
               </td>
               <td class="td">
                   职务:
               </td>
               <td>
                   <%--<input type="text" runat="server" id="TbPost" />--%>
                   <asp:DropDownList runat="server" ID="DdlPost" CssClass="text"></asp:DropDownList>
               </td>
           </tr>
           <tr>
               <td class="td">
                   学历:
               </td>
               <td class="auto-style1">
                   <%--<input type="text" runat="server" id="TbEducation" />--%>
                   <asp:DropDownList runat="server" ID="DdlEducation" CssClass="text"></asp:DropDownList>
               </td>
               <td class="td">
                   用户类型:
               </td>
               <td>
                   <asp:DropDownList runat="server" ID="DdlType" CssClass="text"></asp:DropDownList>
               </td>
               
           </tr>
           <tr>
               <td class="td">
                   性别:
               </td>
               <td>
                   <asp:DropDownList runat="server" ID="DdlSex" CssClass="texts">
                       <asp:ListItem Value="1">男</asp:ListItem>
                       <asp:ListItem Value="2">女</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td class="td">
                   毕业学院:
               </td>
               <td class="auto-style1">
                   <input type="text" runat="server" id="TbAcademy" class="text" placeholder="请输入毕业学院" />
               </td>
               
           </tr>
           <tr>
               <td class="td">
                   电话号码:
               </td>
               <td>
                   <input type="text" class="text" runat="server" id="TbPhone" placeholder="请输入电话号码" />
               </td>
               <td class="td">
                   Email:
               </td>
               <td>
                   <input class="text" type="text" runat="server" id="TbEmail" placeholder="请输入邮箱" />
               </td>
           </tr>
           <tr>
               <td rowspan="2" class="td">
                   详细信息:
               </td>
               <td rowspan="2">
                   <%--<input type="text" style="width:220px;height:80px;" TextMode="MultiLine" runat="server" id="TbDetail" />--%>
                   <asp:TextBox runat="server" TextMode="MultiLine" Width="220" Height="80" ID="TbDetail" placeholder="请输入个人详细信息"></asp:TextBox>
               </td>
               <td class="td">
                   身份证号码:
               </td>
               <td>
                   <input type="text" class="text" runat="server" id="TbIdCard" placeholder="请输入身份证号码" />
               </td>
           </tr>
           <tr>
               <td class="td">
                   住址:
               </td>
               <td>
                   <input type="text" class="text" runat="server" id="TbAddress" placeholder="请输入个人住址" />
               </td>
               
               
           </tr>
           <tr>
               <td class="td">
                   备注
               </td>
               <td>
                   <input type="text" class="text" runat="server" id="TbRemark" placeholder="请输入备注信息" />
               </td>
           </tr>
           <tr>
               <td colspan="4" align="center" height="120">
                   <asp:Button runat="server" ID="BtnAdd" Text="确认添加" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnAdd_Click" />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button runat="server" ID="BtnClous" Text="重置信息" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;"  />
               </td>
           </tr>
       </table>
    </div>
    </form>
</body>
</html>
