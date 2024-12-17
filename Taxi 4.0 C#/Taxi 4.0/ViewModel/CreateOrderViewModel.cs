using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Taxi_4._0.Commands;
using Taxi_4._0.Services.ICreateOrderProvider;
using Taxi_4._0.Stores;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.ViewModel
{
    public class CreateOrderViewModel : ViewModelBase
    {
        private Taxi2 _DbContext { get; set; } = new Taxi4._0.Domain.Models.Taxi2();

        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            {
                _message = value;
                OnProperetyChanged(nameof(Message));
            }
        }


        public Dictionary<int, string> _plases { get; set; } = new Dictionary<int, string>(); // ГАДСТВО ИЗ ЗА НЕГО НЕРАБОТАЛО НИЧЕГО УБИЛ 4 ДЖЯН АААААААААААА
        public List<String> _plases_ { get; set; } = new List<String>();
        private string _where;
        public string Where 
        {
            get => _where;
            set
            {
                _where = value;
                OnProperetyChanged(nameof(Where));
            }
                
        }
        private string _from;
        public string From
        {
            get => _from;
            set
            {
                _from = value;
                OnProperetyChanged(nameof(From));
            }
        }
        private int _prePrice;

        public int PrePrice
        {
            get => _prePrice; 
            set
            {
                _prePrice = value;
                OnProperetyChanged(nameof(PrePrice));
            }
        }

        public ICommand BackToMainMenu { get; }
        public ICommand CreateOrder { get; }

        private IServiceProvider _serviceProvider { get; set; }
        public bool canExecute()
        {
            return (Where == null || From == null) ? false : true;
        }

        public CreateOrderViewModel(NavigationStore _navigationStore, AccountStore accountStore, ICreateOrderProvider createOrder, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.PropertyChanged += PrePriceValue;
            var Locations = _DbContext.Locations.ToList();
            foreach (var location in Locations)
            {
                _plases_.Add(location.StreetName);
            }
            BackToMainMenu = new NavigateCommand(_navigationStore, "MainWindowViewModel", _serviceProvider);
            CreateOrder = new CreateOrderCommand(this,createOrder, accountStore);
        }

        private void PrePriceValue(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Random rnd = new Random();
            if (e.PropertyName != nameof(PrePrice) && e.PropertyName != nameof(Message) && canExecute())
            { 
                PrePrice = rnd.Next(50,200);
            }

        }
    }
}
