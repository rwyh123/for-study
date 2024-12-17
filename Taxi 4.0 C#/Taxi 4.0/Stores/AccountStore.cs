using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Stores
{
    public class AccountStore
    {
        private Account _currentAccount;
        public Account CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                OnCurrentAccountChanded();
            }
        }

        private void OnCurrentAccountChanded()
        {
            CurrentAccountChanged?.Invoke();
        }

        public event Action CurrentAccountChanged;
    }
}
