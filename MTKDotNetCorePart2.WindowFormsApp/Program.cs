namespace MTKDotNetCorePart2.WindowFormsApp;

public static class Program
{
    [STAThread]
    static void Main()
    {
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmMainMenu());
    }
}