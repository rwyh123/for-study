using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Services.LoginProvider
{
    public interface ILoginProvider
    {
        public void Login(LoginViewModel loginViewModel, NavigationStore navStore,  AccountStore _accountStore, IServiceProvider serviceProvider);
    }
}
