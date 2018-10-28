<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_SetPermission.aspx.cs" Inherits="WebUI.M_SetPermission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Css/M_PermissionCSS.css" />
    <title>权限分配</title>
    
    


</head>
<body>
    <form id="form1" runat="server">
        
         <div align="left">
             <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
         </div>
        <div>
            <table id="table">

                <asp:Repeater runat="server" ID="oneRepeater" OnItemDataBound="oneRepeater_ItemDataBound">
                    <ItemTemplate>
                        <tr id="oneRepeater_tr">
                            <td>
                                
                                <asp:HiddenField runat="server" ID="hfPID" Value='<%#Bind("MID") %>' />
                                <input type="checkbox" runat="server" id="cbPageNames" name="cbPageNames" value='<%#Bind("MID") %>' />
                                <%# Eval("MenuName") %>
                                <div id="twoRepeater_Div">
                                    <asp:Repeater runat="server" ID="twoRepeater">
                                        <ItemTemplate>

                                            <li id="twoRepeater_li">
                                                <input type="checkbox" runat="server" id="cbPageName" name="cbPageName" value='<%#Bind("MID") %>' />
                                                <%#Eval("MenuName") %>
                                            </li>



                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td style="text-align: center;">
                        <asp:Button runat="server" ID="btnYes" Text="确   定" CssClass="PowerButton" OnClick="btnYes_Click" />&nbsp;&nbsp;
                   <asp:Button runat="server" ID="btnNo" Text="取   消" CssClass="PowerButton" OnClick="btnNo_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
