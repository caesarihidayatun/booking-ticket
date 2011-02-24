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
/// Summary description for Router
/// </summary>
/// 
namespace DAL
{
    public class Router
    {
        private int routerID;
        private string routerName;
        private string startPlace;
        private string destinationPlace;
        private int distance;
        private string description;
        private bool status;

        public Router()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int RouterID
        {
            get { return routerID; }
            set { routerID = value; }
        }

        public string RouterName
        {
            get { return routerName; }
            set { routerName = value; }
        }

        public string StartPlace
        {
            get { return startPlace; }
            set { startPlace = value; }
        }

        public string DestinationPlace
        {
            get { return destinationPlace; }
            set { destinationPlace = value; }
        }

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}