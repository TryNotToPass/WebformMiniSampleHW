<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>
<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <!--這裡放主要內容-->
                <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />

                <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="False"  OnRowDataBound="gvAccountingList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="標題" DataField="Caption" />
                        <asp:BoundField HeaderText="金額" DataField="Amount" />
                        <asp:TemplateField HeaderText="In/Out">
                            <ItemTemplate>
                                <%--<%# ((int)Eval("ActType") == 0) ? "支出" : "收入" %>--%>
                                <%--<asp:Literal runat="server" ID="ltActType"></asp:Literal>--%>
                                <asp:Label runat="server" ID="lblActType"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:TemplateField HeaderText="Act">
                            <ItemTemplate>
                                <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:Literal runat="server" ID="ltPager">
                </asp:Literal>
                <uc1:ucpager runat="server" id="ucPager" PageSize="10" CurrentPage="1" TotalSize="10" Url="AccountingList.aspx" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="總金錢變更：尚無"></asp:Label>
                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                    <p style="color: red; background-color: cornflowerblue">
                        No data in your Accounting Note.
                    </p>
                </asp:PlaceHolder>
            </td>
        </tr>
    </table>
</asp:Content>
