<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="U_SelUserInfo.aspx.cs" Inherits="WebUI.U_SelUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../Css/UserTable.css" />
    <link rel="stylesheet" href="../Css/Tables.css" />
    <script type="text/javascript">
        function change_div(id) {
            if (id == 'UserInfo') {
                document.getElementById("UserInfo").style.display = 'block';
                document.getElementById("UpdUserInfo").style.display = 'none';
            }
            else if (id == 'UpdUserInfo') {
                document.getElementById("UpdUserInfo").style.display = 'block';
                document.getElementById("UserInfo").style.display = 'none';
            }
            
        }
        function clic(dd) {
            var T = dd.substr(1);
            var kt = document.getElementById(dd).value;

            if (kt == "") {
                var kl = "L" + T;
                document.getElementById(kl).style.display = "block";
            }
            else {
                var kl = "L" + T;
                document.getElementById(kl).style.display = "none";
            }
        }
       
    </script>
    
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }

    </style>
    
</head>
<body>
    <form id="form1" runat="server" align="center">
        <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <span runat="server" class="span" id="Users" onclick="change_div('UserInfo')"> 个人信息</span>&nbsp;&nbsp;
        <span runat="server" class="span" id="UpdUsers" onclick="change_div('UpdUserInfo')" >修改个人基本信息</span>
    <div id="UserInfo">
        <table style="border:1px solid #cccdcf;" class="table1">
            <tr>
                <td colspan="4" align="center" class="auto-style1">
                    <h2>个人信息</h2>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;编&nbsp;号:
                </td>
                <td>
                    
                    <asp:Label runat="server" ID="LbNumber" CssClass="TextBox"></asp:Label>
                    
                </td>
                <td class="td">
                    &nbsp;用户名:
                </td>
                <td width="350">
                    <asp:Label runat="server" ID="LbName" CssClass="TextBox"></asp:Label>
                </td>                
            </tr>

            <tr>
                <td class="td">
                    &nbsp;职&nbsp;务:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbPost" CssClass="TextBox"></asp:Label>
                </td>
               <td class="td">
                   &nbsp;类&nbsp;型:
               </td>
                <td>
                    <asp:Label runat="server" ID="LbUserType" CssClass="TextBox"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="td">
                    &nbsp;部&nbsp;门:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbDepartment" CssClass="TextBox"></asp:Label>
                </td>
                <td class="td">
                    联系方式:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbPhone" CssClass="TextBox"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;学&nbsp;历:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbEducation" CssClass="TextBox"></asp:Label>
                </td>
                <td class="td">
                    毕业院校:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbAcademy" CssClass="TextBox"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;性&nbsp;别:
                </td>
                <td>
                    <asp:Label runat="server" ID="LbSex" CssClass="TextBox"></asp:Label>
                </td>
                <td class="td" style="text-align:center;" rowspan="2">
                    个人介绍:
                </td>
                <td style="width:200px;height:60px;" rowspan="2">
                    <asp:Label runat="server" ID="LbDetails" CssClass="mil" ></asp:Label>
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
            </tr>
            

        </table>
    </div>
        <div id="UpdUserInfo">
            <table class="tables" style="border:1px solid #cccdcf">
            <tr>
                <td colspan="4" align="center" class="auto-style1">
                    <h2>修改用户基本信息</h2>
                </td>
            </tr>
            <tr>
                <%--<td class="td">
                    &nbsp;编&nbsp;号:
                </td>
                <td>
                    
                    <asp:TextBox runat="server" ID="TbNumber" CssClass="TextBox"></asp:TextBox>
                    
                </td>--%>
                <td class="td">
                    &nbsp;用户名:
                </td>
                <td class="tds">
                    <asp:TextBox runat="server" ID="TTbName" CssClass="TextBoxs" onblur="clic(this.id)"></asp:TextBox>
                    <asp:Label runat="server" ID="LTbName"  CssClass="lblshow"><img src="../Image/false.gif" />请输入用户名！</asp:Label>                
                </td>
                <td class="td">
                    &nbsp;性&nbsp;别:
                </td>
                <td class="tds">
                    <asp:DropDownList runat="server" ID="TbSex" CssClass="TextBoxs">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                        
                    </asp:DropDownList>
                    <%--<asp:TextBox runat="server" ID="TbSex" CssClass="TextBoxs"></asp:TextBox>--%>
                </td>                
            </tr>

            
            <tr>
               
                <td class="td">
                    联系方式:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TTbPhone" CssClass="TextBoxs" onblur="clic(this.id)"></asp:TextBox>
                    <asp:Label runat="server" ID="LTbPhone" CssClass="lblshow" ><img src="../Image/false.gif" />请输入联系方式！</asp:Label>
                </td>
                <td class="td">
                    &nbsp;住&nbsp;址:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TTbAddress" CssClass="TextBoxs" onblur="clic(this.id)"></asp:TextBox>
                    <asp:Label runat="server" ID="LTbAddress" CssClass="lblshow" ><img src="../Image/false.gif" />请输入住址！</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;学&nbsp;历:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="TbEducation" CssClass="TextBoxs"></asp:DropDownList>
                    <%--<asp:TextBox runat="server" ID="TbEducation" CssClass="TextBoxs"></asp:TextBox>--%>
                </td>
                <td class="td">
                    毕业院校:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TTbAcademy" CssClass="TextBoxs" onblur="clic(this.id)"></asp:TextBox>
                    <asp:Label runat="server" ID="LTbAcademy" CssClass="lblshow" ><img src="../Image/false.gif" />请输入毕业院校！</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="td">
                    身份证号:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TTbIDCard" CssClass="TextBoxs" onblur="clic(this.id)"></asp:TextBox>
                    <asp:Label runat="server" ID="LTbIDCard" CssClass="lblshow" ><img src="../Image/false.gif" />请输入身份证号！</asp:Label>
                </td>
                <td class="td" style="text-align:center;" rowspan="2">
                    个人介绍:
                </td>
                <td style="width:280px;height:60px;" rowspan="2">
                    <asp:TextBox runat="server" ID="TTbDetails" CssClass="mils" TextMode="MultiLine" onblur="clic(this.id)"></asp:TextBox>
                    <asp:Label runat="server" ID="LTbDetails" CssClass="lblshow" ><img src="../Image/false.gif" />请输入个人介绍！</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="td">
                    &nbsp;Email:
                </td>
                <td>
                   <asp:TextBox runat="server" ID="TTbEmail" CssClass="TextBoxs" onblur="clic(this.id)"></asp:TextBox>
                    <asp:Label runat="server" ID="LTbEmail" CssClass="lblshow" ><img src="../Image/false.gif" />请输入Email！</asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="td">
                    &nbsp;备&nbsp;注:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TbRemark" CssClass="TextBoxs"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                
                <td colspan="4" align="center">
                    <asp:Button runat="server" ID="BtnUpd" Text="确认修改" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnUpd_Click" />
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="BtnCols" Text="取消" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" OnClick="BtnCols_Click" />
                </td>
            </tr>
            
            

        </table>
        </div>
    </form>
</body>
</html>
