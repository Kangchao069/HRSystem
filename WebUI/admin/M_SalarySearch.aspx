<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_SalarySearch.aspx.cs" Inherits="WebUI.admin.M_SalarySeach" %>

<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Css/salarySeach.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">

        <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
            </asp:SiteMapPath>
        </div>
        <div style="padding-bottom: 8px;">
            <asp:DropDownList Font-Size="14px" AutoPostBack="true" runat="server" ID="ddlKindUser" OnSelectedIndexChanged="ddlKindUser_SelectedIndexChanged">
                <asp:ListItem Value="1">按部门查询</asp:ListItem>
                <asp:ListItem Value="2">按姓名查询</asp:ListItem>
                <asp:ListItem Value="3">查询所有</asp:ListItem>
                <%--       <asp:ListItem Value="3">按时间查询</asp:ListItem>--%>
            </asp:DropDownList>
            &nbsp;
            <asp:DropDownList Font-Size="14px" AutoPostBack="true" runat="server" ID="ddlDepartment">
            </asp:DropDownList>

            <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnSeach" Text="查询" OnClick="btnSeach_Click" />
        </div>
        <div id="content">
            <asp:DataList ID="dlSalary" runat="server" CellPadding="4" ForeColor="#333333">
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderTemplate>
                    <table width="860px" border="0" cellpadding="1" cellspacing="2">
                        <tr>
                            <td class="tdcss">详情</td>
                            <td class="tdcss">用户编号</td>
                            <td class="tdcss">姓名</td>
                            <td class="tdcss">部门</td>
                            <td class="tdcss">日期</td>
                            <td class="tdcss">基本工资</td>
                            <td class="tdcss">奖金</td>
                            <td class="tdcss">考勤罚款</td>
                            <td class="tdcss">总计</td>
                        </tr>
                    </table>
                </HeaderTemplate>

                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />

                <ItemTemplate>
                    <table width="860px" border="0" cellpadding="1" cellspacing="2">
                        <tr>
                            <td class="tdcss"><a href="M_SalaryDetail.aspx?UID=<%#Eval("UID")%>&month=<%#Eval("Month") %>">
                                <img src="../Image/View.gif" /></a>
                            </td>
                            <td class="tdcss">
                                <input id="hdUID" type="hidden" runat="server" value='<%#Eval("UID") %>' /><%#Eval("UID") %></td>
                            <td class="tdcss"><%#Eval("UserName") %></td>
                            <td class="tdcss"><%#Eval("Dname") %></td>
                            <td class="tdcss"><%#Convert.ToDateTime(Eval("Month")).ToShortDateString() %></td>
                            <td class="tdcss"><%#Eval("Salary") %></td>
                            <td class="tdcss"><%#Eval("Bonus") %></td>
                            <td class="tdcss"><%#Eval("AttendFine") %></td>
                            <td class="tdcss"><%#Eval("Total") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
            <div style="text-align:center;width:860px;">
                <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextLinkSeparator=" "
                    BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersSeparator="-"
                    PageSize="6" ShowFirstLast="true" ShowPageNumbers="true">
                </cc1:CollectionPager>
            </div>
    </form>
</body>
</html>
