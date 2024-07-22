﻿using System.Data.SqlClient;

namespace MTKDotNetCorePart2.PizzaApi.Database
{
    public class ConnectionStrings
    {
        public static SqlConnectionStringBuilder _sqlConnectionStringBuilder =
            new()
            {
                DataSource = "localhost",
                InitialCatalog = "OJTBatch1",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
    }
}
