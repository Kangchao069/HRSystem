<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H_SelLeaveInfo.aspx.cs" Inherits="WebUI.HR.H_SelLeaveInfo" %>
<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/Task.css" />
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
                    <td align="center" colspan="2" class="auto-style1">
                        <h2>请假信息</h2>
                    </td>
                </tr>
           <tr>
               <td>
                   <span class="tdss">
                       根据编号查询
                   </span>
                   <input type="text" runat="server" id="TbNumber"  style="width:200px;height:32px;" placeholder="请输入用户编号关键字!" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="16" />
                   <asp:Button runat="server" ID="BtnSelByID" Text="查询" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnSelByID_Click" />
               </td>
               <td>
                   <span class="tdss">
                       根据部门查询
                   </span>
                   <%--<input type="text" runat="server" id="TbD" style="width:200px;height:24px;" />--%>
                   <asp:DropDownList runat="server" ID="DdlD" Width="180" Height="32"></asp:DropDownList>
                   <asp:Button runat="server" ID="BtnSelByD" Text="查询" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnSelByD_Click" />
               </td>
           </tr>
           <tr>
               <td>
                   <span class="tdss">
                       根据名字查询
                   </span>
                   <input type="text"  runat="server" id="TbName" style="width:200px;height:32px;" placeholder="请输入用户名关键字"/>
                   <asp:Button runat="server" ID="BtnSelByName" Text="查询" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnSelByName_Click" />
               </td>
               <td>
                   
                   <asp:Button runat="server" ID="BtnDel" Text="选择删除" style="height:39px;background-color :red; border: 0px solid #37b5ed; color:white; width:180px; margin-left:315px;" OnClientClick="return confirm('确定要删除吗？该操作不可恢复！！！')" OnClick="BtnDel_Click" />
               </td>
           </tr>
                <tr>
                    <td align="center" colspan="2">
                        <table>
                            <thead>
                                <tr>
                                    <th class="tdss">
                                        <input id="checkAll" name="checkAll" type="checkbox"   onclick="ToggleCheckAll(this,'chkItem');"/>全选
                                    </th>
                                    <th class="tdss">
                                        编号

                                    </th>
                                    <th class="tdss">
                                        用户编号
                                    </th>
                                    <th class="tdss">
                                        用户名
                                    </th>
                                    <th class="tdss">
                                        用户部门
                                    </th>
                                    <th class="tdsss">
                                        原因
                                    </th>
                                    <th class="tdsss">
                                        开始时间
                                    </th>
                                    <th class="tdsss">
                                        结束时间
                                    </th>

                                </tr>

                            </thead>
                            <tbody>

                                <asp:Repeater runat="server" ID="RLeave">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="tds">
                                                <input type="checkbox" value='<%#Eval("LId") %>' runat="server" id="chkItem" />
                                            </td>
                                            <td class="tds">
                                                <%--<asp:HiddenField runat="server" ID="TID" Value='<%# Eval("TID") %>' />--%>
                                                <%# Eval("LID") %>
                                            </td>
                                            <td class="tds">
                                                <%# Eval("UID.UID") %>
                                            </td>

                                            <td class="tds">
                                                <%--<a onclick="openwinEdit('<%# Eval("UID.UserName") %>')">--%><%# Eval("UID.UserName") %></a>
                                            </td>

                                            <td class="tds">
                                                <%# Eval("DID.DName") %>
                                            </td>

                                            <td class="tds">
                                                <%# Eval("LReason") %>
                                            </td>
                                            <td class="time">
                                                <%# Eval("BeginTime") %>
                                            </td>
                                            <td class="time">
                                                <%# Eval("EndTime") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>


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
