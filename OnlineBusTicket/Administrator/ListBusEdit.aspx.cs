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

public partial class Administrator_ListBusEdit : System.Web.UI.Page
{
    private static ListBus listBus;
    protected void Page_Load(object sender, EventArgs e)
    {
        int listBusId = Convert.ToInt32(Request.QueryString["ListBusID"].ToString());
        listBus = BLLListBus.getListBusByID(listBusId)[0];
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
        ddlBus.SelectedValue = listBus.BusPlate;
        DataTable router = BLLRouter.getAllRouterByStatus(true);
        ddlRouter.DataSource = router;
        ddlRouter.DataTextField = "RouterName";
        ddlRouter.DataValueField = "RouterID";
        ddlRouter.DataBind();
        ddlRouter.SelectedValue = listBus.RouterID.ToString();

        txtDeparture.Text = listBus.Departure.ToShortDateString().ToString();
        ddlStartTime.SelectedValue = listBus.Departure.ToShortTimeString().ToString();

        txtArrival.Text = listBus.Arrival.ToShortDateString().ToString();
        ddlEndTime.SelectedValue = listBus.Arrival.ToShortTimeString().ToString();

        txtPrice.Text = listBus.Price.ToString();
        cbStatus.Checked = listBus.Status;
    }

    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        int routerID = Convert.ToInt32(ddlRouter.SelectedItem.Value.ToString());
        string busPlate = ddlBus.SelectedItem.Value.ToString();
        string departure = txtDeparture.Text.ToString() + " " + ddlStartTime.SelectedItem.Text.ToString();
        string arrival = txtArrival.Text.ToString() + " " + ddlEndTime.SelectedItem.Text.ToString();
        float price = float.Parse(txtPrice.Text.ToString());

        ListBus newListBus = new ListBus();
        newListBus.ListBusID = listBus.ListBusID;
        newListBus.BusPlate = busPlate;
        newListBus.RouterID = routerID;
        newListBus.Departure = DateTime.Parse(departure);
        newListBus.Arrival = DateTime.Parse(arrival);
        newListBus.Price = price;
        if(cbStatus.Checked)
            newListBus.Status = true;
        else
            newListBus.Status = true;

        int k = BLLListBus.UpdateListBus(newListBus);
        Response.Redirect("ListBus.aspx");
    }
    protected void LnkReset_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}
