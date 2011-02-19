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
/// Summary description for Place
/// </summary>
public class Place
{
    private int placeID;
    private string placeName;

    public Place()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int PlaceID
    {
        get { return placeID; }
        set { placeID = value; }
    }

    public string PlaceName
    {
        get { return placeName; }
        set { placeName = value; }
    }
}
