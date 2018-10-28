<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="U_TaskPage.aspx.cs" Inherits="WebUI.U_TaskPage" %>

<%@ Register Assembly="common" Namespace="common" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Css/taskPage.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
            </asp:SiteMapPath>
        </div>
        <div id="content">
            <asp:Repeater runat="server" ID="repLeaveInfo" ClientIDMode="AutoID">
                <ItemTemplate>
                    <div id="leftsource">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a title='<%#Eval("TName") %>&nbsp;发表于<%#Eval("ReleaseTime") %>' href="U_TaskPageDetail.aspx?TID=<%#Eval("TID") %>">
                            <%#Eval("TName") %>  </a>
                    </div>

                    <div id="rightsource"><%#Eval("ReleaseTime") %></div>

                </ItemTemplate>
            </asp:Repeater>
          
        </div>
         <div class="pagecontrol">
                <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextLinkSeparator=" "
                BackText="上一页" FirstText="第一页" LabelText="第" LastText="最后一页" NextText="下一页" PageNumbersSeparator="-"
                PageSize="6" ShowFirstLast="true" ShowPageNumbers="true">
         </cc1:CollectionPager>
           </div>
    </form>
</body>
</html>
