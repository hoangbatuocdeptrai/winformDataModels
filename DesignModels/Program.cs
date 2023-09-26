using DesignModels.Service;
using DesignModels.Services;
using DesignModels.Services.FileImage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesignModels
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ServiceProvider = CreateHostBuilder().Build().Services;
            Application.Run(ServiceProvider.GetService<frmLogin>());
            //Application.Run(ServiceProvider.GetRequiredService<frmMainss>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    //services.AddHelloServices(context.Configuration);
                    services.AddTransient<IDbservice, DbService>();
                    services.AddTransient<IModelsService, ModelsService>();
                    services.AddTransient<IFileImageService, FileImageService>();
                    services.AddTransient<frmMainss>();
                    services.AddTransient<Models>();
                    services.AddTransient<frmDetailsModels>();
                    services.AddTransient<frmLogin>();
                });
        }
    }
}