using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_Controls_Menu : System.Web.UI.UserControl
{
    
    //string username = string.Empty;
    //AccountBUS _accountBUS = new AccountBUS();
    protected void Page_Load(object sender, EventArgs e)
    {

        string menuAdmin ="<ul class='nav left sf-js-enabled' style='display: block;'>"+
	                    "<li id='dashboard><a href='../Administrator/Default.aspx' class='top'>Home</a></li>"+
	                    "<li id='catalog'><a class='top'>Catalog</a>"+
		                    "<ul style='display: none; visibility: hidden;'>"+
			                    "<li><a href='../Administrator/CategoryList.aspx'>Category</a></li>"+
			                    "<li><a href='../Administrator/BustypeList.aspx'>Bus Type</a></li>"+
			                    "<li><a href='../Administrator/BusList.aspx'>Bus</a></li>"+
			                    "<li><a href='../Administrator/PlaceList.aspx'>Place</a></li>"+
                                "<li><a href='../Administrator/TicketCancelList.aspx'>Ticket Cancel</a></li>" +
                                "<li><a href='../Administrator/PromoteList.aspx'>Promote</a></li>" +
		                    "</ul>"+
	                    "</li>"+
	                    "<li class='' id='router'>"+
		                    "<a class='top'>Router</a>"+
		                    "<ul style='display: none; visibility: hidden;'>"+
    		                    "<li><a href='../Administrator/RouterList.aspx'>Router</a></li>"+
    		                    "<li><a href='../Administrator/ListBus.aspx'>List Bus</a></li>"+
		                    "</ul>"+
	                    "</li>"+
	                    "<li class='' id='sale'>"+
		                    "<a class='top'>Sales</a>"+
		                    "<ul style='display: none; visibility: hidden;'>"+
                                "<li><a href='../Administrator/TicketList.aspx'>List Ticket</a></li>" +
    		                "</ul>"+
	                    "</li>"+
                        "<li class='' id='new'>" +
                            "<a class='top'>News</a>" +
                            "<ul style='display: none; visibility: hidden;'>" +
                                "<li><a href='../Administrator/NewsList.aspx'>New</a></li>" +
                                "<li><a href='../Administrator/FaqList.aspx'>Faq</a></li>" +
                            "</ul>" +
                        "</li>" +
                         "<li class='' id='reports'>" +
                            "<a class='top'>Reports</a>" +
                            "<ul style='display: none; visibility: hidden;'>" +
                                "<li><a href='../Administrator/Reports.aspx'>Sales</a></li>" +
                            "</ul>" +
                        "</li>" +
	                    "<li class='' id='system'>"+
		                    "<a class='top'>System</a>"+
		                    "<ul style='display: none; visibility: hidden;'>"+
			                    "<li class=''><a href='../Administrator/AccountList.aspx'>Account</a></li>"+
     	                    "</ul>"+
	                    "</li>"+
                    "</ul>";

                 //string menuEmployee = "<ul class='nav left sf-js-enabled' style='display: block;'>" +
                 //       "<li id='dashboard>" +
                 //           "<a href='../Administrator/Default.aspx' class='top'>Home</a>" +
                 //       "</li>" +
                 //       "<li class='' id='router'>" +
                 //           "<a class='top'>Router</a>" +
                 //           "<ul style='display: none; visibility: hidden;'>" +
                 //               "<li><a href='../Administrator/SeatList.aspx'>Seat</a></li>" +
                 //           "</ul>" +
                 //       "</li>" +
                 //       "<li class='' id='sale'>" +
                 //           "<a class='top'>Sales</a>" +
                 //           "<ul style='display: none; visibility: hidden;'>" +
                 //               "<li><a href='../Administrator/TicketList.aspx'>Orders</a></li>" +
                 //               "<li><a href='../Administrator/Booking.aspx'>Create Ticket</a></li>" +
                 //               "<li class=''><a href='../Administrator/CustomerList.aspx'>Customer</a></li>" +
                 //           "</ul>" +
                 //       "</li>" +
                 //       "<li class='' id='new'>" +
                 //           "<a class='top'>News</a>" +
                 //           "<ul style='display: none; visibility: hidden;'>" +
                 //               "<li><a href='../Administrator/NewsList.aspx'>New</a></li>" +
                 //               "<li><a href='../Administrator/FaqList.aspx'>Faq</a></li>" +
                 //           "</ul>" +
                 //       "</li>" +
                 //        "<li class='' id='reports'>" +
                 //           "<a class='top'>Reports</a>" +
                 //           "<ul style='display: none; visibility: hidden;'>" +
                 //               "<li><a href='../Administrator/Reports.aspx'>Sales</a></li>" +
                 //           "</ul>" +
                 //       "</li>" +
                 //   "</ul>";

        //if (Session["Name"] != null)
        //{
        //    Session["UserName"] = Session["Name"];
        //    username = Session["UserName"].ToString();
        //    Account account = _accountBUS.GetRoleForUserName(username);
        //    Session["Role"] = account.Role;
        //    int role = int.Parse(Session["Role"].ToString());
        //    if (role == 0)
        //    {
        //        litMenu.Text = menuEmployee.ToString();
        //        hplupdateprofile.Visible = true;
        //    }
        //    else
        //    {
                litMenu.Text = menuAdmin.ToString();
                hplupdateprofile.Visible = false;
        //    }
        //}
        //else 
        //{
        //    Response.Redirect("../Login.aspx");
        //}
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        //Response.Redirect("../Login.aspx");
    }
}
