using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Commands;
using Taxi_4._0.Stores;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Services.UnLoginProvider
{
    public class UnLiginProvider : IUnLoginProvider
    {
        public void UnLogin(NavigationStore navStore, AccountStore _accountStore, IServiceProvider serviceProvider)
        {
            _accountStore.CurrentAccount = null;
            var nav = new NavigateCommand(navStore, "HelloViewModel", serviceProvider);
            nav.Execute(null);
            
        }
    }
}
