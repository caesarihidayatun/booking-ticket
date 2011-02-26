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
/// Summary description for DALAccount
/// </summary>

namespace DAL
{
    public class DALAccount : DALBase, IDALAccount
    {
        private const string tableName = "Account";
        private const string accountID = "AccountID";
        private const string userName = "UserName";
        private const string password = "Password";
        private const string role = "Role";
        private const string birthday = "Birthday";
        private const string sex = "Sex";
        private const string identifyCode = "IdentifyCode";
        private const string fullName = "FullName";
        private const string address = "Address";
        private const string phone = "Phone";
        private const string email = "Email";
        private const string status = "Status";

        public DALAccount()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertAccount(Account account) {
            int result = 0;
            try
            {
                String[] columns = {userName, password, role, birthday, sex, identifyCode, fullName, address, phone, email, status};
                Object[] values = {account.UserName, account.Password, account.Role, account.Birthday, account.Sex, account.IdentifyCode, account.FullName, account.Address, account.Phone, account.Email, account.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteAccount(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {accountID};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateAccount(Account account)
        {
            int result = 0;
            try
            {
                String[] columnNames = {userName, password, role, birthday, sex, identifyCode, fullName, address, phone, email, status };
                Object[] values = {account.UserName, account.Password, account.Role, account.Birthday, account.Sex, account.IdentifyCode, account.FullName, account.Address, account.Phone, account.Email, account.Status };
                String[] keyColumnNames = {accountID};
                Object[] keyColumnValues = {account.AccountID};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Account[] getAccountByID(int id)
        {
            Account[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from Account where {0} = @{1}", accountID, accountID);
                cmd.Parameters.Add(String.Format("@{0}", accountID), SqlDbType.Int).Value = id;
                String[] columnNames = { accountID, userName, password, role, birthday, sex, identifyCode, fullName, address, phone, email, status };
                result = SelectCollection<Account>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllAccount()
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

        public DataTable getAllAccountByStatus(Boolean status)
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

        public int checkAccountNameExist(String name) 
        {
            try
            {
                return RecordExisted(tableName, userName, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
