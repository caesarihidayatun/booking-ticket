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

public partial class Administrator_BusTypeAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        string name = Type.Text.Trim();
        if (BLLBusType.checkBusTypeExistName(name)!=0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Notify", "alert('!!!BusType Name existed. Please try again');", true);
        }
        else
        {
            BusType busType = new BusType();
            busType.Type = name;
            busType.Status = true;
            BLLBusType.InsertBusType(busType);
            Response.Redirect("BustypeList.aspx");
        }
    }
    protected void LnkReset_Click(object sender, EventArgs e)
    {
        Type.Text = "";
    }
    
}
