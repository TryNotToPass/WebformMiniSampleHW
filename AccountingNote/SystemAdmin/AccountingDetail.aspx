<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <!--這裡放主要內容-->
                Type: 
                    <asp:DropDownList ID="ddlActType" runat="server">
                        <asp:ListItem Value="0">支出</asp:ListItem>
                        <asp:ListItem Value="1">收入</asp:ListItem>
                    </asp:DropDownList>
                <br />
                Amount: 
                    <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
                <br />
                Caption: 
                    <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                <br />
                Desc:
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
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
