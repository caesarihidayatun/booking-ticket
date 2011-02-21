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

public partial class Administrator_PromoteEdit : System.Web.UI.Page
{
    private static Promote promote;

    protected void Page_Load(object sender, EventArgs e)
    {
        int promoteId = Convert.ToInt32(Request.QueryString["PromoteID"].ToString());
        promote = BLLPromote.getPromoteByID(promoteId)[0];
        if (!Page.IsPostBack)
        {
            FillData();
        }
    }

    private void FillData()
    {
        PromoteName.Text = promote.PromoteName;
        Discount.Text = promote.Discount.ToString();
        cbStatus.Checked = promote.Status;
    }

    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string promoteName = PromoteName.Text;
        string discount = Discount.Text;
        
        if ((!promote.PromoteName.Equals(promoteName)) && (BLLPromote.checkPromoteExistName(promoteName)!= 0))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Promote Name existed. Please try again');", true);
        }
        else
        {
            Promote newPromote = new Promote();
            newPromote.PromoteID = promote.PromoteID;
            newPromote.PromoteName = promoteName;
            newPromote.Discount = Int32.Parse(discount);
            if(cbStatus.Checked)
                newPromote.Status = true;
            else
                newPromote.Status = false;
            BLLPromote.UpdatePromote(newPromote);
            Response.Redirect("PromoteList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        FillData();
    }
    
}
