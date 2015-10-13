<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageWaiters.aspx.cs" Inherits="Admin_ManageWaiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1>Manage Waiters
            <span class="glyphicon glyphicon-glass"></span>
        </h1>

        <!--ObjectDataSource control to do the underlying communication with the BLL and my ListView controls -->
        <asp:ObjectDataSource ID="WaitersDataSource" runat="server"
            TypeName="eRestaurant.Framework.BLL.RestaurantAdminController"
            SelectMethod="ListAllWaiters"
            DataObjectTypeName="eRestaurant.Framework.Entities.Waiter" 
            OldValuesParameterFormatString="original_{0}" 
            UpdateMethod="UpdateWaiter"
            DeleteMethod="DeleteWaiter"
            InsertMethod="InsertWaiter" OnDeleted="ProcessExceptions" OnInserted="ProcessExceptions" OnUpdated="ProcessExceptions">
        </asp:ObjectDataSource>
        <%--<asp:GridView ID="SpecialEventsGridView" runat="server" DataSourceID="SpecialEventsDataSource"></asp:GridView>--%>
        <%--CTRL+K,CTRL+C = comment    CTRL+K, CTRL+U = uncomment--%>

        <asp:Label ID="MessageLabel" runat="server" />

        <asp:ListView ID="WaitersListView" runat="server" 
            DataSourceID="WaitersDataSource" 
            DataKeyNames="WaiterID"
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
                    <asp:Label ID="Label11" runat="server" AssociatedControlID="WaiterIDData" CssClass="control-label">
                        Waiter ID</asp:Label>
                    <asp:Label ID="WaiterIDData" runat="server" Text='<%# Eval("WaiterID") %>' />

                    &mdash;

                    <asp:Label ID="Label1" runat="server" AssociatedControlID="FirstNameData" CssClass="control-label">
                        First Name </asp:Label>
                    <asp:Label ID="FirstNameData" runat="server" Text='<%# Eval("FirstName") %>' />

                    &mdash;

                    <asp:Label ID="Label2" runat="server" AssociatedControlID="LastNameData" CssClass="control-label">
                        Last Name</asp:Label>
                    <asp:Label ID="LastNameData" runat="server" Text='<%# Eval("LastName") %>' />

                    &mdash;

                    <asp:Label ID="Label5" runat="server" AssociatedControlID="PhoneData" CssClass="control-label">
                        Phone</asp:Label>
                    <asp:Label ID="PhoneData" runat="server" Text='<%# Eval("Phone") %>' />

                    &mdash;

                    <asp:Label ID="Label7" runat="server" AssociatedControlID="AddressData" CssClass="control-label">
                        Address</asp:Label>
                    <asp:Label ID="AddressData" runat="server" Text='<%# Eval("Address") %>' />

                    &mdash;

                    <asp:Label ID="Label9" runat="server" AssociatedControlID="HireDateData" CssClass="control-label">
                        Hire Date</asp:Label>
                    <asp:Label ID="HireDateData" runat="server" Text='<%# Eval("HireDate") %>' />

                    &mdash;

                    <asp:Label ID="Label6" runat="server" AssociatedControlID="ReleaseDateData" CssClass="control-label">
                        Release Date</asp:Label>
                    <asp:Label ID="ReleaseDateData" runat="server" Text='<%# Eval("ReleaseDate") %>' />
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

                    &mdash;

                    <asp:Label ID="Label3" runat="server" AssociatedControlID="WaiterIDTextBox" CssClass="control-label">
                        Waiter ID
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("WaiterID") %>' runat="server" ID="WaiterIDTextBox" />
                    &mdash;

                    <asp:Label ID="Label4" runat="server" AssociatedControlID="FirstNameTextBox"  CssClass="control-label">
                        First Name
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("FirstName") %>' runat="server" ID="FirstNameTextBox" />

                    &mdash;

                    <asp:Label ID="Label8" runat="server" AssociatedControlID="LAstNameTextBox"  CssClass="control-label">
                        Last Name
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("LastName") %>' runat="server" ID="LastNameTextBox" />

                    &mdash;

                    <asp:Label ID="Label10" runat="server" AssociatedControlID="PhoneTextBox"  CssClass="control-label">
                        Phone
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("Phone") %>' runat="server" ID="PhoneTextBox" />

                    &mdash;

                    <asp:Label ID="Label12" runat="server" AssociatedControlID="AddressTextBox"  CssClass="control-label">
                        Address
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("Address") %>' runat="server" ID="AddressTextBox" />

                    &mdash;

                    <asp:Label ID="Label13" runat="server" AssociatedControlID="HireDateTextBox"  CssClass="control-label">
                        Hire Date
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("HireDate") %>' runat="server" ID="HireDateTextBox" />

                    &mdash;

                    <asp:Label ID="Label14" runat="server" AssociatedControlID="ReleaseDateTextBox"  CssClass="control-label">
                        Release Date
                    </asp:Label>

                    <asp:TextBox Text='<%# Bind("ReleaseDate") %>' runat="server" ID="ReleaseDateTextBox" />


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

                    Waiter ID:
                    <asp:TextBox runat="server" ID="WaiterIDTextBox" 
                        Text='<%# Bind("WaiterID") %>' 
                        Enabled="false" />

                    First Name:
                    <asp:TextBox runat="server" ID="FirstNameTextBox"
                        Text='<%# Bind("FirstName") %>' />
                    Last Name:
                    <asp:TextBox runat="server" ID="LastNameTextBox"
                        Text='<%# Bind("LastName") %>' />
                    Address:
                    <asp:TextBox runat="server" ID="AddressTextBox"
                        Text='<%# Bind("Address") %>' />
                    Hire Date:
                    <asp:TextBox runat="server" ID="HireDateTextBox"
                        Text='<%# Bind("HireDate") %>' />
                    Release Date:
                    <asp:TextBox runat="server" ID="ReleaseDateTextBox"
                        Text='<%# Bind("ReleaseDate") %>' />
      
                </div>
            </EditItemTemplate>

            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>

        </asp:ListView>
    </div>
    
    
</asp:Content>



