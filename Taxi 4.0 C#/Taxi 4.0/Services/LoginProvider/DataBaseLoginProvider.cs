using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Commands;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Services.LoginProvider
{
    public class DataBaseLoginProvider : ILoginProvider
    {
        private Taxi2 _DBContext;

        public DataBaseLoginProvider()
        {
            _DBContext = new Taxi2();
        }
        public void Login(LoginViewModel loginViewModel, NavigationStore navStore, AccountStore _accountStore, IServiceProvider serviceProvider)
        {
            var user = _DBContext.Users.Where(i => i.Login == loginViewModel.LLogin && i.Password == loginViewModel.LPassword).FirstOrDefault();
            if (user == null)
            {
                loginViewModel.ErrorMessage = "Cannot login, check entered data";
                loginViewModel.LLogin = string.Empty;
                loginViewModel.LPassword = null;

            }
            else
            {
                loginViewModel.ErrorMessage = "Succussed login";
                var nav = new NavigateCommand(navStore, "MainWindowViewModel", serviceProvider);
                nav.Execute(null);
                _accountStore.CurrentAccount = _DBContext.Accounts.Where(i => i.AccountHolder.Id == user.Id).FirstOrDefault();
                
            }
        }
    }
}
