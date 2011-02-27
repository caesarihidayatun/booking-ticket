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
/// Summary description for BLLPromote
/// </summary>
/// 
namespace BLL
{
    public class BLLPromote
    {
        public BLLPromote()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertPromote(Promote promote)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetPromoteDA().InsertPromote(promote);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdatePromote(Promote promote)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetPromoteDA().UpdatePromote(promote);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeletePromote(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetPromoteDA().DeletePromote(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Promote getPromoteByID(int id)
        {
            try
            {
                return DataAccessHelper.GetPromoteDA().getPromoteByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllPromoteByStatus(Boolean status)
        {
            try
            {
                return DataAccessHelper.GetPromoteDA().getAllPromoteByStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllPromote()
        {
            try
            {
                return DataAccessHelper.GetPromoteDA().getAllPromote();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int checkPromoteExistName(String name)
        {
            try
            {
                return DataAccessHelper.GetPromoteDA().checkPromoteExistName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
