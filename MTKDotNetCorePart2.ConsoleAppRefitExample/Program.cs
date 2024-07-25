using Refit;
using MTKDotNetCorePart2.ConsoleAppRefitExample;

try
{
    RefitExample refitExample = new RefitExample();
    await refitExample.RunAsync();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}



