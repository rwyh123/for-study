using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Services.LoginProvider;
using Taxi_4._0.Services.UnLoginProvider;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Commands
{
    internal class UnLoginCommand : ComandBase
    {
        private NavigationStore _navStore;
        private IUnLoginProvider _UnloginProvider;
        private AccountStore _accountStore;
        private IServiceProvider _serviceProvider;

        public UnLoginCommand(NavigationStore navStore, IUnLoginProvider loginProvider, AccountStore accountStore, IServiceProvider serviceProvider)
        {
            _navStore = navStore;
            _UnloginProvider = loginProvider;
            _accountStore = accountStore;
            _serviceProvider = serviceProvider;
        }

        public override void Execute(object? parameter)
        {
            _UnloginProvider.UnLogin(_navStore, _accountStore, _serviceProvider);
        }
    }
}
