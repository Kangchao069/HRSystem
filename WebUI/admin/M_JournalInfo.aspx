<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_JournalInfo.aspx.cs" Inherits="WebUI.admin.M_JournalInfo" %>

<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/U_UserLeaveAdd.css" />
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
            <table class="tables">
                <tr>
                    <td align="center" colspan="2">
                        <h2>系统日志</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="td">根据用户名查询</span>
                        <input runat="server" id="TbName" type="text" class="text" />
                        <asp:Button runat="server" ID="BtnName" Text="查询" OnClick="BtnName_Click" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:100px;" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="BtnDel" Text="批量删除" OnClientClick="return confirm('确定要删除吗？该操作不可恢复！！！')" style="height:39px;background-color :red; border: 0px solid #37b5ed; color:white; width:100px;margin-left:140px;" OnClick="BtnDel_Click" />
                    </td>
                    <%--<td>
                        根据时间查询
                        <input type="text" runat="server" id="TbTime" />
                        <asp:Button runat="server" ID="BtnTime" Text="查询" OnClick="BtnTime_Click" />
                    </td>--%>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView runat="server" ID="GvJournal" AutoGenerateColumns="false" OnRowDeleting="GvJournal_RowDeleting" Width="758px">
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="60px" />
                        <HeaderTemplate >
                                  全选<input type="checkbox"  id="CheckBox2" 
                              onclick="javascript: selectAll('GvJournal', this.checked);"/>
                              </HeaderTemplate>
                              <ItemTemplate>                                  
                                  <input type="checkbox" id="ctlName" value='<%# Bind("JID")%>' runat="server" />
                              </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="编号">
                        <ItemStyle Width="80px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LbNumber" Text='<%# Bind("JID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户名">
                        <ItemStyle Width="80px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LbName" Text='<%# Bind("LoginName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="时间">
                        <ItemStyle Width="180px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LbTime" Text='<%# Bind("ReleaseTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="内容">
                        <ItemStyle Width="280px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LbContent" Text='<%# Bind("Content") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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
                    PageSize="15" ShowFirstLast="true" ShowPageNumbers="true">
                </cc1:CollectionPager>


            </div>
                    </td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
