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
using DAL;
/// <summary>
/// Summary description for DALListBus
/// </summary>

namespace DAL
{
    public class DALListBus : DALBase, IDALListBus
    {
        private const string tableName = "ListBus";
        private const string listBusID = "ListBusID";
        private const string routerID = "RouterID";
        private const string busPlate = "BusPlate";
        private const string departure = "Departure";
        private const string arrival = "Arrival";
        private const string price = "Price";
        private const string status = "Status";


        public DALListBus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertListBus(ListBus listBus) {
            int result = 0;
            try
            {
                String[] columns = {routerID, busPlate, departure, arrival, price, status};
                Object[] values = {listBus.RouterID, listBus.BusPlate, listBus.Departure, listBus.Arrival, listBus.Price, listBus.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteListBus(int key)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {listBusID};
                Object[] keyColumnValues = {key};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateListBus(ListBus listBus)
        {
            int result = 0;
            try
            {
                String[] columnNames = { routerID, busPlate, departure, arrival, price, status };
                Object[] values = { listBus.RouterID, listBus.BusPlate, listBus.Departure, listBus.Arrival, listBus.Price, listBus.Status };
                String[] keyColumnNames = {listBusID};
                Object[] keyColumnValues = {listBus.ListBusID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public ListBus[] getListBusByID(int id)
        {
            ListBus[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from ListBus where {0} = @{1}", listBusID, listBusID);
                cmd.Parameters.Add(String.Format("@{0}", listBusID), SqlDbType.NVarChar).Value = id;
                String[] columnNames = { listBusID, routerID, busPlate, departure, arrival, price, status };
                result = SelectCollection<ListBus>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllListBus()
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

        public DataTable getAllListBusByStatus(Boolean status)
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
        public ListBus[] getListBusCustomer(DateTime start, DateTime end, int routerID, Boolean status)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from ListBus where @start<=Departure and Departure<=@end and RouterID=@routerID  and Status=@status";
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@routerID", routerID);
                cmd.Parameters.AddWithValue("@status", status);      
                String[] columnNames = { listBusID, routerID, busPlate, departure, arrival, price, status };
                result = SelectCollection<ListBus>(columnNames, columnNames, cmd);
                return DALBase.SelectCollection<ListBus>(columnNames, columnNames,cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
