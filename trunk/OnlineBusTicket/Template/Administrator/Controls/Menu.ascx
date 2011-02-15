<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Admin_Controls_Menu" %>
<asp:Literal ID="litMenu" runat="server"></asp:Literal>
<ul class="nav right sf-js-enabled" style="display: block;">
    <li id="store" class="">
        <asp:HyperLink ID="hlkWebsite" runat="server" CssClass="top" NavigateUrl="~/Default.aspx">Visit Website</asp:HyperLink>
        <ul style="display: block; visibility: hidden;"></ul>
    </li>
    <li id="Li1" class="">
        <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click" CssClass="top">Logout</asp:LinkButton>
    </li>
    <li id="changepass" class="">
        <asp:HyperLink ID="hplChangePass" runat="server" CssClass="top" NavigateUrl="~/Admin/Pages/ChangPassword.aspx">ChangePassword</asp:HyperLink>
    </li>
    <li id="updateprofile" class="">
        <asp:HyperLink ID="hplupdateprofile" runat="server" CssClass="top" NavigateUrl="~/Admin/Pages/UpdateProfile.aspx">Profile</asp:HyperLink>
    </li>
     
</ul>
<script type="text/javascript"><!--
    $(document).ready(function() {
	    $('.nav').superfish({
		    hoverClass	 : 'sfHover',
		    pathClass	 : 'overideThisToUse',
		    delay		 : 0,
		    animation	 : {height: 'show'},
		    speed		 : 'normal',
		    autoArrows   : false,
		    dropShadows  : false, 
		    disableHI	 : false, /* set to true to disable hoverIntent detection */
		    onInit		 : function(){},
		    onBeforeShow : function(){},
		    onShow		 : function(){},
		    onHide		 : function(){}
	    });
    	
	    $('.nav').css('display', 'block');
    });
//--></script>
