<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H_UpdUserInfo.aspx.cs" Inherits="WebUI.HR.H_UpdUserInfo" %>

<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/Tables.css" />
    <style type="text/css">
        .button {
            height: 39px;
            background-color: #37b5ed;
            border: 0px solid #37b5ed;
            color: white;
            width: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div align="center">
            <div align="left">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
            </div>
            <table class="table1">
                <tr>
                    <td colspan="2" align="center">
                        <h2>员工信息维护</h2>
                    </td>
                </tr>
                <tr>
                    <td><span class="td">根据员工编号查询</span>
                        <input type="text" id="TbID" runat="server" class="TextBoxs" placeholder="请输入用户编号关键字" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="16" />
                        <asp:Button runat="server" ID="BtnSel" Text="查询" CssClass="button" OnClick="BtnSel_Click" /></td>
                    <td><span class="td">根据部门查询</span><asp:DropDownList runat="server" ID="DdlDepartements" Width="200" Height="40">
                        <%--<asp:ListItem Value="0">全部</asp:ListItem>--%>
                    </asp:DropDownList>
                        <asp:Button runat="server" ID="BtnDdl" Text="查询" CssClass="button" OnClick="BtnDdl_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="td">根据员工名字查询</span>
                        <input type="text" id="TbName" class="TextBoxs" runat="server" placeholder="请输入用户名字关键字" />
                        <asp:Button runat="server" ID="BtnSelByName" Text="查询" CssClass="button" OnClick="BtnSelByName_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView runat="server" ID="GvUserInfo" AutoGenerateColumns="false" BackColor="White" BorderColor="#3366CC" BorderStyle="none" BorderWidth="3px" OnRowCancelingEdit="GvUserInfo_RowCancelingEdit" OnRowDataBound="GvUserInfo_RowDataBound" OnRowDeleting="GvUserInfo_RowDeleting" OnRowEditing="GvUserInfo_RowEditing" OnRowUpdating="GvUserInfo_RowUpdating" Width="1029px">
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="../admin/M_SelUserInfoInformation.aspx?UID={0}"
                                    HeaderText="详细信息" Target="_blank" Text="&lt;img border=0 src='../Image/View.gif'">
                                    <ItemStyle Width="100px" />
                                </asp:HyperLinkField>

                                <asp:TemplateField HeaderText="用户编号">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>

                                        <asp:Label runat="server" ID="LbUID" Text='<%# Bind("UID") %>'></asp:Label>

                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                            <asp:HiddenField runat="server" ID="IDs" Value='<%# Bind("UID") %>' />
                            
                        </EditItemTemplate>--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="登录名">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="LbLoginName" Text='<%# Bind("LoginName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="登录密码">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="LbPassWord" Text='<%# Bind("LoginPassword") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户名">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="LbUserName" Text='<%# Bind("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户部门">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>
                                        <asp:HiddenField runat="server" ID="IDs" Value='<%# Bind("UID") %>' />
                                        <asp:Label runat="server" ID="LbDepartment" Text='<%# Bind("DID.DName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:HiddenField runat="server" ID="ID" Value='<%# Bind("UID") %>' />
                                        <asp:DropDownList runat="server" Width="100" ID="DdlDepartment"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户职务">
                                    <ItemStyle Width="100px" />
                                    <ItemTemplate>

                                        <asp:Label runat="server" ID="LbPost" Text='<%# Bind("PID.PName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>

                                        <asp:DropDownList runat="server" Width="100" ID="DdlPost"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户登录类型">
                                    <ItemStyle Width="130px" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="LbType" Text='<%# Bind("UTID.TypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList runat="server" ID="DdlType" Width="100"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField HeaderText="编辑" ShowEditButton="true" />

                                <asp:CommandField HeaderText="删除" ShowDeleteButton="true" ControlStyle-ForeColor="red" />
                            </Columns>
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#E2F3FA" Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                        <div class="pageLink" id="pageLink" align="center">
                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextLinkSeparator=" "
                                BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersSeparator="-"
                                PageSize="10" ShowFirstLast="true" ShowPageNumbers="true">
                            </cc1:CollectionPager>


                        </div>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
