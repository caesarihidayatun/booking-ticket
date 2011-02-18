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

public partial class Administrator_BusTypeList : System.Web.UI.Page
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
        DataTable dt = BLLBusType.getAllBusType();
        dv = new DataView(dt);
        dv.Sort = "BusTypeID ASC";
        total.Text = dv.Count.ToString();
        gvBusTypeList.DataSource = dv;
        gvBusTypeList.DataBind();
        if (gvBusTypeList.HeaderRow != null)
        {
            gvBusTypeList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvBusTypeList.Rows)
        {
            
            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                int id = int.Parse(row.Cells[1].Text);
                int k = BLLBusType.DeleteBusType(id);
            }
        }
        if(test==0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a BusType from the list to delete');", true);
        else
            Response.Redirect("BusTypeList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        string s = f.RemoveSpecialChars(txtSearchBusType.Text.Trim());
        dv.RowFilter = "Type like '%" + s + "%'";
        total.Text = dv.Count.ToString();
        gvBusTypeList.DataSource = dv;
        gvBusTypeList.DataBind();
    }

    protected void gvBusTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBusTypeList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        { 
            case 0:
                dv.Sort = "BusTypeID ASC"; break;
            case 1:
                dv.Sort = "BusTypeID DESC"; break;
            case 2:
                dv.Sort = "Type ASC"; break;
            case 3:
                dv.Sort = "Type DESC"; break;
               
        }
        total.Text = dv.Count.ToString();
        gvBusTypeList.DataSource = dv;
        gvBusTypeList.DataBind();
    }
}

