using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALPlace
/// </summary>

namespace DAL
{
    public class DALPlace : DALBase, IDALPlace
    {
        private const string tableName = "Place";
        private const string placeId = "PlaceID";
        private const string placeName = "PlaceName";

        public DALPlace()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertPlace(Place place) {
            int result = 0;
            try
            {
                String[] columns = {placeName};
                Object[] values = {place.PlaceName};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeletePlace(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {placeId};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdatePlace(Place place)
        {
            int result = 0;
            try
            {
                String[] columnNames = {placeName};
                Object[] values = {place.PlaceName};
                String[] keyColumnNames = {placeId};
                Object[] keyColumnValues = {place.PlaceID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Place[] getPlaceByID(int id)
        {
            Place[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from Place where {0} = @{1}", placeId, placeId);
                cmd.Parameters.Add(String.Format("@{0}", placeId), SqlDbType.Int).Value = id;
                String[] columnNames = { placeId, placeName};
                result = SelectCollection<Place>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllData()
        {
            try
            {
                return DALBase.getAllData(tableName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int checkPlaceExist(String name) 
        {
            try
            {
                return RecordExisted(tableName, placeName, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
