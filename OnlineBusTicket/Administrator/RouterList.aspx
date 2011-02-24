<%@ Page Language="C#" MasterPageFile="~/Template/Administrator/MasterPage.master" AutoEventWireup="true" CodeFile="RouterList.aspx.cs" Inherits="Administrator_RouterList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Router List</title>
    <script type="text/javascript">
        $(document).ready(function() {
            var chkBox = $("input[id$=ChkAll]");
            chkBox.click(function() {
                $("#<%=gvRouterList.ClientID %> INPUT[type='checkbox']").attr('checked', chkBox.is(':checked'));
            });

            // To deselect CheckAll when a GridView CheckBox
            // is unchecked
            $("#<%=gvRouterList.ClientID %> INPUT[type='checkbox']").click(function(e) {
                if (!$(this)[0].checked) {
                    chkBox.attr("checked", false);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Router" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
			<h1 style="background-image:url(Image/review.png);">Router Manager: [Content]</h1>
			<div class="buttons">
                <asp:HyperLink ID="lnkInsert" runat="server" NavigateUrl="RouterAdd.aspx" CssClass="button"><span>New</span></asp:HyperLink>
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
                                    <asp:ListItem Value="0">RouterID (Increase)</asp:ListItem>
                                    <asp:ListItem Value="1">RouterName (Increase)</asp:ListItem>
                                    <asp:ListItem Value="2">Distance (Increase)</asp:ListItem>
                                    <asp:ListItem Value="6">Status (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="3">RouterID (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="4">RouterName (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="5">Distance (Decrease)</asp:ListItem>
                                    <asp:ListItem Value="7">Status (Increase)</asp:ListItem>
                                    
                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Enter Router Name: &nbsp;
                                <asp:TextBox ID="txtSearchRouter" runat="server" ValidationGroup="searchRouter" Width="250px" style="margin-top: 4px;"></asp:TextBox> <asp:LinkButton ID="lnkSearch" runat="server" CssClass="button" OnClick="lnkSearch_Click"><span>Search</span></asp:LinkButton>
                            </td>
                        </tr>
                    </tbody>
                  </table>
            </div>
		    <div id="form">
                <asp:GridView ID="gvRouterList" runat="server" CssClass="list" 
                    AutoGenerateColumns="False" AllowPaging="True"  
                    OnPageIndexChanging="gvRouterList_PageIndexChanging">
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
                        <asp:BoundField DataField="RouterID" HeaderText="Router ID" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>
                            <ItemStyle Width="6%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RouterName" HeaderText="Router Name" 
                            HeaderStyle-CssClass="left">
<HeaderStyle CssClass="left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="StartPlace" HeaderText="Start Place" HeaderStyle-CssClass="left">
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DestinationPlace" HeaderText="Destination Place" HeaderStyle-CssClass="left">
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Distance" HeaderText="Distance" HeaderStyle-CssClass="left"/>
                             <asp:CheckBoxField DataField="Status" HeaderText="Status">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:CheckBoxField>
                        <asp:TemplateField ItemStyle-CssClass="right" HeaderStyle-CssClass="right">
                            <HeaderTemplate>
                                Action
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text="[Edit]" NavigateUrl='<%#Eval("RouterID","RouterEdit.aspx?RouterID={0}") %>'></asp:HyperLink>
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

