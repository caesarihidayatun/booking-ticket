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

public partial class Administrator_CancelChargeAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string name = CancelChargeName.Text.Trim();
        string price = PercentPrice.Text;
        string date = DateCancel.Text;

        if (BLLCancelCharge.checkCancelChargeExist(name)!=0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Cancel Charge Name existed. Please try again');", true);
        }
        else
        {
            CancelCharge cancel = new CancelCharge();
            cancel.CancelChargeName = name;
            cancel.PercentPrice = Int32.Parse(price);
            cancel.DateCancel = Int32.Parse(date);
            cancel.Status = true;
            BLLCancelCharge.InsertCancelCharge(cancel);
            Response.Redirect("CancelChargeList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        CancelChargeName.Text = "";
        DateCancel.Text = "";
        PercentPrice.Text = "";
    }
    
}
