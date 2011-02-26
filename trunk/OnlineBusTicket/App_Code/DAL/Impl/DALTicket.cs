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
/// Summary description for DALTicket
/// </summary>

namespace DAL
{

    public class DALTicket : DALBase, IDALTicket
    {
        private const string tableName = "Ticket";
        private const string ticketNo = "TicketNo";
        private const string dateBooking = "DateBooking";
        private const string listBusID = "ListBusID";
        private const string accountID = "AccountID";
        private const string numberSeat = "NumberSeat";
        private const string promoteID = "PromoteID";
        private const string cancelDate = "CancelDate";
        private const string totalFees = "TotalFees";
        private const string description = "Description";
        private const string totalReal = "TotalReal";
        private const string status = "Status";

        public DALTicket()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int InsertTicket(Ticket ticket) {
            int result = 0;
            try
            {
                String[] columns = { dateBooking, listBusID, accountID, numberSeat, promoteID, cancelDate, totalFees, totalReal, description, status };
                Object[] values = {ticket.DateBooking, ticket.ListBusID, ticket.AccountID, ticket.NumberSeat, ticket.PromoteID, ticket.CancelDate, ticket.TotalFees, ticket.TotalReal, ticket.Description, ticket.Status};
                result = DALBase.InsertTable(tableName, columns, values) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteTicket(int id)
        {
            int result = 0;
            try
            {
                String[] keyColumnNames = {ticketNo};
                Object[] keyColumnValues = {id};
                result = DALBase.DeleteTable(tableName, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public int UpdateTicket(Ticket ticket)
        {
            int result = 0;
            try
            {
                String[] columnNames = { dateBooking, listBusID, accountID, numberSeat, promoteID, cancelDate, totalFees, totalReal, description, status };
                Object[] values = { ticket.DateBooking, ticket.ListBusID, ticket.AccountID, ticket.NumberSeat, ticket.PromoteID, ticket.CancelDate, ticket.TotalFees, ticket.TotalReal, ticket.Description, ticket.Status };
                String[] keyColumnNames = {ticketNo};
                Object[] keyColumnValues = {ticket.TicketNo};
                result = DALBase.UpdateTable(tableName, columnNames, values, keyColumnNames, keyColumnValues);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Ticket[] getTicketByID(int id)
        {
            Ticket[] result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Format("Select * from Ticket where {0} = @{1}", ticketNo, ticketNo);
                cmd.Parameters.Add(String.Format("@{0}", ticketNo), SqlDbType.Int).Value = id;
                String[] columnNames = { ticketNo, dateBooking, listBusID, accountID, numberSeat, promoteID, cancelDate, totalFees, totalReal, description, status };
                result = SelectCollection<Ticket>(columnNames, columnNames, cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable getAllTicket()
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

        //public DataTable getAllTicketByStatus(string status)
        //{
        //    try
        //    {
        //        return DALBase.getAllDataByStatus(tableName, status);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public int checkTicketNameExist(String name) 
        //{
        //    try
        //    {
        //        return RecordExisted(tableName, userName, name);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
