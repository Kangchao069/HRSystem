<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_PerssionUserType.aspx.cs" Inherits="WebUI.admin.M_PerssionUserType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
            <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <div>
            <asp:GridView runat="server" ID="gvManageType" AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" GridLines="None" Height="127px" Width="825px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTypeDetail" Text='<%#Bind("TName") %>'></asp:Label>
                            <asp:HiddenField runat="server" ID="hfTypeDetail" Value='<%#Bind("UTID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="备注">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbRemark" Text='<%#Bind("Remark") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="../admin/M_SetPermission.aspx?UTID=<%#Eval("UTID") %>">权限分配</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
