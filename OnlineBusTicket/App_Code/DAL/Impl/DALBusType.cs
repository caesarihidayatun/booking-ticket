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
/// Summary description for DALBusType
/// </summary>

namespace DAL
{
    public class DALBusType : DALBase, IDALBusType
    {
        private const string tableName = "BusType";
        private const string busTypeID = "BusTypeID";
        private const string type = "Type";
        private const string status = "Status";

        public DALBusType()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertBusType(BusType busType) {
            int result = 0;
            try
            {
                String[] columns = {type, status};
                Object[] values = {busType.Type, busType.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteBusType(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {busTypeID};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateBusType(BusType busType)
        {
            int result = 0;
            try
            {
                String[] columnNames = {type, status};
                Object[] values = {busType.Type, busType.Status};
                String[] keyColumnNames = {busTypeID};
                Object[] keyColumnValues = {busType.BusTypeID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public BusType[] getBusTypeByID(int id)
        {
            BusType[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from BusType where {0} = @{1}", busTypeID, busTypeID);
                cmd.Parameters.Add(String.Format("@{0}", busTypeID), SqlDbType.Int).Value = id;
                String[] columnNames = { busTypeID, type, status};
                result = SelectCollection<BusType>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllBusType()
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

        public DataTable getAllBusTypeByStatus(Boolean status)
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

        public int checkBusTypeExistName(String name) 
        {
            try
            {
                return RecordExisted(tableName, type, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
