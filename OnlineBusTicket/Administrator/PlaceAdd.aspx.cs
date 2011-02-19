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

public partial class Administrator_PlaceAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string name = PlaceName.Text.Trim();
        if (BLLPlace.checkPlaceExist(name)!=0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Place Name existed. Please try again');", true);
        }
        else
        {
            Place place = new Place();
            place.PlaceName = name;
            BLLPlace.InsertPlace(place);
            Response.Redirect("PlaceList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        PlaceName.Text = "";
    }
    
}
