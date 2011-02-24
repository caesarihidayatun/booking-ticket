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
using System.Text.RegularExpressions;

public partial class Administrator_ListBus : System.Web.UI.Page
{
     static DataView dv;
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            lnkDelete.Attributes.Add("onclick", "return confirm('Are u sure u want to delete?');");
        }
    }

    protected void LoadData()
    {
        DataTable dt = BLLListBus.getAllListBus();
        dv = new DataView(dt);
        dv.Sort = "Status DESC, Departure DESC";
        total.Text = dv.Count.ToString();
        gvListBusList.DataSource = dv;
        gvListBusList.DataBind();
        if (gvListBusList.HeaderRow != null)
        {
            gvListBusList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvListBusList.Rows)
        {
            
            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                int id = int.Parse(row.Cells[1].Text);
                int k = BLLListBus.DeleteListBus(id);
            }
        }
        if(test==0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a ListBus from the list to delete');", true);
        else
            Response.Redirect("ListBusList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        Regex test = new Regex("[^0-9]");
        string s = f.RemoveSpecialChars(txtSearchListBus.Text.Trim());
        if ((!s.Equals(""))&&(!test.IsMatch(s)))
        {
            dv.RowFilter = "ListBusID ='" + s + "'";
            total.Text = dv.Count.ToString();
            gvListBusList.DataSource = dv;
            gvListBusList.DataBind();
        }
        else
            LoadData();
    }

    protected void gvListBusList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvListBusList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        { 
            case 0:
                dv.Sort = "Status DESC, Departure DESC"; break;
            case 1:
                dv.Sort = "Price DESC"; break;
            case 2:
                dv.Sort = "Status DESC"; break;
            case 3:
                dv.Sort = "Status DESC, Departure ASC"; break;
            case 4:
                dv.Sort = "Price ASC"; break;
            case 5:
                dv.Sort = "Status ASC"; break;
        }
        total.Text = dv.Count.ToString();
        gvListBusList.DataSource = dv;
        gvListBusList.DataBind();
    }
    protected void gvListBusList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRouter = (Label)e.Row.FindControl("Label1");
            Label lblBus = (Label)e.Row.FindControl("Label2");
            HiddenField hfRouterID = (HiddenField)e.Row.FindControl("HiddenField1");
            HiddenField hfBusID = (HiddenField)e.Row.FindControl("HiddenField2");

            int routerID = Int32.Parse(hfRouterID.Value);
            string busID = hfBusID.Value;

            Router router = BLLRouter.getRouterByID(routerID)[0];
            Bus bus = BLLBus.getBusByID(busID)[0];

            lblRouter.Text = router.RouterName;
            lblBus.Text = bus.BusName + " ("+bus.BusPlate+")";
        }
    }
    protected void lnkExpired_Click(object sender, EventArgs e)
    {
        DataTable dt = BLLListBus.getAllListBusByStatus(true);
        foreach (DataRow dr in dt.Rows)
        {
            DateTime date = DateTime.Parse(dr["Departure"].ToString());
            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                ListBus listBus = new ListBus();
                listBus.ListBusID = Int32.Parse(dr["ListBusID"].ToString());
                listBus.RouterID = Int32.Parse(dr["RouterID"].ToString());
                listBus.BusPlate = dr["BusPlate"].ToString();
                listBus.Departure = DateTime.Parse(dr["Departure"].ToString());
                listBus.Arrival = DateTime.Parse(dr["Arrival"].ToString());
                listBus.Price = Double.Parse(dr["Price"].ToString());
                listBus.Status = false;
                int k = BLLListBus.UpdateListBus(listBus);
            }
        }
        LoadData();
    }
}

