<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="Administrator_CategoryEdit" Title="Category Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" 
            NavigateUrl="~/Administrator/Default.aspx">Home</asp:HyperLink> :: 
        <asp:HyperLink ID="hlkCategory" runat="server" 
            NavigateUrl="~/Administrator/CategoryList.aspx">Category</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
    <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">Category: [Edit]</h1> 
			<div class="buttons">
                <asp:LinkButton ID="lnkBtnUpdate" runat="server" CssClass="button" OnClick="lnkUpdate_Click"><span>Update</span></asp:LinkButton>
                <asp:LinkButton ID="LnkReset" runat="server" CssClass="button" 
                    onclick="LnkReset_Click"><span>Reset</span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="button" PostBackUrl="CategoryList.aspx"><span>Cancel</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <table class="form">
        		<tbody>
	            	<tr>
	              		<td width="10%">Category Name: </td>
	              		<td>
	              		    <asp:TextBox ID="CategoryName" runat="server" Width="250px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="CategoryName" ErrorMessage="Category Name is required." 
                                    ToolTip="Category Name is required.">*</asp:RequiredFieldValidator>
	              		</td> 
	             	</tr>
	            	<tr>
	            	<td></td>
	            	<td>
	            	    <asp:CheckBox ID="cbStatus" runat="server" Text="Status" />
	            	</td>
	            	</tr>
        		</tbody>
       		</table>
	    </div>
    	<!-- /content -->
	</div>
</asp:Content>

