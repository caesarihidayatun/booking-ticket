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
/// Summary description for IDALBus
/// </summary>
/// 
namespace DAL
{
    public interface IDALBus
    {
        int InsertBus(Bus bus);
        int UpdateBus(Bus bus);
        int DeleteBus(String key);
        Bus[] getBusByID(String id);
        DataTable getAllBus();
        DataTable getAllBusByStatus(Boolean status);
        int checkBusPlateExist(String name);
    }
}
