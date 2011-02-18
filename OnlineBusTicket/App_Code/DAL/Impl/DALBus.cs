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
/// Summary description for DALBus
/// </summary>

namespace DAL
{
    public class DALBus : DALBase, IDALBus
    {
        private const string tableName = "Bus";
        private const string busID = "BusID";
        private const string busName = "BusName";
        private const string busPlate = "BusPlate";
        private const string seat = "Seat";
        private const string busTypeID = "BusTypeID";
        private const string categoryID = "CategoryID";
        private const string status = "Status";


        public DALBus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertBus(Bus bus) {
            int result = 0;
            try
            {
                String[] columns = {busName, busPlate, seat, busTypeID, categoryID, status};
                Object[] values = {bus.BusName, bus.BusPlate, bus.Seat, bus.BusTypeID, bus.CategoryID, bus.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteBus(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {busID};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateBus(Bus bus)
        {
            int result = 0;
            try
            {
                String[] columnNames = { busName, busPlate, seat, busTypeID, categoryID, status };
                Object[] values = { bus.BusName, bus.BusPlate, bus.Seat, bus.BusTypeID, bus.CategoryID, bus.Status };
                String[] keyColumnNames = {busID};
                Object[] keyColumnValues = {bus.BusID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Bus[] getBusByID(int id)
        {
            Bus[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from Bus where {0} = @{1}", busID, busID);
                cmd.Parameters.Add(String.Format("@{0}", busID), SqlDbType.Int).Value = id;
                String[] columnNames = { busID, busName, busPlate, seat, busTypeID, categoryID, status };
                result = SelectCollection<Bus>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllBus()
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

        public DataTable getAllBusByStatus(Boolean status)
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

    }
}
