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
/// Summary description for Ticket
/// </summary>
public class Ticket
{
    private int ticketNo;

    public int TicketNo
    {
        get { return ticketNo; }
        set { ticketNo = value; }
    }
    private DateTime dateBooking;

    public DateTime DateBooking
    {
        get { return dateBooking; }
        set { dateBooking = value; }
    }
    private int listBusID;

    public int ListBusID
    {
        get { return listBusID; }
        set { listBusID = value; }
    }
    private int accountID;

    public int AccountID
    {
        get { return accountID; }
        set { accountID = value; }
    }
    private int numberSeat;

    public int NumberSeat
    {
        get { return numberSeat; }
        set { numberSeat = value; }
    }
    private int promoteID;

    public int PromoteID
    {
        get { return promoteID; }
        set { promoteID = value; }
    }
    private double totalFees;

    public double TotalFees
    {
        get { return totalFees; }
        set { totalFees = value; }
    }
    private DateTime cancelDate;

    public DateTime CancelDate
    {
        get { return cancelDate; }
        set { cancelDate = value; }
    }
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    private double totalReal;

    public double TotalReal
    {
        get { return totalReal; }
        set { totalReal = value; }
    }
    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

	public Ticket()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
