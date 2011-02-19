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

public partial class Administrator_BusEdit : System.Web.UI.Page
{
    private static string busPlate;
    private static Bus bus;

    protected void Page_Load(object sender, EventArgs e)
    {
        busPlate = Request.QueryString["BusPlate"].ToString();
        bus = BLLBus.getBusByID(busPlate)[0];
        if (!IsPostBack)
        {
            FillData();
        }
    }
    /// <summary>
    /// Fill data to Form
    /// </summary>
    private void FillData()
    {
        BusPlate.Text = bus.BusPlate;
        BusName.Text = bus.BusName;
        Seat.Text = bus.Seat.ToString();
        cbStatus.Checked = bus.Status;

        DataTable busType = BLLBusType.getAllBusTypeByStatus(true);
        ddlBusType.DataSource = busType;
        ddlBusType.DataTextField = "Type";
        ddlBusType.DataValueField = "BusTypeID";
        ddlBusType.DataBind();
        ddlBusType.SelectedValue = bus.BusTypeID.ToString();

        DataTable category = BLLCategory.getAllDataByStatus(true);
        ddlCategory.DataSource = category;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();
        ddlCategory.SelectedValue = bus.CategoryID.ToString();
    }

    protected void lnkBtnUpdate_Click(object sender, EventArgs e)
    {
        string busName = BusName.Text;
        string seat = Seat.Text;
        string busTypeId = ddlBusType.SelectedValue.ToString();
        string categoryID = ddlCategory.SelectedValue.ToString();

        Bus newBus = new Bus();
        newBus.BusPlate = bus.BusPlate;
        newBus.BusName = busName;
        newBus.Seat = Int32.Parse(seat);
        newBus.BusTypeID = Int32.Parse(busTypeId);
        newBus.CategoryID = Int32.Parse(categoryID);
        if (cbStatus.Checked)
            newBus.Status = true;
        else
            newBus.Status = false;
        BLLBus.UpdateBus(newBus);
        Response.Redirect("BusList.aspx");
      
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        FillData();
    }
    
}
