using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Taxi_4._0.Commands;
using Taxi_4._0.Services.UnLoginProvider;
using Taxi_4._0.Stores;

namespace Taxi_4._0.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string CurrentAccountName { get; set; }
        public ICommand CreateOrder {get;}
        public ICommand OrderList { get; }
        public ICommand Report { get; }
        public ICommand Unlogin { get; }
        private IServiceProvider _serviceProvider { get; set; }
        public AccountStore AccountStore { get; }

        public MainWindowViewModel(NavigationStore navigationStore, IServiceProvider serviceProvider, IUnLoginProvider unLoginProvider, AccountStore accountStore)
        {
            accountStore.CurrentAccountChanged += UpdateCurretAccountName;
            _serviceProvider = serviceProvider;
            AccountStore = accountStore;
            CreateOrder = new NavigateCommand(navigationStore, "CreateViewModel", _serviceProvider);
            OrderList = new NavigateCommand(navigationStore, "OrderListViewModel", _serviceProvider);
            Report = new NavigateCommand(navigationStore, "ReportViewModel", _serviceProvider);
            Unlogin = new UnLoginCommand(navigationStore, unLoginProvider, accountStore, serviceProvider);
        }

        private void UpdateCurretAccountName()
        {
            if (AccountStore.CurrentAccount != null) 
            CurrentAccountName = AccountStore.CurrentAccount.AccountHolder.Login;
        }
    }
}
