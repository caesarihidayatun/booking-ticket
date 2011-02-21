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

public partial class Administrator_PromoteAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string promoteName = PromoteName.Text;
        string discount = Discount.Text;
        
        if (BLLPromote.checkPromoteExistName(promoteName)!= 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Promote Name existed. Please try again');", true);
        }
        else
        {
            Promote promote = new Promote();
            promote.PromoteName = promoteName;
            promote.Discount = Int32.Parse(discount);
            promote.Status = true;
            BLLPromote.InsertPromote(promote);
            Response.Redirect("PromoteList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        PromoteName.Text = "";
        Discount.Text = "";
    }
    
}
