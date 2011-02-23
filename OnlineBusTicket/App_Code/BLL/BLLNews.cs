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
/// Summary description for BLLNews
/// </summary>
/// 
namespace BLL
{
    public class BLLNews
    {
        public BLLNews()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable getAllNews()
        {
            try
            {
                return DataAccessHelper.GetNewsDA().getAllNews();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}