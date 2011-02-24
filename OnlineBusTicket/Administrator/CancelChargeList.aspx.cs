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

public partial class Administrator_CancelChargeList : System.Web.UI.Page
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
        DataTable dt = BLLCancelCharge.getAllCancelCharge();
        dv = new DataView(dt);
        dv.Sort = "CancelChargeNo ASC";
        total.Text = dv.Count.ToString();
        gvCancelChargeList.DataSource = dv;
        gvCancelChargeList.DataBind();
        if (gvCancelChargeList.HeaderRow != null)
        {
            gvCancelChargeList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvCancelChargeList.Rows)
        {

            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                int id = int.Parse(row.Cells[1].Text);
                int k = BLLCancelCharge.DeleteCancelCharge(id);
            }
        }
        if (test == 0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a Cancel Charge from the list to delete');", true);
        else
            Response.Redirect("CancelChargeList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        string s = f.RemoveSpecialChars(txtSearchCancelCharge.Text.Trim());
        dv.RowFilter = "CancelChargeName like '%" + s + "%'";
        total.Text = dv.Count.ToString();
        gvCancelChargeList.DataSource = dv;
        gvCancelChargeList.DataBind();
    }

    protected void gvCancelChargeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCancelChargeList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void ddlOrderBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        {
            case 0:
                dv.Sort = "CancelChargeNo ASC"; break;
            case 1:
                dv.Sort = "CancelChargeName ASC"; break;
            case 2:
                dv.Sort = "PercentPrice ASC"; break;
            case 3:
                dv.Sort = "CancelChargeNo DESC"; break;
            case 4:
                dv.Sort = "CancelChargeName DESC"; break;
            case 5:
                dv.Sort = "PercentPrice DESC"; break;
            case 6:
                dv.Sort = "Status DESC"; break;
            case 7:
                dv.Sort = "Status ASC"; break;


        }
        total.Text = dv.Count.ToString();
        gvCancelChargeList.DataSource = dv;
        gvCancelChargeList.DataBind();
    }
}

