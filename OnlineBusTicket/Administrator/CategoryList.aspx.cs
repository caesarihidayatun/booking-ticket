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

public partial class Administrator_CategoryList : System.Web.UI.Page
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
        DataTable dt = BLLCategory.getAllData();
        dv = new DataView(dt);
        dv.Sort = "CategoryID ASC";
        total.Text = dv.Count.ToString();
        gvCategoryList.DataSource = dv;
        gvCategoryList.DataBind();
        if (gvCategoryList.HeaderRow != null)
        {
            gvCategoryList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        int test = 0;
        foreach (GridViewRow row in gvCategoryList.Rows)
        {
            
            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb.Checked)
            {
                ++test;
                int id = int.Parse(row.Cells[1].Text);
                int k = BLLCategory.DeleteCategory(id);
            }
        }
        if(test==0)
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Please select a Category from the list to delete');", true);
        else
            Response.Redirect("CategoryList.aspx");

    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        Function f = new Function();
        string s = f.RemoveSpecialChars(txtSearchCategory.Text.Trim());
        dv.RowFilter = "CategoryName like '%" + s + "%'";
        total.Text = dv.Count.ToString();
        gvCategoryList.DataSource = dv;
        gvCategoryList.DataBind();
    }

    protected void gvCategoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategoryList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int test = Int32.Parse(ddlOrderBy.SelectedValue.ToString());
        switch (test)
        { 
            case 0:
                dv.Sort = "CategoryID ASC"; break;
            case 1:
                dv.Sort = "CategoryID DESC"; break;
            case 2:
                dv.Sort = "CategoryName ASC"; break;
            case 3:
                dv.Sort = "CategoryName DESC"; break;
               
        }
        total.Text = dv.Count.ToString();
        gvCategoryList.DataSource = dv;
        gvCategoryList.DataBind();
    }
}

