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
/// Summary description for BusType
/// </summary>
public class BusType
{
    private int busTypeID;
    private string type;
    private bool status;

    public BusType()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int BusTypeID
    {
        get { return busTypeID; }
        set { busTypeID = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }
}
