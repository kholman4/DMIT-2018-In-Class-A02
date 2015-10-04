<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MenuItems.aspx.cs" Inherits="Admin_MenuItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Repeater ID="MenuRepeater" runat="server" DataSourceID="MenuDataSource">
        <ItemTemplate>
        <%# ((decimal)Eval("CurrentPrice")).ToString("C") %> 
        &mdash; <%# Eval("Description") %> &ndash; <%# Eval("Category.Description") %> 
        &ndash; <%# Eval("Calories") %> Calories
        </ItemTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource 
        runat="server" 
        ID="MenuDataSource"
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="ListMenuItems"
        TypeNAme="eRestaurant.BLL.MenuController">
    </asp:ObjectDataSource>

    


</asp:Content>

