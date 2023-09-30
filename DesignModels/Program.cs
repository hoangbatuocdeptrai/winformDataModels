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
            Application.Run(ServiceProvider.GetService<frmMainss>());
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
                    services.AddTransient<IKhuService, KhuService>();
                    services.AddTransient<IHangService, HangService>();
                    services.AddTransient<IKeService, KeService>();
                    services.AddTransient<INhapKhoService, NhapKhoService>();
                    services.AddTransient<IXuatKhoService, XuatKhoService>();
                    services.AddTransient<ILuuTruService, LuuTruService>();
                    services.AddTransient<frmMainss>();
                    services.AddTransient<Models>();
                    services.AddTransient<frmDetailsModels>();
                    services.AddTransient<frmLogin>();
                    services.AddTransient<frmNhapKho>();
                    services.AddTransient<frmXuatKho>();
                    services.AddTransient<frmKhu>();
                    services.AddTransient<frmHang>();
                    services.AddTransient<frmKe>();
                    services.AddTransient<frmTraCuu>();
                    services.AddTransient<frmBieuDo>();
                });
        }
    }
}