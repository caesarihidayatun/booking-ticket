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
/// Summary description for BLLRouter
/// </summary>
/// 
namespace BLL
{
    public class BLLRouter
    {
        public BLLRouter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertRouter(Router router)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetRouterDA().InsertRouter(router);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdateRouter(Router router)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetRouterDA().UpdateRouter(router);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeleteRouter(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetRouterDA().DeleteRouter(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Router[] getRouterByID(int id)
        {
            try
            {
                return DataAccessHelper.GetRouterDA().getRouterByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllRouterByStatus(Boolean status)
        {
            try
            {
                return DataAccessHelper.GetRouterDA().getAllRouterByStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllRouter()
        {
            try
            {
                return DataAccessHelper.GetRouterDA().getAllRouter();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int checkRouterNameExist(String name)
        {
            try
            {
                return DataAccessHelper.GetRouterDA().checkRouterNameExist(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Router getIDrouter(String startPlace, String destinationPlace)
        {
            Router[] result = null;
            try
            {
                result = DataAccessHelper.GetIDrouterDA().getIDrouter(startPlace, destinationPlace);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result[0];
        }
    }
}
