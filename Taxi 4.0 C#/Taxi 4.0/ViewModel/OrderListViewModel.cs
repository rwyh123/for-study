using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Taxi_4._0.Commands;
using Taxi_4._0.Services.OrdersProvider;
using Taxi_4._0.Stores;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.ViewModel
{
    public class OrderListViewModel : ViewModelBase
    {
        public ObservableCollection<OrderViewModel> _orders { get; set; }
        public IEnumerable<OrderViewModel> Oders => _orders;
        public ICommand LoadOrdersCommand { get; set; }
        public ICommand BackToMainMenu { get; }
        public ICommand CreateOrder { get; }
        private IServiceProvider _serviceProvider { get; set; }

        public OrderListViewModel(NavigationStore _navigationStore, OrdersStore ordersStore, AccountStore accountStore, IorderProvider iorderProvider, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _orders = new ObservableCollection<OrderViewModel>();
            LoadOrdersCommand = new LoadOrdersCommand(this, ordersStore, iorderProvider, accountStore);
            BackToMainMenu = new NavigateCommand(_navigationStore, "MainWindowViewModel", _serviceProvider);
            CreateOrder = new NavigateCommand(_navigationStore, "CreateViewModel", _serviceProvider);
            LoadOrdersCommand.Execute(this);
        }

        void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }


    }
}
