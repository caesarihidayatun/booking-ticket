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

public partial class Administrator_PlaceList : System.Web.UI.Page
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
        DataTable dt = BLLPlace.getAllData();
        dv = new DataView(dt);
        dv.Sort = "PlaceID ASC";
        total.Text = dv.Count.ToString();
        gvPlaceList.DataSource = dv;
        gvPlaceList.DataBind();
        if (gvPlaceList.HeaderRow != null)
        {
            gvPlaceList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvPlaceList.Rows)
        {
            
            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                int id = int.Parse(row.Cells[1].Text);
                int k = BLLPlace.DeletePlace(id);
            }
        }
        if(test==0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a Place from the list to delete');", true);
        else
            Response.Redirect("PlaceList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        string s = f.RemoveSpecialChars(txtSearchPlace.Text.Trim());
        dv.RowFilter = "PlaceName like '%" + s + "%'";
        total.Text = dv.Count.ToString();
        gvPlaceList.DataSource = dv;
        gvPlaceList.DataBind();
    }

    protected void gvPlaceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPlaceList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        { 
            case 0:
                dv.Sort = "PlaceID ASC"; break;
            case 1:
                dv.Sort = "PlaceID DESC"; break;
            case 2:
                dv.Sort = "PlaceName ASC"; break;
            case 3:
                dv.Sort = "PlaceName DESC"; break;
               
        }
        total.Text = dv.Count.ToString();
        gvPlaceList.DataSource = dv;
        gvPlaceList.DataBind();
    }
}

