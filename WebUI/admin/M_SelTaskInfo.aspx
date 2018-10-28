<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_SelTaskInfo.aspx.cs" Inherits="WebUI.admin.M_SelTaskInfo" %>

<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/Task.css" />
    <script type="text/javascript">
        function openwinEdit(text) {
            window.open("M_TaskInfoInformation.aspx?TID=" + text, null, "height=511,width=676,top=200,left=300,status=no,toolbar=no,menubar=no,location=no,resizable=no,scroll=no");

        }
    </script>
    
    <script language="javascript" type="text/javascript">
        function ToggleCheckAll(e, item) {
            var inputs = document.getElementsByTagName('input');
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox" && !inputs[i].disabled && (inputs[i].id.indexOf(item) > 0))
                    inputs[i].checked = e.checked;
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
            <table class="table">
                <tr>
                    <td align="center" colspan="2">
                        <h2>任务信息</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="tdss">根据部门查询</span>
                        <asp:DropDownList runat="server" ID="DdlDid" Width="160" Height="32"></asp:DropDownList>
                        <asp:Button runat="server" ID="BtnSelByDid" Text="查询" Style="height:32px;background-color : #37b5ed; border: 0px solid #37b5ed; color:white;width:80px;" OnClick="BtnSelByDid_Click" />
                        &nbsp;&nbsp;
                        <asp:Button runat="server" ID="BtnALL" Text="查询所有" Style="height:32px;background-color : #37b5ed; border: 0px solid #37b5ed; color:white;width:80px;" OnClick="BtnALL_Click"/>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="BtnDel" Text="删除" OnClientClick="return confirm('确定要删除吗？该操作不可恢复！！！')" OnClick="BtnDel_Click" Style="height:32px;background-color : red; border: 0px solid #37b5ed; color:white;width:140px;" />
                        <%--<span class="tdss">根据时间查询</span>
                        <asp:TextBox runat="server" ID="TbTime"></asp:TextBox>
                        <asp:Button runat="server" ID="BtnSelByTime" Text="查询" />--%>
                    </td>
                </tr>

                <tr>
                    <td align="center" colspan="2">
                        <asp:Repeater runat="server" ID="RTaskInfo">
                                <HeaderTemplate>
                        <table>
                                        <tr>
                                            <th class="tdss">详细信息
                                            </th>
                                            <th class="tdss"><input id="checkAll" name="checkAll" type="checkbox"   onclick="ToggleCheckAll(this,'chkItem');"/>全选


                                            </th>
                                            <th class="tdss">编号

                                            </th>
                                            <th class="tdss">任务名称
                                            </th>
                                            <th class="tdss">任务部门
                                            </th>
                                            <th class="tdss">发布时间
                                            </th>

                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        <tr>
                                            <td class="tds">
                                                <img src="../Image/View.gif" alt='<%# Eval("TID") %>' onclick="openwinEdit('<%# Eval("TID") %>')" />
                                            </td>
                                            <td class="tds">
                                                <%--<input type="checkbox" id="cbx" value='<%# Bind("TID")%>' runat="server" />--%>
                                                <%--<asp:CheckBox ID="cbx" runat="server"  />--%>
                                                <%--<asp:CheckBox ID="dd" runat="server" Text='<%# Bind("ID") %>' />--%>
                                                <%--<input name="Item" id="Item" type="checkbox" value='<%# Eval("TID") %>' runat="server"/>--%>
                                                <input type="checkbox" value='<%#Eval("TId") %>' runat="server" id="chkItem" />


                                            </td>
                                            <td class="tds">
                                                <%--<asp:HiddenField runat="server" ID="TID" Value='<%# Eval("TID") %>' />--%>
                                                <%--<%# Eval("TID") %>--%>
                                                <asp:Label runat="server" ID="lbl" Text='<%# Eval("TID") %>'></asp:Label>
                                            </td>

                                            <td class="tds">
                                                <%# Eval("TaskName") %>
                                            </td>

                                            <td class="tds">
                                                <%# Eval("DID.DName") %>
                                            </td>

                                            <td class="tds">
                                                <%# Eval("ReleaseTime") %>
                                            </td>
                                        </tr>
                                </ItemTemplate>
                            

                           <FooterTemplate>
                               </table>
                           </FooterTemplate>
                        </asp:Repeater>


                        <div class="pageLink" id="pageLink" align="center">
                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextLinkSeparator=" "
                                BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersSeparator="-"
                                PageSize="8" ShowFirstLast="true" ShowPageNumbers="true">
                            </cc1:CollectionPager>


                        </div>

                        
                    </td>
                </tr>
            </table>
                    </div>
    </form>
</body>
</html>
