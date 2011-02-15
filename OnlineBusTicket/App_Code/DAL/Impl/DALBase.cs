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
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Summary description for DALBase
/// </summary>
/// 
namespace DAL
{
    public class DALBase
    {
       protected static String ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["OnlineBus"].ConnectionString;
            }
        }

        public DALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected static int InsertTableWithReturnID(String tableName, String[] columnNames, Object[] values, out int autoID)
        {
            int result = 0;
            autoID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    String sql = "Insert into " + tableName + "(";
                    String val = " Values(";
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        //khong insert nhung truong co gia tri la null
                        if (values[i] != null)
                        {
                            sql += columnNames[i] + ",";
                            val += "@" + columnNames[i] + ",";
                        }
                    }
                    //loai bo ky tu , cuoi cung
                    sql = sql.Remove(sql.Length - 1);
                    val = val.Remove(val.Length - 1);
                    sql += ")" + val + ")";
                    sql += "; SET @AutoID = SCOPE_IDENTITY()";
                    cmd.CommandText = sql;
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        if (values[i] != null)
                            cmd.Parameters.AddWithValue(columnNames[i], values[i]);

                    }
                    //lay truong tu tang kieu int
                    SqlParameter autoIDParameter = new SqlParameter("@AutoID", SqlDbType.Int);
                    autoIDParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(autoIDParameter);

                    connection.Open();
                    result = cmd.ExecuteNonQuery();
                    try
                    {
                        if (autoIDParameter.Value != null)
                            autoID = (int)autoIDParameter.Value;
                    }
                    catch (Exception ex) { throw ex;  }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        protected static int InsertTable(String tableName, String[] columnNames, Object[] values)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    String sql = "Insert into " + tableName + "(";
                    String val = " Values(";
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        if (values[i] != null)
                        {
                            sql += columnNames[i] + ",";
                            val += "@" + columnNames[i] + ",";
                        }
                    }
                    //loai bo ky tu , cuoi cung
                    sql = sql.Remove(sql.Length - 1);
                    val = val.Remove(val.Length - 1);
                    sql += ")" + val + ")";
                    cmd.CommandText = sql;
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        if (values[i] != null)
                            cmd.Parameters.AddWithValue(columnNames[i], values[i]);

                    }
                    connection.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        protected static int UpdateTable(String tableName, String[] columnNames, Object[] values, String[] keyColumns, Object[] keyValues)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    String sql = "Update " + tableName + " set ";
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        sql += columnNames[i] + "=@" + columnNames[i] + ",";

                    }
                    //loai bo ky tu "," cuoi cung
                    sql = sql.Remove(sql.Length - 1);
                    String whereClause = " Where ";
                    for (int i = 0; i < keyColumns.Length; i++)
                    {
                        whereClause += keyColumns[i] + "=@Original_" + keyColumns[i] + " AND ";

                    }
                    //loai bo ky tu "AND " cuoi cung trong whereClause
                    whereClause = whereClause.Remove(whereClause.Length - 4);
                    cmd.CommandText = sql + whereClause;
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        if (values[i] != null)
                            cmd.Parameters.AddWithValue(columnNames[i], values[i]);
                        else
                            cmd.Parameters.AddWithValue(columnNames[i], DBNull.Value);
                    }
                    for (int i = 0; i < keyColumns.Length; i++)
                    {
                        cmd.Parameters.AddWithValue("@Original_" + keyColumns[i], keyValues[i]);
                    }
                    connection.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        protected static int DeleteTable(String tableName, String[] keyColumns, Object[] keyValues)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    String sql = "Delete " + tableName;
                    String whereClause = " Where ";
                    for (int i = 0; i < keyColumns.Length; i++)
                    {
                        whereClause += keyColumns[i] + "=@" + keyColumns[i] + " AND ";

                    }
                    //loai bo ky tu "AND " cuoi cung trong whereClause
                    whereClause = whereClause.Remove(whereClause.Length - 4);
                    cmd.CommandText = sql + whereClause;
                    for (int i = 0; i < keyColumns.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(keyColumns[i], keyValues[i]);
                    }
                    connection.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        protected static int RecordExisted(String tableName, String primaryColumnName, Object value)
        {
            try
            {
                int result = 0;
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        if (value.GetType().ToString().Equals("System.String"))
                            value = "'" + value + "'";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = String.Format("Select count(*) from {0} where {1}={2}", tableName, primaryColumnName, value);
                        connection.Open();
                        result = (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static T[] SelectCollection<T>(String[] collectionNames, String[] columnNames, SqlCommand cmd) where T : new()
        {
            List<T> resultList = new List<T>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    cmd.Connection = con;
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        T obj = new T();
                        Type t = obj.GetType();
                        PropertyInfo pInfo;
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (dr[columnNames[i]] != DBNull.Value)
                            {
                                pInfo = t.GetProperty(columnNames[i]);
                                pInfo.SetValue(obj, dr[columnNames[i]], null);
                            }
                        }
                        resultList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultList.ToArray();
        }
        protected static DataTable getAllData(String tableName)
        {
            DataTable dt = new DataTable(tableName);
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM {0}", tableName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        protected static DataTable getAllDataByStatus(String tableName,Boolean status)
        {
            DataTable dt = new DataTable(tableName);
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM {0} WHERE Status = @status", tableName);
                cmd.Parameters.AddWithValue("@status", status);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}