<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="BustypeList.aspx.cs" Inherits="Administrator_BusTypeList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>BustypeList List</title>
    <script type="text/javascript">
        $(document).ready(function() {
            var chkBox = $("input[id$=ChkAll]");
            chkBox.click(function() {
                $("#<%=gvBusTypeList.ClientID %> INPUT[type='checkbox']").attr('checked', chkBox.is(':checked'));
            });

            // To deselect CheckAll when a GridView CheckBox
            // is unchecked
            $("#<%=gvBusTypeList.ClientID %> INPUT[type='checkbox']").click(function(e) {
                if (!$(this)[0].checked) {
                    chkBox.attr("checked", false);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="BusType" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- breadcrumb -->
	<div class="breadcrumb">
		<asp:HyperLink ID="lnkHome" runat="server" 
            NavigateUrl="~/Administrator/Default.aspx">Home</asp:HyperLink>
	</div>
	<!-- /breadcrumb -->
	  		
    <div class="box">
		<div class="left"></div>
		<div class="right"></div>
		<div class="heading">
			<h1 style="background-image:url(Image/review.png);">BusType Manager: [Content]</h1>
			<div class="buttons">
                <asp:HyperLink ID="lnkInsert" runat="server" NavigateUrl="BusTypeAdd.aspx" CssClass="button"><span>New</span></asp:HyperLink>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="button" OnClick="lnkDelete_Click"><span>Delete</span></asp:LinkButton>
			</div>
		</div>
		<div class="content">
		    <div style="background: none repeat scroll 0% 0% rgb(231, 239, 239); border: 1px solid rgb(198, 215, 215); padding: 3px; margin-bottom: 15px;">
                <table width="100%" cellspacing="0" cellpadding="6">
                    <tbody>
                        <tr>
                            <td>
                               
                Order By:&nbsp;<asp:DropDownList ID="ddlOrderBy" 
                                    runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                    <asp:ListItem Value="0">BusTypeID (Increase)</asp:ListItem>
                                    <asp:ListItem Value="2">Type (Increase)</asp:ListItem>
                                    <asp:ListItem Value="1">BusTypeID (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="3">Type (Decrease)</asp:ListItem>
                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Enter Type: &nbsp;
                                <asp:TextBox ID="txtSearchBusType" runat="server" ValidationGroup="searchBusType" Width="250px" style="margin-top: 4px;"></asp:TextBox> <asp:LinkButton ID="lnkSearch" runat="server" CssClass="button" OnClick="lnkSearch_Click"><span>Search</span></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                  </table>
            </div>
		    <div id="form">
                <asp:GridView ID="gvBusTypeList" runat="server" CssClass="list" 
                    AutoGenerateColumns="False" AllowPaging="True"  
                    OnPageIndexChanging="gvBusTypeList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="1px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="ChkAll" runat="server" CssClass="ChkAll"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSel" runat="server" />
                            </ItemTemplate>

<HeaderStyle Width="1px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BusTypeID" HeaderText="BusType ID" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Type" HeaderText="Type" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="Status" HeaderText="Status">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:TemplateField ItemStyle-CssClass="right" HeaderStyle-CssClass="right">
                            <HeaderTemplate>
                                Action
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text="[Edit]" NavigateUrl='<%#Eval("BusTypeID","BusTypeEdit.aspx?BusTypeID={0}") %>'></asp:HyperLink>
                            </ItemTemplate>

<HeaderStyle CssClass="right" HorizontalAlign="Center"></HeaderStyle>

<ItemStyle CssClass="right" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                        <EmptyDataTemplate>
        No results! 
    
    </EmptyDataTemplate>
                </asp:GridView>
                Total of records: &nbsp;<asp:Label ID="total" runat="server" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
		    </div>
	</div>
	<!-- /content -->
		
	</div>
</asp:Content>

