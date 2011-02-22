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
/// Summary description for DALCancelCharge
/// </summary>

namespace DAL
{
    public class DALCancelCharge : DALBase, IDALCancelCharge
    {
        private const string tableName = "CancelCharge";
        private const string cancelChargeNo = "CancelChargeNo";
        private const string cancelChargeName = "CancelChargeName";
        private const string percentPrice = "PercentPrice";
        private const string dateCancel = "DateCancel";
        private const string status = "Status";

        public DALCancelCharge()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertCancelCharge(CancelCharge cancelCharge) {
            int result = 0;
            try
            {
                String[] columns = {cancelChargeName, percentPrice, dateCancel, status};
                Object[] values = {cancelCharge.CancelChargeName, cancelCharge.PercentPrice, cancelCharge.DateCancel, cancelCharge.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteCancelCharge(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {cancelChargeNo};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateCancelCharge(CancelCharge cancelCharge)
        {
            int result = 0;
            try
            {
                String[] columnNames = { cancelChargeName, percentPrice, dateCancel, status };
                Object[] values = { cancelCharge.CancelChargeName, cancelCharge.PercentPrice, cancelCharge.DateCancel, cancelCharge.Status };
                String[] keyColumnNames = {cancelChargeNo};
                Object[] keyColumnValues = {cancelCharge.CancelChargeNo};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public CancelCharge[] getCancelChargeByID(int id)
        {
            CancelCharge[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from CancelCharge where {0} = @{1}", cancelChargeNo, cancelChargeNo);
                cmd.Parameters.Add(String.Format("@{0}", cancelChargeNo), SqlDbType.Int).Value = id;
                String[] columnNames = { cancelChargeNo, cancelChargeName, percentPrice, dateCancel, status };
                result = SelectCollection<CancelCharge>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllCancelCharge()
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

        public DataTable getAllCancelChargeByStatus(Boolean status)
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

        public int checkCancelChargeExist(String name) 
        {
            try
            {
                return RecordExisted(tableName, cancelChargeName, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
