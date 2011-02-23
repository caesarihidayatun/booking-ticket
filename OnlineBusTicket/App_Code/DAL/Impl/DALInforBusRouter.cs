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
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALInforBusRouter
/// </summary>
public class DALInforBusRouter:DALBase,IDALInfoBusRouter
{
    String[] columns = { "BusPlate", "BusName", "Arrival", "Departure", "Price", "Seat" };
	public DALInforBusRouter()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public InfoBusRouter[] getBusRouter(String start, String end, String startPlace, String destinationPlace)
    {
        InfoBusRouter[] result = null;

        DateTime start1 = DateTime.Parse(start);
        DateTime end1 = DateTime.Parse(end);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ListBus,Router,Bus where @start<=Departure and Departure<=@end and StartPlace=@startPlace and DestinationPlace=@destinationPlace and ListBus.RouterID=Router.RouterID and ListBus.BusPlate=Bus.BusPlate";
            cmd.Parameters.AddWithValue("@start", start1);
            cmd.Parameters.AddWithValue("@end", end1);
            cmd.Parameters.AddWithValue("@startPlace", startPlace);
            cmd.Parameters.AddWithValue("@destinationPlace", destinationPlace);
            result = DALBase.SelectCollection<InfoBusRouter>(null, columns,cmd);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return result;
    }
}
