using System;
using System.Configuration;
namespace DAL
{
    /// <summary>
    /// Summary description for DataAccessHelper
    /// </summary>
    public class DataAccessHelper
    {
        public static String dataAccessStringType = ConfigurationManager.AppSettings["DataAccessLayerType"];

        public static IDALCategory GetCategoryDA()
        {
            IDALCategory d = null;
            if (String.IsNullOrEmpty(dataAccessStringType))
            {
                throw (new NullReferenceException("DataAccessType in Web.config is null or empty"));
            }
            else
            {
                if (dataAccessStringType.Equals("SQLSERVER"))
                {
                    Type t = Type.GetType("DAL.DALCategory");
                    d = (DALCategory)Activator.CreateInstance(t);
                }
            }
            return d;
        }

        public static IDALBusType GetBusTypeDA()
        {
            IDALBusType d = null;
            if (String.IsNullOrEmpty(dataAccessStringType))
            {
                throw (new NullReferenceException("DataAccessType in Web.config is null or empty"));
            }
            else
            {
                if (dataAccessStringType.Equals("SQLSERVER"))
                {
                    Type t = Type.GetType("DAL.DALBusType");
                    d = (DALBusType)Activator.CreateInstance(t);
                }
            }
            return d;
        }

        public static IDALBus GetBusDA()
        {
            IDALBus d = null;
            if (String.IsNullOrEmpty(dataAccessStringType))
            {
                throw (new NullReferenceException("DataAccessType in Web.config is null or empty"));
            }
            else
            {
                if (dataAccessStringType.Equals("SQLSERVER"))
                {
                    Type t = Type.GetType("DAL.DALBus");
                    d = (DALBus)Activator.CreateInstance(t);
                }
            }
            return d;
        }
    }
}