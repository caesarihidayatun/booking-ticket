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
/// Summary description for CancelCharge
/// </summary>
public class CancelCharge
{
    private int cancelChargeNo;

    public int CancelChargeNo
    {
        get { return cancelChargeNo; }
        set { cancelChargeNo = value; }
    }
    private string cancelChargeName;

    public string CancelChargeName
    {
        get { return cancelChargeName; }
        set { cancelChargeName = value; }
    }

    private int percentPrice;

    public int PercentPrice
    {
        get { return percentPrice; }
        set { percentPrice = value; }
    }

    private int dateCancel;

    public int DateCancel
    {
        get { return dateCancel; }
        set { dateCancel = value; }
    }
    private bool status;

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }

	public CancelCharge()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
