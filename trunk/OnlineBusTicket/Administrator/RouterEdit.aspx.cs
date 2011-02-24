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

public partial class Administrator_RouterEdit : System.Web.UI.Page
{
    private static Router router;

    protected void Page_Load(object sender, EventArgs e)
    {
        int routerId = Convert.ToInt32(Request.QueryString["RouterID"].ToString());
        router = BLLRouter.getRouterByID(routerId)[0];

        if (!IsPostBack)
        {
            fillData();
        }
    
    }

    private void fillData()
    {
        RouterName.Text = router.RouterName;

        DataTable place = BLLPlace.getAllData();

        ddlStartPlace.DataSource = place;
        ddlStartPlace.DataTextField = "PlaceName";
        ddlStartPlace.DataValueField = "PlaceName";
        ddlStartPlace.DataBind();

        ddlStartPlace.SelectedValue = router.StartPlace;

        ddlDesPlace.DataSource = place;
        ddlDesPlace.DataTextField = "PlaceName";
        ddlDesPlace.DataValueField = "PlaceName";
        ddlDesPlace.DataBind();

        ddlDesPlace.SelectedValue = router.DestinationPlace;
        txtDescription.Text = router.Description;
        txtDistance.Text = router.Distance.ToString();
     
        cbStatus.Checked = router.Status;
    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string name = RouterName.Text.Trim();
        string startPlace = ddlStartPlace.SelectedValue.ToString();
        string desPlace = ddlDesPlace.SelectedValue.ToString();
        string distance = txtDistance.Text;
        string description = txtDescription.Text;

        if ((!router.RouterName.Equals(name))&&(BLLRouter.checkRouterNameExist(name) != 0))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Router Name existed. Please try again');", true);
        }
        else
        {
            Router newRouter = new Router();
            newRouter.RouterID = router.RouterID;
            newRouter.RouterName = name;
            newRouter.StartPlace = startPlace;
            newRouter.DestinationPlace = desPlace;
            newRouter.Distance = Int32.Parse(distance);
            newRouter.Description = description;
            newRouter.Status = true;
            BLLRouter.UpdateRouter(newRouter);
            Response.Redirect("RouterList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        fillData();
    }
    
}
