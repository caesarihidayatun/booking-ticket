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
using DAL;
/// <summary>
/// Summary description for BLLInfoBusRouter
/// </summary>
/// 
namespace BLL
{
    public class BLLInfoBusRouter
    {
        public BLLInfoBusRouter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static InfoBusRouter[] getBusRouter(String start, String end, String startPlace, String destinationPlace)
        {
            InfoBusRouter[] result = null;
            try
            {
                result = DataAccessHelper.GetInfoBusRouterDA().getBusRouter(start,end,startPlace,destinationPlace);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}