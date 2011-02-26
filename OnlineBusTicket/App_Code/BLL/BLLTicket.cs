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
/// Summary description for BLLTicket
/// </summary>
/// 
namespace BLL
{
    public class BLLTicket
    {
        public BLLTicket()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int InsertTicket(Ticket ticket)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetTicketDA().InsertTicket(ticket);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static int UpdateTicket(Ticket ticket)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetTicketDA().UpdateTicket(ticket);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            return result;
        }

        public static int DeleteTicket(int id)
        {
            int result = 0;
            try
            {
                result = DataAccessHelper.GetTicketDA().DeleteTicket(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Ticket[] getTicketByID(int id)
        {
            try
            {
                return DataAccessHelper.GetTicketDA().getTicketByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static DataTable getAllTicketByStatus(Boolean status)
        //{
        //    try
        //    {
        //        return DataAccessHelper.GetTicketDA().getAllTicketByStatus(status);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static DataTable getAllTicket()
        {
            try
            {
                return DataAccessHelper.GetTicketDA().getAllTicket();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static int checkTicketNameExist(String name)
        //{
        //    try
        //    {
        //        return DataAccessHelper.GetTicketDA().checkTicketNameExist(name);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
