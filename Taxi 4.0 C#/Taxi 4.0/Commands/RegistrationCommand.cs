using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Taxi_4._0.Services.RegestrationProvider;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Commands
{
    public class RegistrationCommand : ComandBase
    {
        private readonly RegistrationViewModel _regView;
        private IRegistrationProvider _registrationProvider;

        public RegistrationCommand(RegistrationViewModel regView, IRegistrationProvider registrationProvider)
        {
            _regView = regView;

            _regView.PropertyChanged += _regViewPropertyChanged;

            _registrationProvider = registrationProvider;
        }

        private void _regViewPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_regView.REmail) || e.PropertyName == nameof(_regView.RLogin) || e.PropertyName == nameof(_regView.RPassword))
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return _regView.CanExecute();
        }
        public override void Execute(object? parameter)
        {
            _registrationProvider.Registration(_regView);
        }
    }
}
