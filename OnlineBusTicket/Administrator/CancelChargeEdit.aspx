<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="CancelChargeEdit.aspx.cs" Inherits="Administrator_CancelChargeEdit" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" 
            NavigateUrl="~/Administrator/Default.aspx">Home</asp:HyperLink> :: 
        <asp:HyperLink ID="hlkCancelCharge" runat="server" 
            NavigateUrl="~/Administrator/CancelChargeList.aspx">Cancel Charge</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
    <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">Cancel Charge: [Edit]</h1>
			<div class="buttons">
                <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="button" OnClick="lnkBtnSave_Click"><span>Update</span></asp:LinkButton>
                <asp:LinkButton ID="LnkReset" runat="server" CssClass="button" 
                    onclick="LnkReset_Click"><span>Reset</span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="button" PostBackUrl="CancelChargeList.aspx" CausesValidation="False"><span>Cancel</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <table class="form">
        		<tbody>
	            	<tr>
	              		<td width="16%">Cancel Charge Name: </td>
	              		<td><asp:TextBox ID="CancelChargeName" runat="server" Width="250px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="CancelChargeName" ErrorMessage="CancelCharge Name is required." 
                                    ToolTip="CancelCharge Name is required.">*</asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
	            	<tr>
	              		<td width="16%">Percent Price: </td>
	              		<td><asp:TextBox ID="PercentPrice" runat="server" Width="150px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="PercentPrice" ErrorMessage="Percent Price is required." 
                                    ToolTip="Percent Price is required.">*</asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="PercentPrice" 
                                ErrorMessage="!!!Value of Percent Price should be in the range from 0 to 100" 
                                MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
	              		</td>
	            	</tr>
	            		            	<tr>
	              		<td width="16%">Date cancel: </td>
	              		<td><asp:TextBox ID="DateCancel" runat="server" Width="150px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="DateCancel" ErrorMessage="Date Cancel is required." 
                                    ToolTip="Date Cancel is required.">*</asp:RequiredFieldValidator>
                                    
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="!!!Date Cancel must be a number" ControlToValidate="DateCancel" 
                                ValidationExpression="(^-?\d\d*\.\d*$)|(^-?\d\d*$)|(^-?\.\d\d*$)"></asp:RegularExpressionValidator>
	              		</td>
	            	</tr>
	            	<tr>
	            	<td>        	</td>
	            	<td> 
                        <asp:CheckBox ID="cbStatus" runat="server" Text="Status" /></td>
	            	</tr>
        		</tbody>
       		</table>
	    </div>
    	<!-- /content -->
	</div>
</asp:Content>

