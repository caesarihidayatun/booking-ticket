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

public partial class Administrator_CategoryEdit : System.Web.UI.Page
{
    private static Category category;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        int categoryId = Convert.ToInt32(Request.QueryString["CategoryID"].ToString());
        category = BLLCategory.getCategoryByID(categoryId)[0];
        if (!Page.IsPostBack)
        {
            CategoryName.Text = category.CategoryName;
            cbStatus.Checked = category.Status;
        }
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
       if ((!category.CategoryName.Equals(CategoryName.Text.Trim())) && (BLLCategory.checkCategoryExistName(CategoryName.Text)!=0))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Category Name existed. Please try again');", true);
        }
        else
        {
            Category newCat = new Category();
            newCat.CategoryID = category.CategoryID;
            newCat.CategoryName = CategoryName.Text.Trim();
            if (cbStatus.Checked)
                newCat.Status = true;
            else
                newCat.Status = false;
            int k = BLLCategory.UpdateCategory(newCat);
            Response.Redirect("CategoryList.aspx");
        }
    }
}
