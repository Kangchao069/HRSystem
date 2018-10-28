<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="U_TaskPageDetail.aspx.cs" Inherits="WebUI.U_TaskPageDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Css/TaskDetail.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <div id="bigdiv">
            <div style="width:80%;">
                <div style="text-align:center;width:100%;">
                <asp:Label runat="server" ID="lblTitle" CssClass="bigDivTitle_title"></asp:Label>
                    </div>
                <br />
                <asp:Label runat="server" ID="lblAuthor" CssClass="bigDivTitle_text"></asp:Label>&nbsp;&nbsp;
              <asp:Label runat="server" ID="lblReleaseTime" CssClass="bigDivTitle_text"></asp:Label>
            </div>
            <div class="conStyle">
                <asp:Literal ID="txtContent" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
