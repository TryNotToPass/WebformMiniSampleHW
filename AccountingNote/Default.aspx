<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountingNote.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<center>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>流水帳管理系統</title>
    <link rel="stylesheet" href="Main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>流水帳管理系統</h1>
            <h3>本系統乃登記使用者的收入與支出</h3>
            <asp:Literal ID="ltmsg" runat="server"></asp:Literal>
            <br />
            <br />
            <a href="Login.aspx" runat="server" id="loginLink">移至登入頁面</a>
            <asp:Button ID="Button1" runat="server" Text="新增使用者" OnClick="Button1_Click" Font-Size="16" Visible="false"/>
           <%-- <p>beta版GV</p>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView> --%>
        </div>
    </form>
</body>
</center>
</html>
