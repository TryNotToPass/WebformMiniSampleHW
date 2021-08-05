<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountingNote.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>流水帳管理系統</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>流水帳管理系統</h1>
            <h5>本系統乃登記使用者的收入與支出</h5>
            <asp:Literal ID="ltmsg" runat="server"></asp:Literal>
            <br />
            <br />
            <a href="Login.aspx">移至登入頁面</a>
           <%-- <p>beta版GV</p>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView> --%>
        </div>
    </form>
</body>
</html>
