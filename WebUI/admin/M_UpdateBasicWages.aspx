<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_UpdateBasicWages.aspx.cs" Inherits="WebUI.admin.M_UpdateBasicWages1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
            
    <div style="border:1px solid #f0f0f0">
         <table style="margin: 0 auto;padding-top:20px;padding-bottom:20px;">
              <tr>
                 <td colspan="2" style="text-align:center;">修改员工基本薪资</td>
             </tr>
             <tr>
                 <td>职位:</td>
                 <td>
                        
                     <asp:Label runat="server" ID="lblPName"></asp:Label>
                 </td>
             </tr>

             <tr>
                 <td>基本薪资:</td>
                 <td>
                      <asp:TextBox runat="server" ID="txtSalary"></asp:TextBox>
                 </td>
             </tr>
              <tr>
                 <td colspan="2" style="text-align:center;"><br/>
                     <asp:Button runat="server" ID="btnSure" Text="确定" OnClick="btnSure_Click" />&nbsp;&nbsp;
                     <asp:Button runat="server" ID="btnClose" Text="关闭" />
                 </td>
             </tr>
         </table>
    </div>
    </form>
</body>
</html>
