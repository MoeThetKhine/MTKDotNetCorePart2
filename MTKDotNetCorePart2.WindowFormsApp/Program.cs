namespace MTKDotNetCorePart2.WindowFormsApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmMainMenu());
    }
}