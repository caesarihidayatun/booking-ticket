<%@ Page Language="C#" MasterPageFile="~/Template/Client/MasterPage.master" AutoEventWireup="true"
    CodeFile="Booking.aspx.cs" Inherits="GUI_Booking" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pattern_bg">
        <div class="pattern_box">
            <div class="title_icon">
                <img src="../Template/Client/images/mini_icon1.gif" alt="" title="" /></div>
            <div class="pattern_content">
                <h1>
                    Online bus booking <span class="blue">Bus Booking</span></h1>
            </div>
            <br />
            <br />
            <br />
            <br />
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    HorizontalAlign="Center" onrowcommand="GridView1_RowCommand" Width="605px" 
                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4">
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <columns>
                        <asp:BoundField DataField="BusPlate" HeaderText="BusPlate" />
                        <asp:BoundField DataField="Departure" HeaderText="Departure" />
                        <asp:BoundField DataField="Arrival" HeaderText="Arrival" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        
                        <asp:ButtonField CommandName="Select" HeaderText="Select" Text="Select" />
                        <asp:BoundField DataField="ListBusID" Visible="False" />
                        
                    </columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                </asp:GridView>
                </asp:View>
                
                <asp:View ID="View2" runat="server">
                    <div>
                        <table style="width: 30%;">
                            <tr>
                                <td style="width: 99px">
                                    &nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="Router Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbRouterName" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px; width: 99px">
                                    &nbsp;
                                    <asp:Label ID="Label2" runat="server" Text="Departure"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    
                                    <asp:Label ID="lbDeparture" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 99px">
                                    &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text="Arrival"></asp:Label>
                                </td>
                                <td>
                                    
                                    <asp:Label ID="lbArrival" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 99px">
                                    <asp:Label ID="Label4" runat="server" Text="Ticket Price "></asp:Label>
                                </td>
                                <td>
                                    
                                    <asp:Label ID="lbPrice" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float:right;position:absolute">
                        <asp:CheckBoxList ID="chkSeat" runat="server" RepeatColumns="9" CellPadding="3" CellSpacing="-1" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </asp:View>
                <asp:View ID="View3" runat="server">
                </asp:View>
                <asp:View ID="View4" runat="server">
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
