<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <!--這裡放主要內容-->
                Account: 
                    <asp:TextBox ID="txtAccount" runat="server" TextMode="SingleLine"></asp:TextBox>
                <br />
                <asp:PlaceHolder ID="PlaceHolderPWD" runat="server" Visible="false">
                     Password: 
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    Password double check:
                    <asp:TextBox ID="txtPWDCheck" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                </asp:PlaceHolder>
                Name:
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                E-mail:
                    <asp:TextBox ID="txtMail" runat="server" TextMode="Email"></asp:TextBox>
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Del" OnClick="btnDelete_Click" />
                <br />
                <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
