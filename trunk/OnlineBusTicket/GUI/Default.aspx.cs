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

public partial class GUI_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {

        DropDownFrom.DataSource = BLLPlace.getAllData();
        DropDownFrom.DataTextField = "PlaceName";
        DropDownFrom.DataValueField = "PlaceID";
        DropDownFrom.DataBind();

        DropDownTo.DataSource = BLLPlace.getAllData();
        DropDownTo.DataTextField = "PlaceName";
        DropDownTo.DataValueField = "PlaceID";
        DropDownTo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string from = DropDownFrom.SelectedItem.Text.ToString();
        string to = DropDownTo.SelectedItem.Text.ToString();
        string fromDate = txtFromDate.Text;
        string toDate = txtToDate.Text;
        Response.Redirect("Booking.aspx?From=" + from + "&To=" + to + "&FromDate=" + fromDate + "&toDate=" + toDate);
    }
}
