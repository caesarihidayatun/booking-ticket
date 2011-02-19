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
/// Summary description for BLLPlace
/// </summary>
/// 
namespace BLL
{
    public class BLLPlace
    {
        public BLLPlace()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertPlace(Place place)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetPlaceDA().InsertPlace(place);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdatePlace(Place place)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetPlaceDA().UpdatePlace(place);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeletePlace(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetPlaceDA().DeletePlace(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Place[] getPlaceByID(int id)
        {
            try
            {
                return DataAccessHelper.GetPlaceDA().getPlaceByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllData()
        {
            try
            {
                return DataAccessHelper.GetPlaceDA().getAllData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int checkPlaceExist(String name)
        {
            try
            {
                return DataAccessHelper.GetPlaceDA().checkPlaceExist(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
