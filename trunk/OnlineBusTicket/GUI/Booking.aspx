<%@ Page Language="C#" MasterPageFile="~/Template/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="GUI_Booking" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >           
					<div class="box_title">
                    	<div class="title_icon"><img src="../Template/Client/images/mini_icon1.gif" alt="" title="" /></div>
                        <h2>My <span class="dark_blue">Events</span></h2>
                    </div>
                    <asp:GridView ID="GridView1" runat="server" Width="605px" 
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="BusPlate" HeaderText="BusPlate" />
                            <asp:BoundField DataField="BusName" HeaderText="BusName" />
                            <asp:BoundField DataField="Departure" HeaderText="Departure" />
                            <asp:BoundField DataField="Arrival" HeaderText="Arrival" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="Seat" HeaderText="Seat" />
                            <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
    </div>
</asp:Content>

