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

/// <summary>
/// Summary description for IDALAccount
/// </summary>
/// 
namespace DAL
{
    public interface IDALAccount
    {
        int InsertAccount(Account account);
        int UpdateAccount(Account account);
        int DeleteAccount(int key);
        Account[] getAccountByID(int id);
        DataTable getAllAccount();
        DataTable getAllAccountByStatus(Boolean status);
        int checkAccountNameExist(String name);
    }
}
