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
using DAL;

public partial class GUI_Booking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
        }
    }

    public void LoadData()
    {
       string from = Request.QueryString["From"].ToString().Trim();
       string to = Request.QueryString["To"].ToString().Trim();
       string fromDate = Request.QueryString["FromDate"].ToString().Trim();
       string toDate =Request.QueryString["toDate"].ToString().Trim();
       GridView1.DataSource = BLLInfoBusRouter.getBusRouter(fromDate, toDate, from, to);
       GridView1.DataBind();
    }
}
