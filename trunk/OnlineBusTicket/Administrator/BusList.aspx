<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="BusList.aspx.cs" Inherits="Administrator_BusList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Bus List</title>
    <script type="text/javascript">
        $(document).ready(function() {
            var chkBox = $("input[id$=ChkAll]");
            chkBox.click(function() {
                $("#<%=gvBusList.ClientID %> INPUT[type='checkbox']").attr('checked', chkBox.is(':checked'));
            });

            // To deselect CheckAll when a GridView CheckBox
            // is unchecked
            $("#<%=gvBusList.ClientID %> INPUT[type='checkbox']").click(function(e) {
                if (!$(this)[0].checked) {
                    chkBox.attr("checked", false);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Bus" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
			<h1 style="background-image:url(Image/review.png);">Bus Manager: [Content]</h1>
			<div class="buttons">
                <asp:HyperLink ID="lnkInsert" runat="server" NavigateUrl="BusAdd.aspx" CssClass="button"><span>New</span></asp:HyperLink>
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
                                    onselectedindexchanged="ddlOrderBy_SelectedIndexChanged">
                                    <asp:ListItem Value="0">BusName (Increase)</asp:ListItem>
                                    <asp:ListItem Value="1">BusPlate (Increase)</asp:ListItem>
                                    <asp:ListItem Value="2">Seat (Increase)</asp:ListItem>
                                     <asp:ListItem Value="3">BusName (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="4">BusPlate (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="5">Seat (Decrease)</asp:ListItem>
                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Search by:&nbsp;<asp:DropDownList ID="DropDownList1" Width="100" runat="server">
                                    <asp:ListItem Value="0">Bus Name</asp:ListItem> 
                                    <asp:ListItem Value="1">Bus Plate</asp:ListItem>
                                </asp:DropDownList> &nbsp; Key: &nbsp;
                                <asp:TextBox ID="txtSearchBus" runat="server" ValidationGroup="searchBus" Width="250px" style="margin-top: 4px;"></asp:TextBox> <asp:LinkButton ID="lnkSearch" runat="server" CssClass="button" OnClick="lnkSearch_Click"><span>Search</span></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                  </table>
            </div>
		    <div id="form">
                <asp:GridView ID="gvBusList" runat="server" CssClass="list" 
                    AutoGenerateColumns="False" AllowPaging="True"  
                    OnPageIndexChanging="gvBusList_PageIndexChanging" 
                    onrowdatabound="gvBusList_RowDataBound">
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
                        <asp:BoundField DataField="BusName" HeaderText="Bus Name" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BusPlate" HeaderText="Bus Plate">
                            <HeaderStyle CssClass="left" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Seat" HeaderText="Seat">
                            <HeaderStyle CssClass="left" />
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Bus type">
                            <ItemTemplate>
                                <asp:Label ID="lblBusType" runat="server"></asp:Label>
                                <asp:HiddenField ID="hfBusType" runat="server" 
                                    Value='<%# Eval("BusTypeID") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="left" />
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                <asp:HiddenField ID="hfCategory" runat="server" 
                                    Value='<%# Eval("CategoryID") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="left" />
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="Status" HeaderText="Status">
                            <ItemStyle HorizontalAlign="Center" Width="10%"/>
                        </asp:CheckBoxField>
                        <asp:TemplateField ItemStyle-CssClass="right" HeaderStyle-CssClass="right">
                            <HeaderTemplate>
                                Action
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text="[Edit]" NavigateUrl='<%#Eval("BusPlate","BusEdit.aspx?BusPlate={0}") %>'></asp:HyperLink>
                            </ItemTemplate>

<HeaderStyle CssClass="right" HorizontalAlign="Center"></HeaderStyle>

<ItemStyle CssClass="right" HorizontalAlign="Center" Width="10%"></ItemStyle>
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

