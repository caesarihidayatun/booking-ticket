<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="BusAdd.aspx.cs" Inherits="Administrator_BusAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" 
            NavigateUrl="~/Administrator/Default.aspx">Home</asp:HyperLink> :: 
        <asp:HyperLink ID="hlkBus" runat="server" 
            NavigateUrl="~/Administrator/BusList.aspx">Bus</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
    <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">Bus: [New]</h1>
			<div class="buttons">
                <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="button" OnClick="lnkBtnSave_Click"><span>Save</span></asp:LinkButton>
                <asp:LinkButton ID="LnkReset" runat="server" CssClass="button" 
                    onclick="LnkReset_Click"><span>Reset</span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="button" PostBackUrl="BusList.aspx" CausesValidation="False"><span>Cancel</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <table class="form">
        		<tbody>
	            	<tr>
	              		<td width="15%">Bus Plate: </td>
	              		<td><asp:TextBox ID="BusPlate" runat="server" Width="125px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="BusPlate" ErrorMessage="Bus Plate is required." 
                                    ToolTip="Bus Plate is required.">*</asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
	            	<tr>
	              		<td>Bus Name: </td>
	              		<td><asp:TextBox ID="BusName" runat="server" Width="250px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="BusName" ErrorMessage="Bus Name is required." 
                                    ToolTip="Bus Name is required.">*</asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
	            		            	<tr>
	              		<td>Seat: </td>
	              		<td><asp:TextBox ID="Seat" runat="server" Width="125px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="Seat" ErrorMessage="Seat is required." 
                                    ToolTip="Seat is required.">*</asp:RequiredFieldValidator>&nbsp;
	              		    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="!!!Seat must be a number" ControlToValidate="Seat" 
                                ValidationExpression="(^-?\d\d*\.\d*$)|(^-?\d\d*$)|(^-?\.\d\d*$)"></asp:RegularExpressionValidator>
	              		</td>
	            	</tr>
	            		            		            	<tr>
	              		<td>Bus Type: </td>
	              		<td>
	              		    <asp:DropDownList ID="ddlBusType" runat="server" Width="250px">
                            </asp:DropDownList>
	              		</td>
	            	</tr>
	            		            		            	<tr>
	              		<td>Category: </td>
	              		<td>
	              		    <asp:DropDownList ID="ddlCategory" runat="server" Width="250px">
                            </asp:DropDownList>
	              		</td>
	            	</tr>
	            	
        		</tbody>
       		</table>
	    </div>
    	<!-- /content -->
	</div>
</asp:Content>

