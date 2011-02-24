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

public partial class Administrator_BusList : System.Web.UI.Page
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
        DataTable dt = BLLBus.getAllBus();
        dv = new DataView(dt);
        dv.Sort = "BusName ASC";
        total.Text = dv.Count.ToString();
        gvBusList.DataSource = dv;
        gvBusList.DataBind();
        if (gvBusList.HeaderRow != null)
        {
            gvBusList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvBusList.Rows)
        {

            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                string id = row.Cells[2].Text;
                int k = BLLBus.DeleteBus(id);
            }
        }
        if (test == 0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a Bus from the list to delete');", true);
        else
            Response.Redirect("BusList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        string s = f.RemoveSpecialChars(txtSearchBus.Text.Trim());
        int value = Int32.Parse(DropDownList1.SelectedValue.ToString());
        if(value==0)
            dv.RowFilter = "BusName like '%" + s + "%'";
        else
            dv.RowFilter = "BusPlate like '%" + s + "%'";
        total.Text = dv.Count.ToString();
        gvBusList.DataSource = dv;
        gvBusList.DataBind();
    }

    protected void gvBusList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBusList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void ddlOrderBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        { 
            case 0:
                dv.Sort = "BusName ASC"; break;
            case 1:
                dv.Sort = "BusPlate ASC"; break;
            case 2:
                dv.Sort = "Seat ASC"; break;
            case 3:
                dv.Sort = "BusName DESC"; break;
            case 4:
                dv.Sort = "BusPlate DESC"; break;
            case 5:
                dv.Sort = "Seat DESC"; break;
            case 6:
                dv.Sort = "Status DESC"; break;
            case 7:
                dv.Sort = "Status ASC"; break;
        }
        total.Text = dv.Count.ToString();
        gvBusList.DataSource = dv;
        gvBusList.DataBind();
    }
    protected void gvBusList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblBusType = (Label)e.Row.FindControl("lblBusType");
            Label lblCategory = (Label)e.Row.FindControl("lblCategory");
            HiddenField hfBusType = (HiddenField)e.Row.FindControl("hfBusType");
            HiddenField hfCategory = (HiddenField)e.Row.FindControl("hfCategory");

            int busTypeID = Int32.Parse(hfBusType.Value);
            int categoryID = Int32.Parse(hfCategory.Value);

            BusType busType = BLLBusType.getBusTypeByID(busTypeID)[0];
            Category cat = BLLCategory.getCategoryByID(categoryID)[0];

            lblBusType.Text = busType.Type;
            lblCategory.Text = cat.CategoryName;

        }
    }
}

