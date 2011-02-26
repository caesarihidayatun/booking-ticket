using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
    private int accountID;

    public int AccountID
    {
        get { return accountID; }
        set { accountID = value; }
    }
    private string userName;

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    private string role;

    public string Role
    {
        get { return role; }
        set { role = value; }
    }
    private DateTime birthday;

    public DateTime Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    private string sex;

    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }
    private string identifyCode;

    public string IdentifyCode
    {
        get { return identifyCode; }
        set { identifyCode = value; }
    }
    private string fullName;

    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }
    private string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    private string phone;

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    private bool status;

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }

	public Account()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
