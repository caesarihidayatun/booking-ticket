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

public partial class Administrator_RouterAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillData();
        }
    
    }

    private void fillData()
    {
        DataTable place = BLLPlace.getAllData();

        ddlStartPlace.DataSource = place;
        ddlStartPlace.DataTextField = "PlaceName";
        ddlStartPlace.DataValueField = "PlaceName";
        ddlStartPlace.DataBind();

        ddlDesPlace.DataSource = place;
        ddlDesPlace.DataTextField = "PlaceName";
        ddlDesPlace.DataValueField = "PlaceName";
        ddlDesPlace.DataBind();
    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string name = RouterName.Text.Trim();
        string startPlace = ddlStartPlace.SelectedValue.ToString();
        string desPlace = ddlDesPlace.SelectedValue.ToString();
        string distance = txtDistance.Text;
        string description = txtDescription.Text;

        if (BLLRouter.checkRouterNameExist(name) != 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Router Name existed. Please try again');", true);
        }
        else
        {
            Router router = new Router();
            router.RouterName = name;
            router.StartPlace = startPlace;
            router.DestinationPlace = desPlace;
            router.Distance = Int32.Parse(distance);
            router.Description = description;
            router.Status = true;
            BLLRouter.InsertRouter(router);
            Response.Redirect("RouterList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        RouterName.Text = "";
        txtDistance.Text = "";
        txtDescription.Text = "";
        fillData();
    }
    
}
