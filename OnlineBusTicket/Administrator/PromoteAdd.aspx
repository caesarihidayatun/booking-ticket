<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="PromoteAdd.aspx.cs" Inherits="Administrator_PromoteAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" 
            NavigateUrl="~/Administrator/Default.aspx">Home</asp:HyperLink> :: 
        <asp:HyperLink ID="hlkPromote" runat="server" 
            NavigateUrl="~/Administrator/PromoteList.aspx">Promote</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
    <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">Promote: [New]</h1>
			<div class="buttons">
                <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="button" OnClick="lnkBtnSave_Click"><span>Save</span></asp:LinkButton>
                <asp:LinkButton ID="LnkReset" runat="server" CssClass="button" 
                    onclick="LnkReset_Click"><span>Reset</span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="button" PostBackUrl="PromoteList.aspx" CausesValidation="False"><span>Cancel</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <table class="form">
        		<tbody>
	            	<tr>
	              		<td>Promote Name: </td>
	              		<td><asp:TextBox ID="PromoteName" runat="server" Width="250px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="PromoteName" ErrorMessage="Promote Name is required." 
                                    ToolTip="Promote Name is required.">*</asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
	            		            	<tr>
	              		<td>Discount(%) : </td>
	              		<td><asp:TextBox ID="Discount" runat="server" Width="125px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="Discount" ErrorMessage="Discount is required." 
                                    ToolTip="Discount is required.">*</asp:RequiredFieldValidator>&nbsp;
	              		    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="Discount" 
                                ErrorMessage="Value of Discount should be in the range from 0 to 100" 
                                MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
	              		</td>
	            	</tr>
	            		            		            		            	
        		</tbody>
       		</table>
	    </div>
    	<!-- /content -->
	</div>
</asp:Content>

