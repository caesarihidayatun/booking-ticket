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

public partial class Administrator_BusTypeEdit : System.Web.UI.Page
{
    private static BusType busType;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        int busTypeId = Convert.ToInt32(Request.QueryString["BusTypeID"].ToString());
        busType = BLLBusType.getBusTypeByID(busTypeId)[0];
        if (!Page.IsPostBack)
        {
            BusTypeName.Text = busType.Type;
            cbStatus.Checked = busType.Status;
        }
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
       if ((!busType.Type.Equals(BusTypeName.Text.Trim())) && (BLLBusType.checkBusTypeExistName(BusTypeName.Text)!=0))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!Type Name existed. Please try again');", true);
        }
        else
        {
            BusType newBusType = new BusType();
            newBusType.BusTypeID = busType.BusTypeID;
            newBusType.Type = BusTypeName.Text.Trim();
            if (cbStatus.Checked)
                newBusType.Status = true;
            else
                newBusType.Status = false;
            int k = BLLBusType.UpdateBusType(newBusType);
            Response.Redirect("BustypeList.aspx");
        }
    }
    protected void LnkReset_Click(object sender, EventArgs e)
    {
        BusTypeName.Text = busType.Type;
        cbStatus.Checked = busType.Status;
    }
}
