using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ReferenceService
{
    public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>().UseKestrel().UseUrls("http://*:5001"); ;
            });
}
}
