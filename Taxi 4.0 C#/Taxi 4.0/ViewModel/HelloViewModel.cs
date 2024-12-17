using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Taxi_4._0.Commands;
using Taxi_4._0.Stores;

namespace Taxi_4._0.ViewModel
{
    public class HelloViewModel : ViewModelBase
    {
        public ICommand HLogin { get; }
        public ICommand HRegistration { get; }

        private  IServiceProvider _serviceProvider { get; set;}
        protected Lazy<LoginViewModel> _lazyClassService;
        public HelloViewModel(NavigationStore navigationStore, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            HLogin = new NavigateCommand(navigationStore, "LoginViewModel", _serviceProvider);
            HRegistration = new NavigateCommand(navigationStore, "RegistrationViewModel", _serviceProvider);
        }

    }
}
