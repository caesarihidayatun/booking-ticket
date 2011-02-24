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

public partial class Administrator_PromoteList : System.Web.UI.Page
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
        DataTable dt = BLLPromote.getAllPromote();
        dv = new DataView(dt);
        dv.Sort = "PromoteID ASC";
        total.Text = dv.Count.ToString();
        gvPromoteList.DataSource = dv;
        gvPromoteList.DataBind();
        if (gvPromoteList.HeaderRow != null)
        {
            gvPromoteList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvPromoteList.Rows)
        {
            
            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                int id = int.Parse(row.Cells[1].Text);
                int k = BLLPromote.DeletePromote(id);
            }
        }
        if(test==0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a Promote from the list to delete');", true);
        else
            Response.Redirect("PromoteList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        string s = f.RemoveSpecialChars(txtSearchPromote.Text.Trim());
        dv.RowFilter = "PromoteName like '%" + s + "%'";
        total.Text = dv.Count.ToString();
        gvPromoteList.DataSource = dv;
        gvPromoteList.DataBind();
    }

    protected void gvPromoteList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPromoteList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        { 
            case 0:
                dv.Sort = "PromoteID ASC"; break;
            case 1:
                dv.Sort = "PromoteName ASC"; break;
            case 2:
                dv.Sort = "Discount ASC"; break;
            case 3:
                dv.Sort = "PromoteID DESC"; break;
            case 4:
                dv.Sort = "PromoteName DESC"; break;
            case 5:
                dv.Sort = "Discount DESC"; break;
            case 6:
                dv.Sort = "Status DESC"; break;
            case 7:
                dv.Sort = "Status ASC"; break;
        }
        total.Text = dv.Count.ToString();
        gvPromoteList.DataSource = dv;
        gvPromoteList.DataBind();
    }
}

