<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_BasicWages.aspx.cs" Inherits="WebUI.admin.M_BasicWages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>调整基本工资</title>
    <link href="../Css/BasicWages.css" rel="stylesheet" />
</head>
<script type="text/javascript">
    function openwinEdit(text) {
        window.open("M_UpdateBasicWages.aspx?PID=" + text, null, "height=300,width=400,top=200,left=600,status=no,toolbar=no,menubar=no,location=no,resizable=no,scroll=no");

    }
</script>

<body>
    <form id="form1" runat="server">
        
            <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <div>
            <div id="titName">
                <div style="float: left; width: 400px">员工基本工资明细</div>
            </div>
            <div id="basicInfo">
                <asp:Repeater runat="server" ID="repShow">
                    <ItemTemplate>
                        <div id="leftPName">
                            <asp:HiddenField runat="server" ID="hfPID" Value='<%#Eval("PID")%>' />
                            <%#Eval("PName") %>&nbsp;
                        </div>
                        <div id="rightWages">
                            &nbsp;  <%#Eval("Salary") %><a class="aEdit" onclick="openwinEdit('<%# Server.UrlDecode(Eval("PID").ToString()) %>')">修改基本工资</a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
