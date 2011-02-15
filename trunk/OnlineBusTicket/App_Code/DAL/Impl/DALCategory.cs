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
/// Summary description for DALCategory
/// </summary>

namespace DAL
{
    public class DALCategory : DALBase, IDALCategory
    {
        private const string tableName = "Category";
        private const string categoryId = "CategoryID";
        private const string categoryName = "CategoryName";
        private const string status = "Status";

        public DALCategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertCategory(Category category) {
            int result = 0;
            try
            {
                String[] columns = {categoryName, status};
                Object[] values = {category.CategoryName, category.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {categoryId};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateCategory(Category category)
        {
            int result = 0;
            try
            {
                String[] columnNames = {categoryName, status};
                Object[] values = {category.CategoryName, category.Status};
                String[] keyColumnNames = {categoryId};
                Object[] keyColumnValues = {category.CategoryID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Category[] getCategoryByID(int id)
        {
            Category[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from Category where {0} = @{1}", categoryId, categoryId);
                cmd.Parameters.Add(String.Format("@{0}", categoryId), SqlDbType.Int).Value = id;
                String[] columnNames = { categoryId, categoryName, status};
                result = SelectCollection<Category>(columnNames, columnNames, cmd);

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

        public DataTable getAllDataByStatus(Boolean status)
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

        public int checkCategoryExistName(String name) 
        {
            try
            {
                return RecordExisted(tableName, categoryName, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
