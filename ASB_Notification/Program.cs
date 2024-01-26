using Microsoft.Extensions.Configuration;

namespace ASB_Notification
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            //To register all default providers:
            //var host = Host.CreateDefaultBuilder(args).Build();
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile("local.appsettings.json", optional: true, reloadOnChange: true)
               .Build();




            Application.Run(new Form1(builder));
        }




    }
}