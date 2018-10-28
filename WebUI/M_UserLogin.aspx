<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_UserLogin.aspx.cs" Inherits="WebUI.M_UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .lblshow {
            display: none;
            color: red;
            height:24px;
           float:right;
            
        }
    </style>
    <script>
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
</head>
<body style="padding: 0px; margin: 0px;">
    <form id="form1" runat="server" >
        <div style="margin-top:190px; width: 100%; height: 400px; background-color:black;">
            
            <div style="float: left; margin-top: 30px; margin-left: 200px;">
                <h1 style="color:white; font-size:40px; font-family:"Trebuchet MS", Arial, Helvetica, sans-serif;">ZHAONI 找你网络科技</h1>
                <h1 style="color:white; font-size:40px; font-family:"Trebuchet MS", Arial, Helvetica, sans-serif;">后 台 登 录 系 统</h1>
            </div>
            <div style=" position: absolute;border-radius:8px 8px; background-color: #f5f2f2; height: 450px; width: 450px; top: 165px; right: 190px; box-shadow: 3px 3px 6px #ebe9e9;background-color:darkgrey;">

                <div style="margin-left: 40px; margin-top: 70px;">
                    <font style="font-size: 24px; font-family: 黑体; color: #333333;">登录名：</font>
                    <input runat="server" placeholder="请输入用户名" id="TtbName"  style="width:270px;height:40px;" onblur="clic(this.id)" />
                    <img src="Image/false.gif" class="lblshow" id="LtbName" alt="登录名不能为空" />  
                </div>
                <div style="margin-left: 40px; margin-top: 60px;">
                    <font style="font-size: 24px; font-family: 黑体; color: #333333;">密&nbsp;&nbsp;码：</font>
                    <input type="password" id="TtbPswd" placeholder="请输入用户密码" style="width:270px;height:40px;" runat="server" onblur="clic(this.id)" />
                    <img src="Image/false.gif" class="lblshow" id="LtbPswd" alt="登录密码不能为空" />
                    
                </div><%--<div style="margin-left:395px; width:40px; margin-top:-35px;"></div>--%>
                <div style="margin-left: 40px; margin-top: 50px;">
                    <font style="font-size: 24px; font-family: 黑体; color: #333333;">类&nbsp;&nbsp;型：</font>
                    <asp:DropDownList runat="server" ID="ddlUserType" Width="270px" Height="40px">
                        <asp:ListItem Value="1">管理员</asp:ListItem>
                        <asp:ListItem Value="2">人事</asp:ListItem>
                        <asp:ListItem Value="3">员工</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="margin-top: 60px; margin-left: 140px;">
                    <asp:Button runat="server" style="height:39px;background-color : #37b5ed; border: 0px solid #37b5ed; color:white; width:80px;" ID="BtnLogin" Text="登录" OnClick="BtnLogin_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" style="height:39px;background-color : #37b5ed; border: 0px solid #37b5ed; color:white; width:80px;" ID="BtnCZ" Text="重置" OnClick="BtnCZ_Click" />
                </div>
            </div>
        </div>        
    
    </form>
</body>
</html>
