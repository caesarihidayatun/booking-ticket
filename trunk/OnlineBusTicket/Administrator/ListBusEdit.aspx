<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="ListBusEdit.aspx.cs" Inherits="Administrator_ListBusEdit" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>List Bus Edit</title>
    
    <link type="text/css" href="../Template/Scripts/JQuery/themes/base/jquery.ui.all.css" rel="stylesheet" />
    
	<script type='text/javascript' src='../Template/Scripts/JQuery/jquery-1.4.4.js'></script>
	<script type='text/javascript' src='../Template/Scripts/JQuery/ui/jquery.ui.core.js'></script>
	<script type='text/javascript' src='../Template/Scripts/JQuery/ui/jquery.ui.widget.js'></script>
	<script type='text/javascript' src='../Template/Scripts/JQuery/ui/jquery.ui.datepicker.js'></script>
    
       
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $("#<%=txtDeparture.ClientID %>").datepicker({showOn: 'button',buttonImage: '../Images/calendar.png',buttonImageOnly: true });
            $("#<%=txtArrival.ClientID %>").datepicker({showOn: 'button',buttonImage: '../Images/calendar.png',buttonImageOnly: true });
        });    
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Admin/Pages/Default.aspx">Home</asp:HyperLink> :: <asp:HyperLink ID="hlkCategory" runat="server" NavigateUrl="~/Admin/Pages/ListBusList.aspx">List Bus</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
        <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">List Bus [Edit]</h1>
			<div class="buttons">
                <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="button" OnClick="lnkBtnSave_Click"><span>Update</span></asp:LinkButton>
                <asp:LinkButton ID="LnkReset" runat="server" CssClass="button" 
                    onclick="LnkReset_Click"><span>Reset</span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="button" PostBackUrl="ListBus.aspx"><span>Cancel</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <table class="form">
        		<tbody>
        		    <tr>
	              		<td width="15%" >Router:</td>
	              		<td>
	              		    <asp:DropDownList runat="server" ID="ddlRouter" 
                                Width="250px" AppendDataBoundItems="True">
                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>&nbsp;
	              		    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToValidate="ddlRouter" ErrorMessage="!!!Router is required." 
                                Operator="NotEqual" ValueToCompare="-1" Display="Dynamic"></asp:CompareValidator>
	              		</td>
	            	</tr>
	            	<tr>
	              		<td >Bus:</td>
	              		<td>
	              		    <asp:DropDownList runat="server" ID="ddlBus" Width="250px" 
                                AppendDataBoundItems="True">
                                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>&nbsp;
	              		    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                ControlToValidate="ddlBus" ErrorMessage="!!!Bus is required." 
                                Operator="NotEqual" ValueToCompare="-1" Display="Dynamic"></asp:CompareValidator>
	              		</td>
	            	</tr>
	            	<tr>
	              		<td >Departure:</td>
	              		<td>
	              		    <asp:TextBox runat="server" ID="txtDeparture" style="width:200px"></asp:TextBox>
                              <asp:DropDownList ID="ddlStartTime" runat="server">
                                <asp:ListItem value="12:00 AM">12:00 AM</asp:ListItem>
						        <asp:ListItem value="12:30 AM">12:30 AM</asp:ListItem>
						        <asp:ListItem value="1:00 AM">1:00 AM</asp:ListItem>
						        <asp:ListItem value="1:30 AM">1:30 AM</asp:ListItem>
						        <asp:ListItem value="2:00 AM">2:00 AM</asp:ListItem>
						        <asp:ListItem value="2:30 AM">2:30 AM</asp:ListItem>
						        <asp:ListItem value="3:00 AM">3:00 AM</asp:ListItem>
						        <asp:ListItem value="3:30 AM">3:30 AM</asp:ListItem>
						        <asp:ListItem value="4:00 AM">4:00 AM</asp:ListItem>
						        <asp:ListItem value="4:30 AM">4:30 AM</asp:ListItem>
						        <asp:ListItem value="5:00 AM">5:00 AM</asp:ListItem>
						        <asp:ListItem value="5:30 AM">5:30 AM</asp:ListItem>
						        <asp:ListItem value="6:00 AM">6:00 AM</asp:ListItem>
						        <asp:ListItem value="6:30 AM">6:30 AM</asp:ListItem>
						        <asp:ListItem value="7:00 AM">7:00 AM</asp:ListItem>
						        <asp:ListItem value="7:30 AM">7:30 AM</asp:ListItem>
						        <asp:ListItem value="8:00 AM">8:00 AM</asp:ListItem>
						        <asp:ListItem value="8:30 AM">8:30 AM</asp:ListItem>
						        <asp:ListItem value="9:00 AM">9:00 AM</asp:ListItem>
						        <asp:ListItem value="9:30 AM">9:30 AM</asp:ListItem>
						        <asp:ListItem value="10:00 AM">10:00 AM</asp:ListItem>
						        <asp:ListItem value="10:30 AM">10:30 AM</asp:ListItem>
						        <asp:ListItem value="11:00 AM">11:00 AM</asp:ListItem>
						        <asp:ListItem value="11:30 AM">11:30 AM</asp:ListItem>
						        <asp:ListItem value="12:00 AM">12:00 pm</asp:ListItem>
						        <asp:ListItem value="12:30 AM">12:30 pm</asp:ListItem>
						        <asp:ListItem value="1:00 PM">1:00 PM</asp:ListItem>
						        <asp:ListItem value="1:30 PM">1:30 PM</asp:ListItem>
						        <asp:ListItem value="2:00 PM">2:00 PM</asp:ListItem>
						        <asp:ListItem value="2:30 PM">2:30 PM</asp:ListItem>
						        <asp:ListItem value="3:00 PM">3:00 PM</asp:ListItem>
						        <asp:ListItem value="3:30 PM">3:30 PM</asp:ListItem>
						        <asp:ListItem value="4:00 PM">4:00 PM</asp:ListItem>
						        <asp:ListItem value="4:30 PM">4:30 PM</asp:ListItem>
						        <asp:ListItem value="5:00 PM">5:00 PM</asp:ListItem>
						        <asp:ListItem value="5:30 PM">5:30 PM</asp:ListItem>
						        <asp:ListItem value="6:00 PM">6:00 PM</asp:ListItem>
						        <asp:ListItem value="6:30 PM">6:30 PM</asp:ListItem>
						        <asp:ListItem value="7:00 PM">7:00 PM</asp:ListItem>
						        <asp:ListItem value="7:30 PM">7:30 PM</asp:ListItem>
						        <asp:ListItem value="8:00 PM">8:00 PM</asp:ListItem>
						        <asp:ListItem value="8:30 PM">8:30 PM</asp:ListItem>
						        <asp:ListItem value="9:00 PM">9:00 PM</asp:ListItem>
						        <asp:ListItem value="9:30 PM">9:30 PM</asp:ListItem>
						        <asp:ListItem value="10:00 PM">10:00 PM</asp:ListItem>
						        <asp:ListItem value="11:30 PM">10:30 PM</asp:ListItem>
						        <asp:ListItem value="11:00 PM">11:00 PM</asp:ListItem>
						        <asp:ListItem value="11:30 PM">11:30 PM</asp:ListItem>
                              </asp:DropDownList> &nbsp;
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="!!!Departure is required." ControlToValidate="txtDeparture" 
                                Display="Dynamic"></asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
	            	<tr>
	              		<td >Arrival:</td>
	              		<td>
	              		    <asp:TextBox runat="server" ID="txtArrival" style="width:200px"></asp:TextBox>
	              		    <asp:DropDownList ID="ddlEndTime" runat="server">
                                <asp:ListItem value="12:00 AM">12:00 AM</asp:ListItem>
						        <asp:ListItem value="12:30 AM">12:30 AM</asp:ListItem>
						        <asp:ListItem value="1:00 AM">1:00 AM</asp:ListItem>
						        <asp:ListItem value="1:30 AM">1:30 AM</asp:ListItem>
						        <asp:ListItem value="2:00 AM">2:00 AM</asp:ListItem>
						        <asp:ListItem value="2:30 AM">2:30 AM</asp:ListItem>
						        <asp:ListItem value="3:00 AM">3:00 AM</asp:ListItem>
						        <asp:ListItem value="3:30 AM">3:30 AM</asp:ListItem>
						        <asp:ListItem value="4:00 AM">4:00 AM</asp:ListItem>
						        <asp:ListItem value="4:30 AM">4:30 AM</asp:ListItem>
						        <asp:ListItem value="5:00 AM">5:00 AM</asp:ListItem>
						        <asp:ListItem value="5:30 AM">5:30 AM</asp:ListItem>
						        <asp:ListItem value="6:00 AM">6:00 AM</asp:ListItem>
						        <asp:ListItem value="6:30 AM">6:30 AM</asp:ListItem>
						        <asp:ListItem value="7:00 AM">7:00 AM</asp:ListItem>
						        <asp:ListItem value="7:30 AM">7:30 AM</asp:ListItem>
						        <asp:ListItem value="8:00 AM">8:00 AM</asp:ListItem>
						        <asp:ListItem value="8:30 AM">8:30 AM</asp:ListItem>
						        <asp:ListItem value="9:00 AM">9:00 AM</asp:ListItem>
						        <asp:ListItem value="9:30 AM">9:30 AM</asp:ListItem>
						        <asp:ListItem value="10:00 AM">10:00 AM</asp:ListItem>
						        <asp:ListItem value="10:30 AM">10:30 AM</asp:ListItem>
						        <asp:ListItem value="11:00 AM">11:00 AM</asp:ListItem>
						        <asp:ListItem value="11:30 AM">11:30 AM</asp:ListItem>
						        <asp:ListItem value="12:00 AM">12:00 pm</asp:ListItem>
						        <asp:ListItem value="12:30 AM">12:30 pm</asp:ListItem>
						        <asp:ListItem value="1:00 PM">1:00 PM</asp:ListItem>
						        <asp:ListItem value="1:30 PM">1:30 PM</asp:ListItem>
						        <asp:ListItem value="2:00 PM">2:00 PM</asp:ListItem>
						        <asp:ListItem value="2:30 PM">2:30 PM</asp:ListItem>
						        <asp:ListItem value="3:00 PM">3:00 PM</asp:ListItem>
						        <asp:ListItem value="3:30 PM">3:30 PM</asp:ListItem>
						        <asp:ListItem value="4:00 PM">4:00 PM</asp:ListItem>
						        <asp:ListItem value="4:30 PM">4:30 PM</asp:ListItem>
						        <asp:ListItem value="5:00 PM">5:00 PM</asp:ListItem>
						        <asp:ListItem value="5:30 PM">5:30 PM</asp:ListItem>
						        <asp:ListItem value="6:00 PM">6:00 PM</asp:ListItem>
						        <asp:ListItem value="6:30 PM">6:30 PM</asp:ListItem>
						        <asp:ListItem value="7:00 PM">7:00 PM</asp:ListItem>
						        <asp:ListItem value="7:30 PM">7:30 PM</asp:ListItem>
						        <asp:ListItem value="8:00 PM">8:00 PM</asp:ListItem>
						        <asp:ListItem value="8:30 PM">8:30 PM</asp:ListItem>
						        <asp:ListItem value="9:00 PM">9:00 PM</asp:ListItem>
						        <asp:ListItem value="9:30 PM">9:30 PM</asp:ListItem>
						        <asp:ListItem value="10:00 PM">10:00 PM</asp:ListItem>
						        <asp:ListItem value="11:30 PM">10:30 PM</asp:ListItem>
						        <asp:ListItem value="11:00 PM">11:00 PM</asp:ListItem>
						        <asp:ListItem value="11:30 PM">11:30 PM</asp:ListItem>
                              </asp:DropDownList>&nbsp;
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="!!!Arrival is required." ControlToValidate="txtArrival" 
                                Display="Dynamic"></asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
	            	<tr>
	              		<td >Price:</td>
	              		<td>
	              		    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
	              		     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtPrice" ErrorMessage="Price is required." 
                                    ToolTip="Price is required.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="!!!Price must be a number" ControlToValidate="txtPrice" 
                                ValidationExpression="(^-?\d\d*\.\d*$)|(^-?\d\d*$)|(^-?\.\d\d*$)" 
                                Display="Dynamic"></asp:RegularExpressionValidator>
	              		    
	              		</td>
	            	</tr>
	            	<tr>
	            	    <td></td>
	            	        <td>
                                <asp:CheckBox ID="cbStatus" runat="server" Text="Status" /> </td>
	            	</tr>
        		</tbody>
       		</table>
	    </div>
    	<!-- /content -->
	</div>
</asp:Content>

