<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <th>帳戶</th>
                        <td><asp:Literal runat="server" ID="ltAccount"></asp:Literal></td>
                    </tr>
                    <tr>
                        <th>姓名</th>
                        <td><asp:Literal runat="server" ID="ltName"></asp:Literal></td>
                    </tr>
                    <tr>
                        <th>Email</th>
                        <td><asp:Literal runat="server" ID="ltEmail"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Literal runat="server" ID="ltMsg"></asp:Literal></td>
                    </tr>
                </table>
                <asp:Button runat="server" ID="btnLogout" Text="登出" OnClick="btnLogout_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
