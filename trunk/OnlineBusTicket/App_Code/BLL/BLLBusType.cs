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
/// Summary description for BLLBusType
/// </summary>
/// 
namespace BLL
{
    public class BLLBusType
    {
        public BLLBusType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertBusType(BusType busType)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetBusTypeDA().InsertBusType(busType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdateBusType(BusType busType)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetBusTypeDA().UpdateBusType(busType);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeleteBusType(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetBusTypeDA().DeleteBusType(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static BusType[] getBusTypeByID(int id)
        {
            try
            {
                return DataAccessHelper.GetBusTypeDA().getBusTypeByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllBusTypeByStatus(Boolean status)
        {
            try
            {
                return DataAccessHelper.GetBusTypeDA().getAllBusTypeByStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllBusType()
        {
            try
            {
                return DataAccessHelper.GetBusTypeDA().getAllBusType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int checkBusTypeExistName(String name)
        {
            try
            {
                return DataAccessHelper.GetBusTypeDA().checkBusTypeExistName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
