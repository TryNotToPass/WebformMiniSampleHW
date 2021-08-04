<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="目前尚無使用者" Visible="False"></asp:Label>
    <asp:GridView ID="gv_UserList" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Account" HeaderText="帳戶" />
            <asp:BoundField DataField="Name" HeaderText="名稱" />
            <asp:BoundField DataField="Email" HeaderText="電子郵件" />
            <asp:TemplateField HeaderText="編輯">
                <ItemTemplate>
                    <a href="/SystemAdmin/UserDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <uc1:ucpager runat="server" id="ucPager" PageSize="10" CurrentPage="1" Url="/SystemAdmin/UserList.aspx" />
    <br />
    <asp:Button ID="btn_addUser" runat="server" Text="新增使用者" OnClick="btn_addUser_Click" />
</asp:Content>
