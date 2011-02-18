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
/// Summary description for Bus
/// </summary>
public class Bus
{

    private int busID;
    private string busName;
    private string busPlate;
    private int seat;
    private int busTypeID;
    private int categoryID;
    private bool status;

	public Bus()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int BusID
    {
        get { return busID; }
        set { busID = value; }
    }

    public string BusName
    {
        get { return busName; }
        set { busName = value; }
    }

    public string BusPlate
    {
        get { return busPlate; }
        set { busPlate = value; }
    }

    public int Seat
    {
        get { return seat; }
        set { seat = value; }
    }

    public int BusTypeID
    {
        get { return busTypeID; }
        set { busTypeID = value; }
    }

    public int CategoryID
    {
        get { return categoryID; }
        set { categoryID = value; }
    }

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }
}
