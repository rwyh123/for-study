using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Taxi_4._0.Commands;
using Taxi_4._0.Services.RegestrationProvider;
using Taxi_4._0.Stores;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.ViewModel
{
    public class RegistrationViewModel : ViewModelBase
    {
        private Taxi2 _DbContext { get; set; } = new Taxi4._0.Domain.Models.Taxi2();
        private string rLogin = "";
        public string RLogin
        {   get => rLogin;
            set
            {
                rLogin = value;
                OnProperetyChanged(nameof(RLogin));
            }
        }
        private string rPassword = "";

        public string RPassword
        {
            get => rPassword;
            set
            {
                rPassword = value;
                OnProperetyChanged(nameof(RPassword));
            }
        }

        public string rEmail = "";

        public string REmail
        {
            get => rEmail;
            set
            {
                rEmail = value;
                OnProperetyChanged(nameof(REmail));
            }
        }

        private string _errorMesage;

        public string ErrorMessage
        {
            get { return _errorMesage; }
            set
            {
                _errorMesage = value;
                OnProperetyChanged(nameof(ErrorMessage));
            }
        }

        public bool CanExecute()
        {
            if ((REmail == "" || RLogin == "" || RPassword == ""))
            {
                ErrorMessage = "All fields need to be, filled";
                return false;

            }
            else
            {
                ErrorMessage = "";
                return true;
            }
        }

        public IRegistrationProvider _registrationProvider;
        private IServiceProvider _serviceProvider { get; set; }
        public ICommand RHello { get; }
        public ICommand RRegistrationCommand { get; }
        public RegistrationViewModel(NavigationStore navigationStore, IRegistrationProvider registrationProvider, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RHello = new NavigateCommand(navigationStore, "HelloViewModel", _serviceProvider);
            RRegistrationCommand = new RegistrationCommand(this, registrationProvider);
            _registrationProvider = registrationProvider;
        }
    }
}
