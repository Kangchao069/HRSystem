<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="U_Attendance.aspx.cs" Inherits="WebUI.U_Attendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Css/userAttend.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function change(num) {
            if(num==1){
                document.getElementById("myAttendInfo").style.display = "block";
                document.getElementById("myLeaveInfo").style.display = "none";
                this.cc.style.backgroundColor = "#5275e7";
                this.qq.style.backgroundColor = "#ffffff";
            }else if(num==2){
                document.getElementById("myAttendInfo").style.display = "none";
                document.getElementById("myLeaveInfo").style.display = "block";
                this.qq.style.backgroundColor = "#5275e7";
                this.cc.style.backgroundColor = "#ffffff";
            }
        }
    </script>
</head>
  

<body>
    <form id="form1" runat="server">
        <div align="left">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                </asp:SiteMapPath>
        </div>
        <div id="content">
            <div id="myAttendTitle">
                <div class="changestyle" style="background-color:#5275e7;" id="cc" onclick="javascript:change(1);">出勤记录</div>&nbsp;<div class="changestyle" id="qq" onclick="javascript:change(2);">请假记录</div>
            </div>
            <div id="myAttendInfo">
                <asp:GridView   CssClass="datable" runat="server" ID="gvPaper" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns >
                    
                    <asp:TemplateField HeaderText="日期" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("Month") %>'></asp:Label>
                            <asp:HiddenField runat="server" ID="hfTPID" Value='<%#Eval("AID") %>' />
                        </ItemTemplate>
                            
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="出勤天数" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("AttendDays") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="加班天数" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("OvertimeDays") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="奖金" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("Bonus") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="备注" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("Remark") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                    <RowStyle HorizontalAlign ="Center" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
            </asp:GridView>

            </div>



            <div id="myLeaveInfo" style="display:none;">
                <asp:GridView  CssClass="datable" runat="server" ID="gvLeaveDate" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns >
                    <asp:TemplateField HeaderText="开始日期" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("BeginTime") %>'></asp:Label>
                        </ItemTemplate>
                        
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="结束日期" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("EndTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="原因" HeaderStyle-Width="150px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("LReason") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="备注" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTPID" Text='<%#Bind("Remark") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    
                </Columns>

                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#E3EAEB" HorizontalAlign ="Center" />
            </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
