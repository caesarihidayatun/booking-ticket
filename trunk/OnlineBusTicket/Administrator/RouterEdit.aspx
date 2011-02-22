<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="RouterEdit.aspx.cs" Inherits="Administrator_RouterEdit" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" 
            NavigateUrl="~/Administrator/Default.aspx">Home</asp:HyperLink> :: 
        <asp:HyperLink ID="hlkRouter" runat="server" 
            NavigateUrl="~/Administrator/RouterList.aspx">Router</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
    <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">Router: [Edit]</h1>
			<div class="buttons">
                <asp:LinkButton ID="lnkBtnSave" runat="server" CssClass="button" OnClick="lnkBtnSave_Click"><span>Update</span></asp:LinkButton>
                <asp:LinkButton ID="LnkReset" runat="server" CssClass="button" 
                    onclick="LnkReset_Click"><span>Reset</span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="button" PostBackUrl="RouterList.aspx" CausesValidation="False"><span>Cancel</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <table class="form">
        		<tbody>
	            	<tr>
	              		<td width="16%">Router Name: </td>
	              		<td><asp:TextBox ID="RouterName" runat="server" Width="250px"></asp:TextBox>
	              		    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="RouterName" ErrorMessage="Router Name is required." 
                                    ToolTip="Router Name is required.">*</asp:RequiredFieldValidator>
	              		</td>
	            	</tr>
	            	<tr>
	              		<td width="16%">Start Place: </td>
	              		<td>
                              <asp:DropDownList ID="ddlStartPlace" runat="server" Width="150px">
                              </asp:DropDownList>
	              		</td>
	            	</tr>
	            		            	<tr>
	              		<td width="16%" class="style1">Destination Place: </td>
	              		<td class="style1">
                              <asp:DropDownList ID="ddlDesPlace" runat="server" Width="150px">
                              </asp:DropDownList>&nbsp;
	              		      <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                  ControlToCompare="ddlDesPlace" ControlToValidate="ddlStartPlace" 
                                  ErrorMessage="!!!Start Place and Destination Place are not the same." 
                                  Operator="NotEqual"></asp:CompareValidator>
	              		</td>
	            	</tr>
	            	<tr>
	            	    <td>Distance (KM):</td>
	            	    <td> 
                            <asp:TextBox ID="txtDistance" runat="server" Width="100px"></asp:TextBox>&nbsp;
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtDistance" ErrorMessage="Distance is required." 
                                    ToolTip="Distance is required.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="!!!Distance must be a number" ControlToValidate="txtDistance" 
                                ValidationExpression="(^-?\d\d*\.\d*$)|(^-?\d\d*$)|(^-?\.\d\d*$)"></asp:RegularExpressionValidator>
                                </td>
	            	</tr>
	            	<tr>
	            	    <td>Description:</td>
	            	    <td> 
                            <asp:TextBox ID="txtDescription" runat="server" Height="100px" 
                                TextMode="MultiLine" Width="250px"></asp:TextBox>
                        </td>
	            	</tr>
	            	<tr>
	            	    <td></td>
	            	    <td> 
                            <asp:CheckBox ID="cbStatus" runat="server" Text="Status" /></td>
	            	</tr>
	            	
        		</tbody>
       		</table>
	    </div>
    	<!-- /content -->
	</div>
</asp:Content>

