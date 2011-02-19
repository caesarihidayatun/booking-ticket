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
/// Summary description for BLLBus
/// </summary>
/// 
namespace BLL
{
    public class BLLBus
    {
        public BLLBus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertBus(Bus bus)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetBusDA().InsertBus(bus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdateBus(Bus bus)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetBusDA().UpdateBus(bus);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeleteBus(String id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetBusDA().DeleteBus(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Bus[] getBusByID(String id)
        {
            try
            {
                return DataAccessHelper.GetBusDA().getBusByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllBusByStatus(Boolean status)
        {
            try
            {
                return DataAccessHelper.GetBusDA().getAllBusByStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllBus()
        {
            try
            {
                return DataAccessHelper.GetBusDA().getAllBus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int checkBusPlateExist(String name)
        {
            try
            {
                return DataAccessHelper.GetBusDA().checkBusPlateExist(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
