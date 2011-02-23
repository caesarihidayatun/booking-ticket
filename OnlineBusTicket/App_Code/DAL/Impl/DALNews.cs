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
/// Summary description for DALNews
/// </summary>
/// 
namespace DAL
{
public class DALNews: DALBase,IDALNews
{
    private const string tableName = "News";
	public DALNews()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable getAllNews()
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

}
}