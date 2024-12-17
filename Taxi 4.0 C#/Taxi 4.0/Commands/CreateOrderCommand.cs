using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Taxi_4._0.Services.ICreateOrderProvider;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi_4._0.Views;

namespace Taxi_4._0.Commands
{
    public class CreateOrderCommand : ComandBase
    {
        private readonly CreateOrderViewModel _covm;
        private ICreateOrderProvider _createOrderProvider;
        private AccountStore _accountStore;

        public CreateOrderCommand(CreateOrderViewModel covm, ICreateOrderProvider createOrderProvider, AccountStore accountStore)
        {
            _covm = covm;
            _createOrderProvider = createOrderProvider;
            _accountStore = accountStore;
            _covm.PropertyChanged += _covmPropertyChanged;
        }
        private void _covmPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_covm.Where) || e.PropertyName == nameof(_covm.From))
                OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return _covm.canExecute();
        }
        public override void Execute(object? parameter)
        {
            _createOrderProvider.CreateOrder(_covm, _accountStore);
        }
    }
}
