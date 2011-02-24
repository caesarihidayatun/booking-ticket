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
/// Summary description for IDALRouter
/// </summary>
/// 
namespace DAL
{
    public interface IDALRouter
    {
        int InsertRouter(Router router);
        int UpdateRouter(Router router);
        int DeleteRouter(int key);
        Router[] getIDrouter(String startPlace, String destinationPlace);
        Router[] getRouterByID(int id);
        DataTable getAllRouter();
        DataTable getAllRouterByStatus(Boolean status);
        int checkRouterNameExist(String name);
    }
}
