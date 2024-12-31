namespace MTKDotNetCorePart2.WindowFormsApp;

#region ConnectionStrings

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

#endregion