<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageSpecialEvents.aspx.cs" Inherits="Admin_ManageSpecialEvents" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="my" TagName="MessageUserControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1>Manage Special Events
            <span class="glyphicon glyphicon-glass"></span>
        </h1>

        <!--ObjectDataSource control to do the underlying communication with the BLL and my ListView controls -->
        <asp:ObjectDataSource ID="SpecialEventsDataSource" runat="server"
            TypeName="eRestaurant.Framework.BLL.RestaurantAdminController"
            SelectMethod="ListAllSpecialEvents"
            DataObjectTypeName="eRestaurant.Framework.Entities.SpecialEvent" 
            OldValuesParameterFormatString="original_{0}" 
            UpdateMethod="UpdateSpecialEvent"
            DeleteMethod="DeleteSpecialEvent"
            InsertMethod="InsertSpecialEvent" OnDeleted="ProcessExceptions" OnInserted="ProcessExceptions" OnUpdated="ProcessExceptions">
        </asp:ObjectDataSource>
        <%--<asp:GridView ID="SpecialEventsGridView" runat="server" DataSourceID="SpecialEventsDataSource"></asp:GridView>--%>
        <%--CTRL+K,CTRL+C = comment    CTRL+K, CTRL+U = uncomment--%>

        <%--<asp:Label ID="MessageLabel" runat="server" />--%>

        <my:MessageUserControl runat="server" ID="MessageUserControl" />

        <asp:ListView ID="SpecialEventsListView" runat="server" 
            DataSourceID="SpecialEventsDataSource" 
            DataKeyNames="EventCode"
            InsertItemPosition="LastItem">

            <LayoutTemplate>
                <fieldset runat="server" id="itemPlaceholderContainer">
                    <div runat="server" id="itemPlaceholder" />
                </fieldset>
            </LayoutTemplate>

            <ItemTemplate>
                <div>
                    <asp:LinkButton runat="server" CommandName="Edit" ID="EditButton">
                        Edit<span class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>

                    &nbsp;&nbsp;

                    <asp:LinkButton runat="server" CommandName="Delete" ID="DeleteButton">
                        Delete<span class="glyphicon glyphicon-trash"></span>
                    </asp:LinkButton>

                    &nbsp;&nbsp;&nbsp;

                    <!-- < %# directs to the data source property in C# language, by each row in the object -->
                    <asp:CheckBox Checked='<%# Eval("Active") %>' 
                        runat="server" ID="ActiveCheckbox"
                        Enabled="false" Text="Active" />
                    &mdash;
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="EventCodeData" CssClass="control-label">
                        Event Code </asp:Label>
                    <asp:Label ID="EventCodeData" runat="server" Text='<%# Eval("EventCode") %>' />
                    &mdash;
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="DescriptionData" CssClass="control-label">
                        Description</asp:Label>
                    <asp:Label ID="DescriptionData" runat="server" Text='<%# Eval("Description") %>' />
                </div>
            </ItemTemplate>

            <InsertItemTemplate>
                <span style="">
                    <asp:LinkButton runat="server" CommandName="Insert" ID="InsertButton">
                        Update
                        <span class="glyphicon glyphicon-plus"></span>
                    </asp:LinkButton>

                    &nbsp;&nbsp;&nbsp;

                    <asp:LinkButton runat="server" CommandName="Cancel" ID="CancelButton">
                        Cancel
                        <span class="glyphicon glyphicon-refresh"></span>
                    </asp:LinkButton>

                    &nbsp;&nbsp;&nbsp;

                    <asp:CheckBox Checked='<%# Bind("Active") %>' runat="server" ID="ActiveCheckBox" Text="Active" />

                    &mdash;

                    <asp:Label ID="Label3" runat="server" AssociatedControlID="EventCodeTextBox" CssClass="control-label">
                        Event Code
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("EventCode") %>' runat="server" ID="EventCodeTextBox" />
                    &mdash;

                    <asp:Label ID="Label4" runat="server" AssociatedControlID="DescriptionTextBox"  CssClass="control-label">
                        Description
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" />
                </span>
            </InsertItemTemplate>

            <EditItemTemplate>
                <div>
                    <asp:LinkButton runat="server" CommandName="Update" ID="UpdateButton" Text="Update">
                    </asp:LinkButton>

                    &nbsp;&nbsp;

                    <asp:LinkButton runat="server" CommandName="Cancel" ID="CancelButton" Text="Cancel">
                    </asp:LinkButton>

                    &nbsp;&nbsp;&nbsp;

                    Event Code:
                    <asp:TextBox runat="server" ID="EventCodeTextBox" 
                        Text='<%# Bind("EventCode") %>' 
                        Enabled="false" />

                    Description:
                    <asp:TextBox runat="server" ID="DescriptionTextBox"
                        Text='<%# Bind("Description") %>' />
                    <asp:CheckBox runat="server" ID="ActiveCheckbox"
                        Checked='<%# Bind("Active") %>' />

                </div>
            </EditItemTemplate>

            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>

        </asp:ListView>
    </div>
    
    
</asp:Content>

