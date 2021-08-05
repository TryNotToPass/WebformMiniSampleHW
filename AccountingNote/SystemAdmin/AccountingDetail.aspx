<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>收/支:</td> 
            <td align="left"><asp:DropDownList ID="ddlActType" runat="server">
                <asp:ListItem Value="0">支出</asp:ListItem>
                <asp:ListItem Value="1">收入</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr>
                <td>金額:</td> 
                <td><asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox></td>
        </tr>
        <tr>
                <td>說明:</td> 
                <td><asp:TextBox ID="txtCaption" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
                <td style="height: 34px">補充:</td>
                <td style="height: 34px"><asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    &nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Del" OnClick="btnDelete_Click" />
    <br />
    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>

</asp:Content>
