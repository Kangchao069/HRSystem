<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_SalaryDetailByUser.aspx.cs" Inherits="WebUI.admin.M_SalaryDetailByUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Css/salarySeach.css" rel="stylesheet" />
</head>
<body>
     <form runat="server">
         
            <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <div id="all">
            <div id="searchTime">
                请输入要查询的日期:
            <input runat="server" type="text" class="demo-input" placeholder="请选择日期" id="ipTime" />
                <asp:Button CssClass="btnstyle" runat="server" ID="btnSearch" Text="查询" OnClick="btnSearch_Click" />
            </div>
            <div id="detailInfo" cellpadding="0" cellspacin="0">
                <asp:Repeater ID="repBind" runat="server">
                    <ItemTemplate>
                        <table border="1px">
                            <tr>
                                <td class="widthfoName">员工姓名:</td>
                                <td>
                                    <%#Eval("UserName") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">日期:</td>
                                <td>
                                   <%#Eval("Month") %> <label runat="server" id="lblMonth"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">应发工资</td>
                                <td>
                                    <%#Eval("shouldSalary") %><label runat="server" id="lblshouldSalary"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">所属部门:</td>
                                <td>
                                    <%#Eval("DName") %><label runat="server" id="lblDName"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">基本工资:</td>
                                <td>
                                    <%#Eval("Salary") %><label runat="server" id="lblSalary"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">奖金:</td>
                                <td>
                                    <%#Eval("Bonus") %><label runat="server" id="lblBonus"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">缺勤天数:</td>
                                <td>
                                    <%#Eval("MissDay") %><label runat="server" id="lblMissDay"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">缺勤罚款:</td>
                                <td>
                                    <%#Eval("AttendFine") %><label runat="server" id="lblAttendFine"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="widthfoName">实发工资:</td>
                                <td>
                                    <%#Eval("Payroll") %><label runat="server" id="lblPayroll"></label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>



            <script src="../js/laydate/laydate.js"></script>
            <script>
                lay('#version').html('-v' + laydate.v);
                //执行一个laydate实例
                laydate.render({
                    elem: '#ipTime',//指定元素
                    type: 'month'

                });
            </script>
        </div>
    </form>
</body>
</html>
