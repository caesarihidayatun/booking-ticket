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

public partial class Administrator_BusAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillData();
        }
    }

    /// <summary>
    /// Fill data to dropdownlist
    /// </summary>
    private void fillData()
    {
        DataTable busType = BLLBusType.getAllBusTypeByStatus(true);
        ddlBusType.DataSource = busType;
        ddlBusType.DataTextField = "Type";
        ddlBusType.DataValueField = "BusTypeID";
        ddlBusType.DataBind();
        DataTable category = BLLCategory.getAllDataByStatus(true);
        ddlCategory.DataSource = category;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();
    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string busPlate = BusPlate.Text;
        string busName = BusName.Text;
        string seat = Seat.Text;
        string busTypeId = ddlBusType.SelectedValue.ToString();
        string categoryID = ddlCategory.SelectedValue.ToString();

        if (BLLBus.checkBusPlateExist(busPlate) != 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Bus Plate existed. Please try again');", true);
        }
        else
        {
            Bus bus = new Bus();
            bus.BusPlate = busPlate;
            bus.BusName = busName;
            bus.Seat = Int32.Parse(seat);
            bus.BusTypeID = Int32.Parse(busTypeId);
            bus.CategoryID = Int32.Parse(categoryID);
            BLLBus.InsertBus(bus);
            Response.Redirect("BusList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        BusName.Text = "";
    }
    
}
