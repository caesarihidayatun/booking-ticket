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
/// Summary description for IDALPlace
/// </summary>
/// 
namespace DAL
{
    public interface IDALPlace
    {
        int InsertPlace(Place place);
        int UpdatePlace(Place place);
        int DeletePlace(int id);
        Place[] getPlaceByID(int id);
        DataTable getAllData();
        int checkPlaceExist(String name);
    }
}
