<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>帳號:</td>
            <td><asp:TextBox ID="txtAccount" runat="server" TextMode="SingleLine"></asp:TextBox></td>
        </tr>
        
        <asp:PlaceHolder ID="PlaceHolderPWD" runat="server" Visible="false">
            <tr>
                <td>密碼:<td />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </tr>
            <tr>
                <td>確認密碼:<td />
                <asp:TextBox ID="txtPWDCheck" runat="server" TextMode="Password"></asp:TextBox>
            </tr>
        </asp:PlaceHolder>
        <tr>
            <td>姓名:<td />
            <asp:TextBox ID="txtName" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </tr>
        <tr>
            <td>E-mail:<td />
            <asp:TextBox ID="txtMail" runat="server" TextMode="Email"></asp:TextBox>
        </tr>
    </table>
                <asp:Button ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click"  Font-Size="16"/>
                &nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" Font-Size="16"/>
                &nbsp;
                <br />
                <a href="UserChangePWD.aspx" runat="server" ID="pwLink">進入密碼變更頁面</a>
                <br />
                <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
</asp:Content>
