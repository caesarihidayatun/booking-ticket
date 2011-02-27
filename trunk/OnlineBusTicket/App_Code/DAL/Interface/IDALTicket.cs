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
/// Summary description for IDALTicket
/// </summary>
/// 
namespace DAL
{
    public interface IDALTicket
    {
        int InsertTicket(Ticket ticket);
        int UpdateTicket(Ticket ticket);
        int DeleteTicket(int key);
        Ticket[] getTicketByID(int id);
        Ticket[] getTicketByListBusID(int lisbusID);
        DataTable getAllTicket();

    }
}
