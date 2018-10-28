<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_SelUserInfoInformation.aspx.cs" Inherits="WebUI.admin.M_SelUserInfoInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/Tables.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="border:0px solid #cccdcf;" class="table2">
            <tr>
                <td colspan="4" align="center">
                    <h2>员工详细信息</h2>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;编&nbsp;号:
                </td>
                <td>
                    
                    <asp:Label runat="server" ID="LbNumber" CssClass="TextBoxs"></asp:Label>
                    
                </td>
                <td class="td">
                    &nbsp;用户名:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbName" CssClass="TextBoxs"></asp:Label>
                </td>                
            </tr>

            <tr>
                <td class="td">
                    &nbsp;职&nbsp;务:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbPost" CssClass="TextBoxs"></asp:Label>
                </td>
               <td class="td">
                   &nbsp;类&nbsp;型:
               </td>
                <td>
                    <asp:Label runat="server" ID="LbUserType" CssClass="TextBoxs"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="td">
                    &nbsp;部&nbsp;门:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbDepartment" CssClass="TextBoxs"></asp:Label>
                </td>
                <td class="td">
                    联系方式:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbPhone" CssClass="TextBoxs"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;学&nbsp;历:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbEducation" CssClass="TextBoxs"></asp:Label>
                </td>
                <td class="td">
                    毕业院校:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbAcademy" CssClass="TextBoxs"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;性&nbsp;别:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbSex" CssClass="TextBoxs"></asp:Label>
                </td>
                <td class="td" style="text-align:center;" rowspan="2">
                    个人介绍:
                </td>
                <td style="width:280px;height:60px;" rowspan="2">
                    <asp:Label runat="server" ID="LbDetails" CssClass="mils" ></asp:Label>
                    <%--<asp:TextBox runat="server"  TextMode="MultiLine" Width="380" Height="100"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;Email:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbEmail" CssClass="TextBox"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="td">
                    &nbsp;住&nbsp;址:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbAddress" CssClass="TextBox"></asp:Label>
                </td>
                <td class="td">
                    身份证号:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbIDCard" CssClass="TextBox"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="td">
                    &nbsp;备&nbsp;注:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbRemake" CssClass="TextBox"></asp:Label>
                </td>
                <td class="td">
                    用户状态
                </td>
                <td>
                    <asp:Label runat="server" ID="lbstate" CssClass="state"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" >
                    <asp:Button runat="server" ID="BtnUpdState" Text="停用用户" style="height:39px;background-color : red; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnUpdState_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="BtnHf" Text="恢复用户" style="height:39px;background-color : #37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnHf_Click" />
                </td>
            </tr>

        </table>
    </div>
    </form>
</body>
</html>
