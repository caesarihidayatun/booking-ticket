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
/// Summary description for DALPromote
/// </summary>

namespace DAL
{
    public class DALPromote : DALBase, IDALPromote
    {
        private const string tableName = "Promote";
        private const string promoteID = "PromoteID";
        private const string promoteName = "PromoteName";
        private const string discount = "Discount";
        private const string status = "Status";

        public DALPromote()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertPromote(Promote promote) {
            int result = 0;
            try
            {
                String[] columns = {promoteName, discount, status };
                Object[] values = {promote.PromoteName, promote.Discount, promote.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeletePromote(int key)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {promoteID};
                Object[] keyColumnValues = {key};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdatePromote(Promote promote)
        {
            int result = 0;
            try
            {
                String[] columnNames = { promoteName, discount, status };
                Object[] values = { promote.PromoteName, promote.Discount, promote.Status};
                String[] keyColumnNames = { promoteID };
                Object[] keyColumnValues = {promote.PromoteID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Promote getPromoteByID(int id)
        {
            Promote[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from Promote where {0} = @{1}", promoteID, promoteID);
                cmd.Parameters.Add(String.Format("@{0}", promoteID), SqlDbType.Int).Value = id;
                String[] columnNames = {promoteID, promoteName, discount, status};
                result = SelectCollection<Promote>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result[0];
        }

        public DataTable getAllPromote()
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

        public DataTable getAllPromoteByStatus(Boolean status)
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

        public int checkPromoteExistName(String name)
        {
            try
            {
                return RecordExisted(tableName, promoteName, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
