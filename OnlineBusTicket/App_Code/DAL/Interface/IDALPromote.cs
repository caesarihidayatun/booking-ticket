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
/// Summary description for IDALPromote
/// </summary>
/// 
namespace DAL
{
    public interface IDALPromote
    {
        int InsertPromote(Promote promote);
        int UpdatePromote(Promote promote);
        int DeletePromote(int id);
        Promote getPromoteByID(int id);
        DataTable getAllPromote();
        DataTable getAllPromoteByStatus(Boolean status);
        int checkPromoteExistName(String name);
    }
}
