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
/// Summary description for IDALBusType
/// </summary>
/// 
namespace DAL
{
    public interface IDALBusType
    {
        int InsertBusType(BusType busType);
        int UpdateBusType(BusType busType);
        int DeleteBusType(int id);
        BusType[] getBusTypeByID(int id);
        DataTable getAllBusType();
        DataTable getAllBusTypeByStatus(Boolean status);
        int checkBusTypeExistName(String name);
    }
}
