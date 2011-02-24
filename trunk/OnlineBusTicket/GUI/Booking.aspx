<%@ Page Language="C#" MasterPageFile="~/Template/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="GUI_Booking" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pattern_bg">           
					<div class="pattern_box">
                    	<div class="title_icon"><img src="../Template/Client/images/mini_icon1.gif" alt="" title="" /></div>
                         <div class="pattern_content">
                        <h1>Online bus booking <span class="blue">Bus Booking</span></h1>
            
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" Width="605px" 
                        AutoGenerateColumns="False" ForeColor="White" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="BusPlate" HeaderText="BusPlate" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Departure" HeaderText="Departure" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Arrival" HeaderText="Arrival" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="Price" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="Select" ShowSelectButton="True" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:CommandField>
                        </Columns>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                    </div>
                  
                       
                        
                        
                    
                    
    </div>
</asp:Content>

