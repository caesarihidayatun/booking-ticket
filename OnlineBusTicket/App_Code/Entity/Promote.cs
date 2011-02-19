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
/// Summary description for Promote
/// </summary>
public class Promote
{
    private int promoteID;
    private string promoteName;
    private int discount;
    private bool status;

	public Promote()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int PromoteID
    {
        get { return promoteID; }
        set { promoteID = value; }
    }

    public string PromoteName
    {
        get { return promoteName; }
        set { promoteName = value; }
    }

    public int Discount
    {
        get { return discount; }
        set { discount = value; }
    }

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }
}
