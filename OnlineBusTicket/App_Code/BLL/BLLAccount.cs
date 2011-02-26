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
using DAL;

/// <summary>
/// Summary description for BLLAccount
/// </summary>
/// 
namespace BLL
{
    public class BLLAccount
    {
        public BLLAccount()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertAccount(Account account)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetAccountDA().InsertAccount(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdateAccount(Account account)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetAccountDA().UpdateAccount(account);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeleteAccount(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetAccountDA().DeleteAccount(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Account[] getAccountByID(int id)
        {
            try
            {
                return DataAccessHelper.GetAccountDA().getAccountByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllAccountByStatus(Boolean status)
        {
            try
            {
                return DataAccessHelper.GetAccountDA().getAllAccountByStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAllAccount()
        {
            try
            {
                return DataAccessHelper.GetAccountDA().getAllAccount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int checkAccountNameExist(String name)
        {
            try
            {
                return DataAccessHelper.GetAccountDA().checkAccountNameExist(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
