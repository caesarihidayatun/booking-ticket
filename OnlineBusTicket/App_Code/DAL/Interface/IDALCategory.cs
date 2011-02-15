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
/// Summary description for IDALCategory
/// </summary>
/// 
namespace DAL
{
    public interface IDALCategory
    {
        int InsertCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int id);
        Category[] getCategoryByID(int id);
        DataTable getAllData();
        DataTable getAllDataByStatus(Boolean status);
        int checkCategoryExistName(String name);
    }
}
