<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
		<!-- header -->
		<div id="header">
			<div class="div1">
				<img src="Images/logo.png" alt="Administration" onclick="location = '#'" />
			</div>
		</div>
		<!-- /header -->
		
    	<!-- content -->
		<div id="content">
			<div style="width: 325px; min-height: 300px; margin-top: 40px; margin-left: auto; margin-right: auto;" class="box">
              <div class="left"></div>
              <div class="right"></div>
              <div class="heading">
                <h1 style="background-image: url(Images/lockscreen.png);">Please enter your login details.</h1>
              </div>
              <div style="min-height: 150px;" class="content">
                  <asp:Panel ID="palMessageError" runat="server" style="padding: 3px;" >
                      <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                  </asp:Panel>
                    <div id="form">
                      <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td rowspan="4" style="text-align: center;"><img alt="Please enter your login details." src="Images/login.png" /></td>
                            </tr>
                            <tr>
                                <td>Username:<br />
                                    <asp:TextBox ID="username" runat="server" style="margin-top: 4px;"></asp:TextBox>
                                    <br />
                                    <br />
                                    Password:<br />
                                    <asp:TextBox ID="password" runat="server" style="margin-top: 4px;" TextMode="Password"></asp:TextBox>
                               </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    <asp:LinkButton ID="lnkLogin" runat="server" CssClass="button" OnClick="lnkLogin_Click"><span>Login</span></asp:LinkButton>
                                </td>
                            </tr>
                      </tbody>
                      </table>
                   </div>
              </div>
            </div>
		</div>
		<!-- /content -->
	</div>
	<!-- /container -->
	
	<div id="footer">
  		Online Bus Ticket &nbsp;© 2009-2010 All Rights Reserved.<br />Version 1.0
  	</div>
    </form>
</body>
</html>
