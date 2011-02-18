<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="BusTypeAdd.aspx.cs" Inherits="Administrator_BusTypeAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" 
            NavigateUrl="~/Administrator/Default.aspx">Home</asp:HyperLink> :: 
        <asp:HyperLink ID="hlkBusType" runat="server" 
            NavigateUrl="~/Administrator/BustypeList.aspx">BusType</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
    <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">BusType: [New]</h1>
			<div class="buttons">
                <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="button" OnClick="lnkBtnSave_Click"><span>Save</span></asp:LinkButton>
                <asp:LinkButton ID="LnkReset" runat="server" CssClass="button" 
                    onclick="LnkReset_Click"><span>Reset</span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="button" PostBackUrl="BustypeList.aspx" CausesValidation="False"><span>Cancel</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <table class="form">
        		<tbody>
	            	<tr>
	              		<td width="10%">Type name: </td>
	              		<td><asp:TextBox ID="Type" runat="server" Width="250px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="Type" ErrorMessage="Type name is required." 
                                    ToolTip="Type name is required.">*</asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
        		</tbody>
       		</table>
	    </div>
    	<!-- /content -->
	</div>
</asp:Content>

