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
/// Summary description for BLLListBus
/// </summary>
/// 
namespace BLL
{
    public class BLLListBus
    {
        public BLLListBus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertListBus(ListBus listBus)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetListBusDA().InsertListBus(listBus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdateListBus(ListBus listBus)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetListBusDA().UpdateListBus(listBus);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeleteListBus(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetListBusDA().DeleteListBus(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static ListBus[] getListBusByID(int id)
        {
            try
            {
                return DataAccessHelper.GetListBusDA().getListBusByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllListBusByStatus(Boolean status)
        {
            try
            {
                return DataAccessHelper.GetListBusDA().getAllListBusByStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllListBus()
        {
            try
            {
                return DataAccessHelper.GetListBusDA().getAllListBus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
