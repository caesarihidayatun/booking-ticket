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

public partial class Administrator_RouterList : System.Web.UI.Page
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
        DataTable dt = BLLRouter.getAllRouter();
        dv = new DataView(dt);
        dv.Sort = "RouterID ASC";
        total.Text = dv.Count.ToString();
        gvRouterList.DataSource = dv;
        gvRouterList.DataBind();
        if (gvRouterList.HeaderRow != null)
        {
            gvRouterList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvRouterList.Rows)
        {
            
            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                int id = int.Parse(row.Cells[1].Text);
                int k = BLLRouter.DeleteRouter(id);
            }
        }
        if(test==0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a Router from the list to delete');", true);
        else
            Response.Redirect("RouterList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        string s = f.RemoveSpecialChars(txtSearchRouter.Text.Trim());
        dv.RowFilter = "RouterName like '%" + s + "%'";
        total.Text = dv.Count.ToString();
        gvRouterList.DataSource = dv;
        gvRouterList.DataBind();
    }

    protected void gvRouterList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRouterList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        { 
            case 0:
                dv.Sort = "RouterID ASC"; break;
            case 1:
                dv.Sort = "RouterName ASC"; break;
            case 2:
                dv.Sort = "Distance ASC"; break;
            case 3:
                dv.Sort = "RouterID DESC"; break;
            case 4:
                dv.Sort = "RouterName DESC"; break;
            case 5:
                dv.Sort = "Distance DESC"; break;
        }
        total.Text = dv.Count.ToString();
        gvRouterList.DataSource = dv;
        gvRouterList.DataBind();
    }
}

