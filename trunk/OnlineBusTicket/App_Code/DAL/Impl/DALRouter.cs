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
/// Summary description for DALRouter
/// </summary>

namespace DAL
{
    public class DALRouter : DALBase, IDALRouter
    {
        private const string tableName = "Router";
        private const string routerId = "RouterID";
        private const string routerName = "RouterName";
        private const string startPlace = "StartPlace";
        private const string destinationPlace = "DestinationPlace";
        private const string distance = "Distance";
        private const string description = "Description";
        private const string status = "Status";

        public DALRouter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertRouter(Router router) {
            int result = 0;
            try
            {
                String[] columns = {routerName, startPlace, destinationPlace, distance, description, status};
                Object[] values = {router.RouterName, router.StartPlace, router.DestinationPlace, router.Distance, router.Description, router.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteRouter(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {routerId};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateRouter(Router router)
        {
            int result = 0;
            try
            {
                String[] columnNames = { routerName, startPlace, destinationPlace, distance, description, status };
                Object[] values = { router.RouterName, router.StartPlace, router.DestinationPlace, router.Distance, router.Description, router.Status };
                String[] keyColumnNames = {routerId};
                Object[] keyColumnValues = {router.RouterID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Router[] getRouterByID(int id)
        {
            Router[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from Router where {0} = @{1}", routerId, routerId);
                cmd.Parameters.Add(String.Format("@{0}", routerId), SqlDbType.Int).Value = id;
                String[] columnNames = { routerId, routerName, startPlace, destinationPlace, distance, description, status };
                result = SelectCollection<Router>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllRouter()
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

        public DataTable getAllRouterByStatus(Boolean status)
        {
            try
            {
                return DALBase.getAllDataByStatus(tableName, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int checkRouterNameExist(String name) 
        {
            try
            {
                return RecordExisted(tableName, routerName, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Router[] getIDrouter(String startPlace, String destinationPlace)
        {
            Router[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select RouterID from Router where StartPlace=@startPlace and DestinationPlace=@destinationPlace";
                cmd.Parameters.AddWithValue("@startPlace", startPlace);
                cmd.Parameters.AddWithValue("@destinationPlace", destinationPlace);
                String[] columnNames = {routerId};
                result = SelectCollection<Router>(null, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
