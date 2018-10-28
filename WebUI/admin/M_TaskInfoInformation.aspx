<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M_TaskInfoInformation.aspx.cs" Inherits="WebUI.admin.M_TaskInfoInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link type="text/css" rel="stylesheet" href="../Css/Task.css" />
    <script type="text/javascript">
        function change_div(id) {
            if (id == 'TaskInfo') {
                document.getElementById("TaskInfo").style.display = 'block';
                document.getElementById("UpdTaskInfo").style.display = 'none';
            }
            else if (id == 'UpdTaskInfo') {
                document.getElementById("UpdTaskInfo").style.display = 'block';
                document.getElementById("TaskInfo").style.display = 'none';
            }

        }
    </script>
    <style>
        #UpdTaskInfo {
            display: none;
        }

        .text {
            width: 200px;
            height: 40px;
        }

        span:hover {
            color: black;
            cursor: pointer;
        }

        #Tasks {
            margin-left: 108px;
            float: left;
            border: 1px solid #cccdcf;
            font-family: 黑体;
            font-size: 18px;
            text-align: center;
            padding-top: 18px;
            width: 180px;
            height: 39px;
            background-repeat: no-repeat;
            background-color:red;
        }
        #Taskss{
             margin-left: 8px;
             margin-top:18px;
            float: left;
            border: 1px solid #cccdcf;
            font-family: 黑体;
            font-size: 18px;
            text-align: center;
            padding-top: 18px;
            width: 180px;
            height: 24px;
            background-repeat: no-repeat;
            background-color:#37b5ed;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="TaskInfo">
            <table class="tables">
                <tr>
                    <td colspan="2" align="center">
                        <h2>任务详细信息</h2>
                    </td>
                </tr>
                <tr>
                    <td class="td1">任务名称:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LbTaskName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">任务类型:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LbDID"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">发布时间:
                    </td>


                    <td>
                        <asp:Label runat="server" ID="LbTime"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="td1">发布内容:
                    </td>
                    <td width="400" height="120">
                        <asp:Label runat="server" ID="LbContent"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="td1">备注:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LbRemark"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%--<asp:Button runat="server" ID="BtnSel" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" Text="查看任务信息" onclick="change_div('TaskInfo')" />--%>
                        <%--<span runat="server" ID="BtnSel" style="height:39px;background-color :#37b5ed; border: 0px solid #37b5ed; color:white; width:180px;" onclick="change_div('TaskInfo')">查看任务信息</span>--%>
                  &nbsp;&nbsp;&nbsp;
                  <%--<asp:Button runat="server" ID="BtnDel" style="height:39px;background-color :red; border: 0px solid #37b5ed; color:white; width:180px;" Text="修改任务" onclick="change_div('UpdTaskInfo')" />--%>
                        <span runat="server" class="span" id="Tasks" onclick="change_div('UpdTaskInfo')">修改任务</span>
                    </td>
                </tr>
            </table>
        </div>
        <div id="UpdTaskInfo">
            <table class="tables">
                <tr>
                    <td colspan="2" align="center">
                        <h2>修改任务</h2>
                    </td>
                </tr>
                <tr>
                    <td class="td1">任务名称:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TbName" CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="td1">任务类型:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="DdlDids" CssClass="text"></asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
              <td class="td1">
                  发布时间:
              </td>
         
          
              <td>
                  <asp:Label runat="server" ID="Label3"></asp:Label>
              </td>
        </tr>--%>
                <tr>
                    <td class="td1">发布内容:
                    </td>
                    <td width="400" height="120">
                        <asp:TextBox runat="server" ID="TbContent" TextMode="MultiLine" Width="300" Height="120"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="td1">备注:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TbRemark" CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button runat="server" ID="BtnUpd" Style="height: 39px; background-color: red; border: 0px solid #37b5ed; color: white; width: 180px;" Text="确认修改" OnClick="BtnUpd_Click" />
                        
                    </td>
                    <td align="center">
                        &nbsp;&nbsp;&nbsp;
                  <%--<asp:Button runat="server" ID="Button2" Style="height: 39px; background-color: #37b5ed; border: 0px solid #37b5ed; color: white; width: 180px;" Text="取消" OnClick="change_div('TaskInfo')" />--%>
                        <span runat="server" id="Taskss" onclick="change_div('TaskInfo')">取消</span>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
