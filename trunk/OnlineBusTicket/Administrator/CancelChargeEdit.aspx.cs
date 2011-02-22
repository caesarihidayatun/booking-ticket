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

public partial class Administrator_CancelChargeEdit : System.Web.UI.Page
{
    private static CancelCharge cancel;

    protected void Page_Load(object sender, EventArgs e)
    {
        int cancelId = Convert.ToInt32(Request.QueryString["CancelChargeNo"].ToString());
        cancel = BLLCancelCharge.getCancelChargeByID(cancelId)[0];
        if (!Page.IsPostBack)
        {
            fillData();
        }
    }

    private void fillData()
    {
        CancelChargeName.Text = cancel.CancelChargeName;
        PercentPrice.Text = cancel.PercentPrice.ToString();
        DateCancel.Text = cancel.DateCancel.ToString();
        cbStatus.Checked = cancel.Status;
    }

    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
      
        string name = CancelChargeName.Text.Trim();
        string price = PercentPrice.Text;
        string date = DateCancel.Text;

        if ((!cancel.CancelChargeName.Equals(name)) && (BLLCancelCharge.checkCancelChargeExist(name)!=0))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Cancel Charge Name existed. Please try again');", true);
        }
        else
        {
            CancelCharge newCancel = new CancelCharge();
            newCancel.CancelChargeNo = cancel.CancelChargeNo;
            newCancel.CancelChargeName = name;
            newCancel.PercentPrice = Int32.Parse(price);
            newCancel.DateCancel = Int32.Parse(date);
            if(cbStatus.Checked)
                newCancel.Status = true;
            else
                newCancel.Status = true;
            BLLCancelCharge.UpdateCancelCharge(newCancel);
            Response.Redirect("CancelChargeList.aspx");
        }
    }

    protected void LnkReset_Click(object sender, EventArgs e)
    {
        fillData();
    }
    
}
