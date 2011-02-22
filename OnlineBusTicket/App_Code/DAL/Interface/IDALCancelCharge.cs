using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for IDALCancelCharge
/// </summary>
/// 
namespace DAL
{
    public interface IDALCancelCharge
    {
        int InsertCancelCharge(CancelCharge cancelCharge);
        int UpdateCancelCharge(CancelCharge cancelCharge);
        int DeleteCancelCharge(int key);
        CancelCharge[] getCancelChargeByID(int id);
        DataTable getAllCancelCharge();
        DataTable getAllCancelChargeByStatus(Boolean status);
        int checkCancelChargeExist(String name);
    }
}
