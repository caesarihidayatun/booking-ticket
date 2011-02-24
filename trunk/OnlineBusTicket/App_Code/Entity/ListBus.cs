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
/// Summary description for ListBus
/// </summary>
public class ListBus
{
    private int listBusID;

    public int ListBusID
    {
        get { return listBusID; }
        set { listBusID = value; }
    }
    private int routerID;

    public int RouterID
    {
        get { return routerID; }
        set { routerID = value; }
    }
    private string busPlate;

    public string BusPlate
    {
        get { return busPlate; }
        set { busPlate = value; }
    }
    private DateTime departure;

    public DateTime Departure
    {
        get { return departure; }
        set { departure = value; }
    }
    private DateTime arrival;

    public DateTime Arrival
    {
        get { return arrival; }
        set { arrival = value; }
    }
    private double price;

    public double Price
    {
        get { return price; }
        set { price = value; }
    }
    private bool status;

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }

	public ListBus()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
