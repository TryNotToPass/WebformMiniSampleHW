<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AccountingNote.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<center>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>使用者登入</title>
    <link rel="stylesheet" href="Main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder runat="server" ID="plcLogin" Visible="false">
            <h1>使用者登入</h1>
            <table>
                <tr>
                    <td>帳號:</td>
                    <td><asp:TextBox ID="txtAccount" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>密碼:</td>
                    <td><asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center"><asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click" Font-Size="16"/></td>
                </tr>
            </table>
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            <a href="Default.aspx">回到首頁</a>
        </asp:PlaceHolder>
    </form>
</body>
</center>
</html>
