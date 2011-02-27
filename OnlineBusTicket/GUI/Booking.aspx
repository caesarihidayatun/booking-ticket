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
            <asp:HiddenField ID="_listbusID" runat="server" />
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
                        OnRowCommand="GridView1_RowCommand" Width="605px" CellPadding="4" ForeColor="#333333"
                        GridLines="None">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:BoundField DataField="ListBusID" />
                            <asp:BoundField DataField="BusPlate" HeaderText="BusPlate" />
                            <asp:BoundField DataField="Departure" HeaderText="Departure" />
                            <asp:BoundField DataField="Arrival" HeaderText="Arrival" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:ButtonField CommandName="Select" HeaderText="Select" Text="Select" />
                        </Columns>
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#1C5E55"
                            Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div>
                        <div style="float: left; width: 30%">
                            <table>
                                <tr>
                                    <td style="width: 99px">
                                        <asp:Label ID="Label1" runat="server" Text="Router Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbRouterName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 19px; width: 99px">
                                        <asp:Label ID="Label2" runat="server" Text="Departure"></asp:Label>
                                    </td>
                                    <td style="height: 19px">
                                        <asp:Label ID="lbDeparture" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 99px">
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
                                        <asp:Label ID="lbPrice2" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; margin-left: 50px">
                            <asp:CheckBoxList ID="chkSeat" runat="server" RepeatColumns="9" CellPadding="3" CellSpacing="-1" />
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            <asp:LinkButton ID="lnkBackBusSelect" runat="server" Text="[Back]" OnClick="BackBusSelect"></asp:LinkButton>
                            <asp:LinkButton ID="lnkNext" runat="server" OnClick="bntNext" ><span>Continue</span></asp:LinkButton>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <div>
                        <div style="float: left; width: 30%">
                            <table>
                                <tr>
                                    <td style="width: 99px">
                                        <asp:Label ID="Label5" runat="server" Text="Router Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbRouterName1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 19px; width: 99px">
                                        <asp:Label ID="Label7" runat="server" Text="Departure"></asp:Label>
                                    </td>
                                    <td style="height: 19px">
                                        <asp:Label ID="lbDeparture2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 99px">
                                        <asp:Label ID="Label9" runat="server" Text="Arrival"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbArrival2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 99px">
                                        <asp:Label ID="Label11" runat="server" Text="Ticket Price "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbPrice" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left;margin-left:50px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Custumer Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbName" runat="server" Text=""></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="BirthDay"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbBirthday" runat="server" Text=""></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Moblie"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbMoble" runat="server" Text=""></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Address"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbAdd" runat="server" Text=""></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Mail"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbMail" runat="server" Text=""></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                             <asp:LinkButton ID="LinkButton1" runat="server" Text="[Back]" OnClick="BackBusSelect"></asp:LinkButton>
                             <asp:LinkButton ID="lnkValidateCustomer" runat="server" OnClick="bntNext" ><span>Continue</span></asp:LinkButton>
                                

                        </div>
                        
                       
                       
                    </div>
                </asp:View>
                <asp:View ID="View4" runat="server">
                    <div>
                        <div style="float:left;width:30%">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Customer"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbCustomer2" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Discount Age"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbDiscount" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lbPromotePrent" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="Number Seat"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbNumberSeat" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Total Price"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbTotalPrice" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left;margin-left:50px">
                            <asp:LinkButton ID="LinkButton4" runat="server" Text="[Back]" OnClick="BackBusSelect"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server"  OnClick="bntSaveOrder"><span>Save Order</span></asp:LinkButton>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View5" runat="server">
                    <div>
                        <asp:Literal ID="litSuccess" Text="thank you for the booking we will contact you soon"
                            runat="server"></asp:Literal>
                        <asp:HyperLink ID="LinkButton2" runat="server" CssClass="button" NavigateUrl="~/Default.aspx"><span>Back Home</span></asp:HyperLink>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
