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

public partial class Admin_Login : System.Web.UI.Page
{
    //private AccountBUS _account;

    protected void Page_Load(object sender, EventArgs e)
    {
        //_account = new AccountBUS();
        //if (Session["name"] != null)
        //{
        //    Response.Redirect("Pages/Default.aspx");
        //}
    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        //bool check = _account.CheckAccount(username.Text, password.Text);
        //if (check)
        //{
        //    Session["name"] = username.Text;
        //    Account account = new Account();
        //    account = _account.GetDataByUserName(username.Text);
        //    Session["AccountID"] = account.AccountID.ToString();
        //    Response.Redirect("Pages/Default.aspx");
        //}
        //else
        //{
        //    lblMessage.Text = "No match for Username and/or Password.";
        //    palMessageError.CssClass = "warning";
        //}
    }
}
