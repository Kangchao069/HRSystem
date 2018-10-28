<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H_SelAllResigntions.aspx.cs" Inherits="WebUI.HR.H_SelAllResigntions" %>

<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/Tables.css" />
    <style type="text/css">
        .button {
            height: 32px;
            background-color: #37b5ed;
            border: 0px solid #37b5ed;
            color: white;
            width: 80px;
        }

        .button2 {
            height: 32px;
            background-color: #ff0000;
            border: 0px solid #37b5ed;
            color: white;
            width: 80px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        
        function selectAll(ctlName,bool)
        {
            var ctl = document.getElementById(ctlName);//根据控件的在客户端所呈现的ID获取控件
            var checkbox = ctl.getElementsByTagName('input');//获取该控件内标签为input的控件
            /*所有Button、TextBox、CheckBox、RadioButton类型的服务器端控件在解释成Html控件后，都为<input type=''./>，通过type区分它们的类型。*/
            for(var i=0;i<checkbox.length;i++)
            {
                if(checkbox[i].type=='checkbox')
                {
                    checkbox[i].checked = bool;
                }
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
            <table class="table1">
                <tr>
                    <td colspan="2" align="center">
                        <h2>员工辞职信息</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="td">根据编号查询</span>
                        <input runat="server" id="TbUid" type="text" class="TextBoxs" placeholder="请输入用户编号关键字" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="16" />
                        <asp:Button runat="server" ID="BtnSelByID" Text="查询" OnClick="BtnSelByID_Click" CssClass="button" />
                    </td>
                    <td>
                        <span class="td">根据部门查询</span>
                        <asp:DropDownList runat="server" ID="DdlDid" Width="180" Height="30"></asp:DropDownList>
                        <asp:Button runat="server" ID="BtnSelByDid" Text="查询" OnClick="BtnSelByDid_Click" CssClass="button" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="td">根据名字查询</span>
                        <input runat="server" id="TbName" type="text" class="TextBoxs" placeholder="请输入用户名关键字" />
                        <asp:Button runat="server" ID="BtnSelByName" Text="查询" OnClick="BtnSelByName_Click" CssClass="button" />
                    </td>
                    <td align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="BtnDel" Text="删除" OnClick="BtnDel_Click" CssClass="button2" OnClientClick="return confirm('确定要删除吗？该操作不可恢复！！！')" />
                        <tr>
                            <td colspan="2" align="center">
                                <asp:GridView runat="server" ID="GvResignation" AutoGenerateColumns="false" OnRowDeleting="GvResignation_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                全选<input type="checkbox" id="CheckBox2"
                                                    onclick="javascript: selectAll('GvResignation', this.checked);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" id="ctlName" value='<%# Bind("RID")%>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="员工编号">
                                            <ItemStyle Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LbUid" Text='<%# Bind("UID.UID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="员工名称">
                                            <ItemStyle Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LbName" Text='<%# Bind("UID.UserName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="所属部门">
                                            <ItemStyle Width="100px" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LbDid" Text='<%# Bind("DID.DName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="辞职原因">
                                            <ItemStyle Width="160px" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LbReason" Text='<%# Bind("Reason")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="辞职时间">
                                            <ItemStyle Width="160px" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LbTime" Text='<%# Bind("Time")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="备注">
                                            <ItemStyle Width="120px" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LbRemark" Text='<%# Bind("Remark")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="用户状态">
                                            <ItemStyle Width="100px" ForeColor="Red" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="LbState" Text='<%# Bind("UID.State")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField HeaderText="操作" ShowDeleteButton="true" ControlStyle-ForeColor="red" DeleteText="停用">
                                            <ItemStyle Width="40px" />
                                            <ControlStyle ForeColor="Red"></ControlStyle>
                                        </asp:CommandField>
                                    </Columns>
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#E2F3FA" Font-Bold="True" ForeColor="Black" />
                                </asp:GridView>
                                <div class="pageLink" id="pageLink" align="center">
                                    <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextLinkSeparator=" "
                                        BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersSeparator="-"
                                        PageSize="6" ShowFirstLast="true" ShowPageNumbers="true">
                                    </cc1:CollectionPager>
                                </div>
                            </td>
                        </tr>
            </table>

        </div>
    </form>
</body>
</html>
