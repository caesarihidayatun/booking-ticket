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
using DAL;

public partial class GUI_Booking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    public void LoadData()
    {
        string from = Request.QueryString["From"].ToString().Trim();
        string to = Request.QueryString["To"].ToString().Trim();
        Router router = BLLRouter.getIDrouter(from, to);
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"].ToString().Trim());
        DateTime toDate = DateTime.Parse(Request.QueryString["toDate"].ToString().Trim());
        GridView1.DataSource = BLLListBus.getListBusCustomer(fromDate, toDate, router.RouterID, true);
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index =  Convert.ToInt32(e.CommandArgument.ToString());
            
            GridViewRow row = GridView1.Rows[index];        
            lbDeparture.Text = row.Cells[2].Text;
            lbArrival.Text = row.Cells[3].Text;
            lbPrice.Text = row.Cells[4].Text;
            ListBus listbus = new ListBus();
            listbus.ListBusID = row.Cells[0].Text;
            listbus.BusPlate = row.Cells[1].Text;
            listbus.Departure = row.Cells[2].Text;
            listbus.Arrival = row.Cells[3].Text;
            listbus.Price = row.Cells[4].Text;
            ViewState["lisbus"] = listbus; 
            MultiView1.ActiveViewIndex++;
        }
    }
 
}