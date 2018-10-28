<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="WebUI.UpdatePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Css/updatePwd.css"  rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <div id="OutArea">
            <div id="InArea">
                <div class="fontUpdate">修改密码</div>
                <div id="content">
                    <div>
                        <input runat="server" id="iptRePwd" type="text" placeholder=" 原密码" />
                    </div>
                    <div>
                        <input runat="server" id="iptNewPwd" type="password" placeholder=" 新密码" />
                    </div>
                    <div>
                        <input runat="server" id="iptSurePwd" type="password" placeholder=" 确认密码" />
                    </div>
                    <div>
                       
                    </div>
                </div>
                <div id="btnBut">
                    <asp:Button CssClass="buttonsl" runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
