using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;

public partial class Administrator_ListBusAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            LoadData();
        }
    }

    protected void LoadData()
    {
        DataTable bus = BLLBus.getAllBusByStatus(true);
        ddlBus.DataSource = bus;
        ddlBus.DataTextField = "BusName";
        ddlBus.DataValueField = "BusPlate";
        ddlBus.DataBind();

        DataTable router = BLLRouter.getAllRouterByStatus(true);
        ddlRouter.DataSource = router;
        ddlRouter.DataTextField = "RouterName";
        ddlRouter.DataValueField = "RouterID";
        ddlRouter.DataBind();
    }

    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        int routerID = Convert.ToInt32(ddlRouter.SelectedItem.Value.ToString());
        string busPlate = ddlBus.SelectedItem.Value.ToString();
        string departure = txtDeparture.Text.ToString() + " " + ddlStartTime.SelectedItem.Text.ToString();
        string arrival = txtArrival.Text.ToString() + " " + ddlEndTime.SelectedItem.Text.ToString();
        float price = float.Parse(txtPrice.Text.ToString());

        ListBus listBus = new ListBus();
        listBus.BusPlate = busPlate;
        listBus.RouterID = routerID;
        listBus.Departure = DateTime.Parse(departure);
        listBus.Arrival = DateTime.Parse(arrival);
        listBus.Price = price;
        listBus.Status = true;

        int k = BLLListBus.InsertListBus(listBus);
        Response.Redirect("ListBus.aspx");
    }
    protected void LnkReset_Click(object sender, EventArgs e)
    {
        LoadData();
        txtDeparture.Text = "";
        txtArrival.Text = "";
        txtPrice.Text = "";
    }
}
