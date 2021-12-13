using ChurchManager.Domain.Entidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ChurchManager.API
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
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:5000/");
                    webBuilder.UseSentry(o =>
                    {
                        o.Dsn = "https://42bb28680a9c47ebaecf813e02f67c7b@o1053240.ingest.sentry.io/6037562";
                        o.TracesSampleRate = 1.0;
                    });
                });
    }
}
