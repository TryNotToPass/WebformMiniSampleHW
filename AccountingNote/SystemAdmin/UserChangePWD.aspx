<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserChangePWD.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserChangePWD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:PlaceHolder ID="AccPlaceHolder" runat="server">
                    請再輸入一次帳號與密碼，確認你的身分。
                    <br />
                    帳號
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                    <br />
                    密碼:
                    <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnCheck" runat="server" Text="確認" OnClick="btnCheck_Click" Font-Size="16"/>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="PWDPlaceHolder" runat="server" Visible="false">
                    密碼: 
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    密碼再次確認:
                    <asp:TextBox ID="txtPWDCheck" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnOK" runat="server" Text="密碼變更確認" OnClick="btnOK_Click" Font-Size="16"/>
                </asp:PlaceHolder>
                <br />
                <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>

</asp:Content>
