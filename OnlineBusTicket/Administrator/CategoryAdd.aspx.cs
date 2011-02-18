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

public partial class Administrator_CategoryAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string name = CategoryName.Text.Trim();
        if (BLLCategory.checkCategoryExistName(name)!=0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Category Name existed. Please try again');", true);
        }
        else
        {
            Category cat = new Category();
            cat.CategoryName = name;
            cat.Status = true;
            BLLCategory.InsertCategory(cat);
            Response.Redirect("CategoryList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        CategoryName.Text = "";
    }
    
}
