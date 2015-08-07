using System.Configuration;

namespace AstonTech.Lottery.DAL
{
    public static class AppConfiguration
    {
        /// <summary>
        /// Returns the connection string for the Application
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }

        /// <summary>
        /// Returns the name of the current connection string for the Application
        /// </summary>
        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringName"];
            }

        }
    }
}
