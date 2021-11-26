using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecordBook.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RecordBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<RecordBkContext>(options =>
            {
                options.UseSqlServer("Server=(local)\\sqlexpress;Database=RecordBook;Trusted_Connection=True;");
               
            });
            services.AddSingleton<MainWindow>();
        }
        private void OnStartup(object sender,StartupEventArgs e)
        {
            var mainWimdow = serviceProvider.GetService<MainWindow>();
            mainWimdow.Show();
        }
    }
}
