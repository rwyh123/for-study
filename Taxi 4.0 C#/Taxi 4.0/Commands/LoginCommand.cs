using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Taxi_4._0.Services.LoginProvider;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Commands
{
    internal class LoginCommand : ComandBase
    {
        private readonly LoginViewModel _logView;
        private readonly Taxi2 _taxiContext;
        private NavigationStore _navStore;
        private MainWindowViewModel _mvVM;
        private ILoginProvider _loginProvider;
        private AccountStore _accountStore;
        private IServiceProvider _serviceProvider;

        public LoginCommand(LoginViewModel logView, Taxi2 taxiContext, NavigationStore navStore, MainWindowViewModel mvVM, ILoginProvider loginProvider,AccountStore accountStore, IServiceProvider serviceProvider)
        {
            _logView = logView;
            _taxiContext = taxiContext;
            _navStore = navStore;
            _mvVM = mvVM;
            _loginProvider = loginProvider;
            _accountStore = accountStore;
            _serviceProvider = serviceProvider;
        }

        public override void Execute(object? parameter)
        {
            _loginProvider.Login(_logView,_navStore, _accountStore, _serviceProvider);
        }
    }
}
