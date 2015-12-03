<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SplitBill.aspx.cs" Inherits="Staff_SplitBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1>Split Bill</h1>
        Active Bills:
        <asp:DropDownList ID="ActiveBills" runat="server" AppendDataBoundItems="true" DataSourceID="ActiveBillsDataSource" DataTextField="DisplayText" DataValueField="BillID">
            <asp:ListItem Value="0">[select a bill]</asp:ListItem>
        </asp:DropDownList>

        <asp:LinkButton ID="SelectBill" runat="server" CssClass="btn btn-primary" OnClick="SelectBill_Click">
            Select Bill
        </asp:LinkButton>
        <asp:HiddenField ID="BillToSplit" runat="server" />

        <asp:ObjectDataSource runat="server" ID="ActiveBillsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListUnpaidBills" TypeName="eRestaurant.Framework.BLL.WaiterController"></asp:ObjectDataSource>
        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
    </div>

    <div class="row">
        <div class="row col-md-6">
        <h2>Original Bill</h2>
        <asp:GridView ID="OriginalBillItems" runat="server" 
            AutoGenerateColumns="false" 
            ItemType="eRestaurant.Framework.Entities.POCOs.OrderItem"
            OnSelectedIndexChanging="BillItems_SelectedIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="MoveOver" runat="server" CommandName="Select" CssClass="btn btn-default"><span class="glyphicon glyphicon-forward"> Move </span></asp:LinkButton>
                        <asp:Label ID="Quantity" runat="server" Text="<%# Item.Quantity %>"></asp:Label>
                        <asp:Label ID="ItemName" runat="server" Text="<%# Item.ItemName %>"></asp:Label>
                        <asp:Label ID="Price" runat="server" Text="<%# Item.Price %>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        <div class="row col-md-6">
        <h2>New Bill</h2>
        <asp:GridView ID="NewBillItems" runat="server" AutoGenerateColumns="false" ItemType="eRestaurant.Framework.Entities.POCOs.OrderItem" OnSelectedIndexChanging="BillItems_SelectedIndexChanging">
            <EmptyDataTemplate>
                New bill is empty. Move an item from the original bill.
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="MoveOver" runat="server" CommandName="Select" CssClass="btn btn-default"><span class="glyphicon glyphicon-backward"> Move </span></asp:LinkButton>
                        <asp:Label ID="Quantity" runat="server" Text="<%# Item.Quantity %>"></asp:Label>
                        <asp:Label ID="ItemName" runat="server" Text="<%# Item.ItemName %>"></asp:Label>
                        <asp:Label ID="Price" runat="server" Text="<%# Item.Price %>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </div>

    <div class="row col-md-12">
        <asp:LinkButton ID="SplitBillCommit" runat="server" CssClass="btn btn-default" OnClick="SplitBill_Click">
            Split Bill
        </asp:LinkButton>
    </div>


</asp:Content>



