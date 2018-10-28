<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_SelAllUserInfo.aspx.cs" Inherits="WebUI.admin.M_SelAllUserInfo" %>

<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/Tables.css" />
    <style type="text/css">
        .button{
            height:39px;
        background-color : #37b5ed; border: 0px solid #37b5ed;
         color:white;
         width:80px;
        }
    </style>
    <script type="text/javascript">
        function openwinEdit(text) {
            window.open("M_SelUserInfoInformation.aspx?UID=" + text, null, "height=580,width=960,top=100,left=320,status=no,toolbar=no,menubar=no,location=no,resizable=no,scroll=no");

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
                    <td colspan="2" align="center">
                        <h2>员工信息</h2>
                    </td>
                </tr>
                <tr>
                    <td><span class="td">根据员工编号查询</span>
                        <input type="text" id="TbID" runat="server" class="TextBoxs" placeholder="请输入用户编号关键字" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="16" />
                        <asp:Button runat="server" ID="BtnSel" Text="查询" CssClass="button" OnClick="BtnSel_Click" /></td>
                    <td><span class="td">根据部门查询</span><asp:DropDownList runat="server" ID="DdlDepartement" Width="200" Height="40">
                        <%--<asp:ListItem Value="0">全部</asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:Button  runat="server" ID="BtnDdl" Text="查询" CssClass="button" OnClick="BtnDdl_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="td">根据员工名字查询</span>
                        <input type="text"  id="TbName" class="TextBoxs" runat="server" placeholder="请输入用户名关键字"/>
                        <asp:Button runat="server" ID="BtnSelByName" Text="查询" CssClass="button" OnClick="BtnSelByName_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table>
                            <thead>
                                <tr>
                                    <th class="th">
                                        详细信息
                                    </th>
                                    <th class="th">员工编号
                                    </th>
                                    <th class="th">员工名字
                                    </th>

                                    <th class="th">员工部门
                                    </th>
                                    <th class="th">员工职务
                                    </th>
                                    <th class="th">联系方式
                                    </th>
                                    <th class="th">家庭地址
                                    </th>
                                    <th class="th">Email
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RpUserInfo">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <img src="../Image/View.gif"  alt="'<%# Eval("UID") %>'" onclick="openwinEdit('<%# Eval("UID") %>')"/>
                                            </td>
                                            <td>
                                                <a onclick="openwinEdit('<%# Eval("UID") %>')"><%# Eval("UID") %></a>
                                            </td>
                                            <td>
                                                <%# Eval("UserName") %>
                                            </td>
                                            <td>
                                                <%# Eval("DID.DName") %>
                                            </td>
                                            <td>
                                                <%# Eval("PID.PName") %>
                                            </td>
                                            <td>
                                                <%# Eval("Phone") %>
                                            </td>
                                            <td>
                                                <%# Eval("Address") %>
                                            </td>
                                            <td>
                                                <%# Eval("Email") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>

                        </table>
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
