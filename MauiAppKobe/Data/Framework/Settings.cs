using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Framework
{
    public static class Settings
    {
        public static string GetConnectionString()
        {
            //string connectionString = "Trusted_Connection=True;";  

            //string connectionString = @"Data Source=JOJI_JNR\SQLEXPRESS;Initial Catalog=WPL_LOCAL_SERVER;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;"
            string connectionString =
                @"Data Source=MSI\SQLEXPRESS;
                Initial Catalog=Cars;
                Integrated Security=True;";
            return connectionString;
        }
    }
}
