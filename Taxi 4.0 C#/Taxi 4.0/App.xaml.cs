using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Taxi_4._0.Commands;
using Taxi_4._0.Services.ICreateOrderProvider;
using Taxi_4._0.Services.LoginProvider;
using Taxi_4._0.Services.OrdersProvider;
using Taxi_4._0.Services.RegestrationProvider;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;
using ConnectingApps.SmartInject;
using Taxi_4._0.Services.UnLoginProvider;
using Taxi_4._0.Views;


namespace Taxi_4._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Taxi2 _taxiDbContext;

        public ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection servicces = new ServiceCollection();

            servicces.AddSingleton<NavigationStore>();
            servicces.AddSingleton<AccountStore>();
            servicces.AddSingleton<OrdersStore>();

            servicces.AddTransient<CreateOrderViewModel>();
            servicces.AddTransient<HelloViewModel>();
            servicces.AddTransient<LoginViewModel>();
            servicces.AddTransient<MainViewModel>();
            servicces.AddSingleton<MainWindowViewModel>();
            servicces.AddTransient<OrderListViewModel>();
            servicces.AddTransient<RegistrationViewModel>();
            servicces.AddTransient<ReportViewModel>();
            servicces.AddTransient<ReportWindowViewModel>();

            servicces.AddTransient<ReportWindow>();

            servicces.AddTransient<ILoginProvider, DataBaseLoginProvider>();
            servicces.AddTransient<IRegistrationProvider, DataBaseRegitrationProvider>();
            servicces.AddTransient<ICreateOrderProvider, DataBaseCreateOrderProvider>();
            servicces.AddTransient<IorderProvider, DataBaseOrdersProvider>();
            servicces.AddTransient<IUnLoginProvider, UnLiginProvider>();

            servicces.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = servicces.BuildServiceProvider();


            _taxiDbContext = new Taxi2();

        }
        protected override void OnStartup(StartupEventArgs e)
        {

            NavigationStore nav = _serviceProvider.GetRequiredService<NavigationStore>();

            nav.CurrentViewModel = _serviceProvider.GetRequiredService<HelloViewModel>();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            MainWindow.Show();
            base.OnStartup(e);
        }

    }

}
