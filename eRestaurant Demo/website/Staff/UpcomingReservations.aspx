<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UpcomingReservations.aspx.cs" Inherits="Staff_UpcomingReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h1>Upcoming Reservations</h1>
            <asp:ObjectDataSource 
                ID="ActiveEventsDataSource" 
                runat="server"
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="ListActiveEvents" 
                TypeName="eRestaurant.Framework.BLL.ReservationsController">          

            </asp:ObjectDataSource>

            <%--<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ActiveEventsDataSource" DataTextField="Description" DataValueField="Code"></asp:DropDownList>--%>

            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                DataSourceID="ActiveEventsDataSource" 
                DataTextField="Description" 
                DataValueField="Code" 
                AppendDataBoundItems="true" 
                RepeatDirection="Horizontal" 
                RepeatLayout="Flow">

                <asp:ListItem Selected="True" Value="All">All Events</asp:ListItem>
                <asp:ListItem Value="None">No Event</asp:ListItem>

            </asp:RadioButtonList>
        </div>
    </div>
</asp:Content>
