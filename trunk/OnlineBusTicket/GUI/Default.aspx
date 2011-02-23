<%@ Page Language="C#" MasterPageFile="~/Template/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="GUI_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" src="../Template/Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Template/Scripts/superfish.js"></script>
    <script type="text/javascript" src="../Template/Scripts/jquery-ui-1.8.2.custom.min.js"></script>
    <script type="text/javascript" src="../Template/Client/jquery-ui-1.8.2.custom.css"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $("#<%=txtFromDate.ClientID %>").datepicker();
            $("#<%=txtToDate.ClientID %>").datepicker();
        });      
    </script>    
    
    <div class="pattern_bg">
    
    	<div class="pattern_box">
            <div class="pattern_box_icon"><img src="../Template/Client/images/icon1.png" alt="" title="" width="70" height="112" /></div>
            <div class="pattern_content">
            <h1>Online bus booking <span class="blue">Bus Booking</span></h1>
            
            </div>
            <div style="float:left">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 80px" align="left">
                        &nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="11pt" 
                            ForeColor="White" Text="From"></asp:Label>
                    </td>
                    <td style="width: 141px">
                        <asp:DropDownList ID="DropDownFrom" runat="server" Height="17px" Width="143px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 15px">
                        &nbsp;
                    </td>
                    <td style="width: 65px" align="left">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="11pt" 
                            ForeColor="White" Text="To"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="DropDownTo" runat="server" Width="143px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px" align="left">
                        &nbsp;
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="11pt" 
                            ForeColor="White" Text="Date From"></asp:Label>
                    </td>
                    <td style="width: 141px">
                         <asp:TextBox ID="txtFromDate" runat="server"  style="width: 140px;"></asp:TextBox>
                    </td>
                    <td style="width: 15px">
                        &nbsp;</td>
                    <td style="width: 65px" align="left">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="11pt" 
                            ForeColor="White" Text="Date To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server"  style="width: 140px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        &nbsp;
                        <asp:Button ID="Button1" runat="server" Text="Search Buses" Width="108px" 
                            onclick="Button1_Click" />
                    </td>
                </tr>
                </table>
            </div>
            
        </div>
   
    </div>
</asp:Content>

