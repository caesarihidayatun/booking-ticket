<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="ListBus.aspx.cs" Inherits="Administrator_ListBus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>List Bus</title>
    <script type="text/javascript">
        $(document).ready(function() {
            var chkBox = $("input[id$=ChkAll]");
            chkBox.click(function() {
                $("#<%=gvListBusList.ClientID %> INPUT[type='checkbox']").attr('checked', chkBox.is(':checked'));
            });

            // To deselect CheckAll when a GridView CheckBox
            // is unchecked
            $("#<%=gvListBusList.ClientID %> INPUT[type='checkbox']").click(function(e) {
                if (!$(this)[0].checked) {
                    chkBox.attr("checked", false);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ListBus" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
			<h1 style="background-image:url(Image/review.png);">List Bus Manager: [Content]</h1>
			<div class="buttons">
			    <asp:LinkButton ID="lnkExpired" runat="server" CssClass="button" 
                    onclick="lnkExpired_Click"><span>Expired</span></asp:LinkButton>
                <asp:HyperLink ID="lnkInsert" runat="server" NavigateUrl="ListBusAdd.aspx" CssClass="button"><span>New</span></asp:HyperLink>
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
                                    <asp:ListItem Value="0">Departure (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="1">Price (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="2">Status (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="3">Departure (Increase)</asp:ListItem>
                                    <asp:ListItem Value="4">Price (Increase)</asp:ListItem>
                                    <asp:ListItem Value="5">Status (Increase)</asp:ListItem>
                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Enter ListBus ID:&nbsp;
                                <asp:TextBox ID="txtSearchListBus" runat="server" Width="250px" style="margin-top: 4px;"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button" OnClick="lnkSearch_Click"><span>Search</span></asp:LinkButton>
                                
                            </td>
                        </tr>
                    </tbody>
                  </table>
            </div>
		    <div id="form">
                <asp:GridView ID="gvListBusList" runat="server" CssClass="list" 
                    AutoGenerateColumns="False" AllowPaging="True"  
                    OnPageIndexChanging="gvListBusList_PageIndexChanging" 
                    onrowdatabound="gvListBusList_RowDataBound">
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
                        <asp:BoundField DataField="ListBusID" HeaderText="ListBus ID" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>
                            <ItemStyle Width="8%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Router Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ListBusName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" 
                                    Value='<%# Eval("RouterID") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bus Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StartPlace") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                <asp:HiddenField ID="HiddenField2" runat="server" 
                                    Value='<%# Eval("BusPlate") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="left" />
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Departure" HeaderText="Departure" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>

                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Arrival" HeaderText="Arrival" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>
                             <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Price" HeaderText="Price ($)" 
                            HeaderStyle-CssClass="left">
                            <HeaderStyle CssClass="left" />
                            <ItemStyle Width="8%" />
                        </asp:BoundField>
                             <asp:CheckBoxField DataField="Status" HeaderText="Status">
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:CheckBoxField>
                        <asp:TemplateField ItemStyle-CssClass="right" HeaderStyle-CssClass="right">
                            <HeaderTemplate>
                                Action
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text="[Edit]" NavigateUrl='<%#Eval("ListBusID","ListBusEdit.aspx?ListBusID={0}") %>'></asp:HyperLink>
                            </ItemTemplate>

<HeaderStyle CssClass="right" HorizontalAlign="Center"></HeaderStyle>

<ItemStyle CssClass="right" HorizontalAlign="Center" Width="8%"></ItemStyle>
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

