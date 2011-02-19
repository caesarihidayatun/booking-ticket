using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;

public partial class Administrator_PlaceEdit : System.Web.UI.Page
{
    private static Place place;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        int placeId = Convert.ToInt32(Request.QueryString["PlaceID"].ToString());
        place = BLLPlace.getPlaceByID(placeId)[0];
        if (!Page.IsPostBack)
        {
            PlaceName.Text = place.PlaceName;
        }
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
       if ((!place.PlaceName.Equals(PlaceName.Text.Trim())) && (BLLPlace.checkPlaceExist(PlaceName.Text)!=0))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Place Name existed. Please try again');", true);
        }
        else
        {
            Place newPlace = new Place();
            newPlace.PlaceID = place.PlaceID;
            newPlace.PlaceName = PlaceName.Text.Trim();
            int k = BLLPlace.UpdatePlace(newPlace);
            Response.Redirect("PlaceList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        PlaceName.Text = place.PlaceName;
     }
}
