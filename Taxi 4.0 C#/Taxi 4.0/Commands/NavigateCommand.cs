using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;

namespace Taxi_4._0.Commands
{
    public class NavigateCommand : ComandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly string _modelName;
        private readonly IServiceProvider _serviceProvider;

        public NavigateCommand(NavigationStore navigationStore, string modelName, IServiceProvider serviceProvider)
        {
            _navigationStore = navigationStore;
            _modelName = modelName;
            _serviceProvider = serviceProvider;

        }

        public override void Execute(object? parameter)
        {
            switch (_modelName)
            {
                case "CreateViewModel":
                    _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<CreateOrderViewModel>();
                    break;
                case "HelloViewModel":
                    _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<HelloViewModel>();
                    break;
                case "LoginViewModel":
                    _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
                    break;
                case "MainWindowViewModel":
                    _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
                    break;
                case "OrderListViewModel":
                    _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<OrderListViewModel>();
                    break;
                case "RegistrationViewModel":
                    _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<RegistrationViewModel>();
                    break;
                case "ReportViewModel":
                    _navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<ReportViewModel>();
                    break;


            }

        }


        }
}
