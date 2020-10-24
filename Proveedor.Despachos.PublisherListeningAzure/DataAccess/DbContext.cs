using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace CorePOSApi.Business.Data.context
{
    public class DbContext
    {
        private static string _connectionString = string.Empty;

        public static string GetConnectionString()
        {
            return "Server=tcp:turing.database.windows.net,1433;Initial Catalog=mock_proveedor;Persist Security Info=False;User ID=aesoftware;Password=artifactS20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public static SqlConnection CreateConnection()
        {
            SqlConnection DbConnection1 = new SqlConnection(GetConnectionString());
            DbConnection1.Open();
            int i = 0;
            while (DbConnection1.State != System.Data.ConnectionState.Open)
            {
                if (i < 10)
                {
                    System.Threading.Thread.Sleep(1500);
                    try
                    {
                        DbConnection1.Open();
                    }
                    catch
                    {
                    }
                    i++;
                }
                else break;
            }
            if (DbConnection1.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("DbConnection1.State != ConnectionState.Open");
            }
            return DbConnection1;
        }
    }
}