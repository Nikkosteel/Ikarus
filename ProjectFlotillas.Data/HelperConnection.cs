using System.Configuration;

namespace ProjectFlotillas.Data
{
    public class HelperConnection
    {
        private static string connection;

        public static string Connection()
        {
            connection = ConfigurationManager.ConnectionStrings["flotillas"].ToString();
            return connection;
        }
    }
}
