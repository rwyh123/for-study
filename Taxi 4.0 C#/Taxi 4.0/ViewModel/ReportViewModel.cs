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
    public class ReportViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IServiceProvider _services;
        public ICommand ReportShow {  get; }
        public ICommand ReMainMenuCommand { get; }

        public ReportViewModel(NavigationStore navigationStore, IServiceProvider serviceProvider)
        {
            _navigationStore = navigationStore;
            _services = serviceProvider;
            ReMainMenuCommand = new NavigateCommand(_navigationStore, "MainWindowViewModel", _services);
            ReportShow = new ReportCommand(serviceProvider);
        }
    }
}
