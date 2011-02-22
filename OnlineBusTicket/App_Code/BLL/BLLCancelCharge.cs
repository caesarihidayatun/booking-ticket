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
/// Summary description for BLLCancelCharge
/// </summary>
/// 
namespace BLL
{
    public class BLLCancelCharge
    {
        public BLLCancelCharge()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertCancelCharge(CancelCharge cancelCharge)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetCancelChargeDA().InsertCancelCharge(cancelCharge);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdateCancelCharge(CancelCharge cancelCharge)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetCancelChargeDA().UpdateCancelCharge(cancelCharge);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeleteCancelCharge(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetCancelChargeDA().DeleteCancelCharge(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static CancelCharge[] getCancelChargeByID(int id)
        {
            try
            {
                return DataAccessHelper.GetCancelChargeDA().getCancelChargeByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllCancelChargeByStatus(Boolean status)
        {
            try
            {
                return DataAccessHelper.GetCancelChargeDA().getAllCancelChargeByStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllCancelCharge()
        {
            try
            {
                return DataAccessHelper.GetCancelChargeDA().getAllCancelCharge();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int checkCancelChargeExist(String name)
        {
            try
            {
                return DataAccessHelper.GetCancelChargeDA().checkCancelChargeExist(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
