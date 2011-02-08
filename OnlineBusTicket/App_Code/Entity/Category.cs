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
/// Summary description for Category
/// </summary>
public class Category
{
    private int categoryID;
    private string categoryName;
    private bool status;

    public Category()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int CategoryID
    {
        get { return categoryID; }
        set { categoryID = value; }
    }

    public string CategoryName
    {
        get { return categoryName; }
        set { categoryName = value; }
    }

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }
}
