<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_Index.aspx.cs" Inherits="WebUI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Css/Index.css" rel="stylesheet" />
    <title></title>
</head>
    <script>
        function changeDiv(o) {
            var s = o.id.substr(2);
            var sc = document.getElementById("ul" + s);
            if (sc.style.display == "none") {
                sc.style.display = "block";
                document.getElementById(o).style.color = red;
            }
            else {
                sc.style.display = "none";
            }
        }

        function changeDiv2(o) {
            var s = o.id.substr(2);
            var sc = document.getElementById("ul" + s);
           
                sc.style.display = "none";
               
        }

    </script>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="H_header">
             <div id="leftBanner"> ZHAONI 找你网络科技 </div>  
             <div id="rightBanner">
                 <div id="UserLoginInfo">
                    您好:&nbsp;<asp:Label runat="server" ID="lblUserName"></asp:Label><asp:Button CssClass="btnOut" runat="server" ID="btnLoginOut" Text="退出" OnClientClick="return confirm('确定退出吗？');" OnClick="btnLoginOut_Click" />
                 </div>
                 <div id="timeShow">
                     <label id="lblTime" runat="server"></label>&nbsp;<label id="lblWeek" runat="server"></label>
                 </div>
             </div>
            </div>
            <div id="M_Menu">
                <asp:Literal runat="server" ID="literal"></asp:Literal>
            </div>
            <div id="C_Content">
                <iframe runat="server" id="iframe" name="iframe" class="iframeStyle" ></iframe>
            </div>
            <div id="B_tip"></div>
        </div>
    </form>
</body>
</html>
