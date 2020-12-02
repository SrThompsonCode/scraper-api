using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace web_scrapper
{
    public class Program
    {

        //LOCAL
        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        //DEPLOY HEROKU WITH DOKER
        public static void Main(string[] args)
        {
#if DEBUG
            CreateHostBuilder(args).Build().Run();
#else
            var host = CreateWebHostBuilder(args).

              UseKestrel().
              UseUrls("http://0.0.0.0:" + System.Environment.GetEnvironmentVariable("PORT")).
              Build();
            host.Run();

#endif
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}


