using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.ViewModel;

namespace Taxi_4._0.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanded();
            }
        }


        public NavigationStore()
        { }
        private void OnCurrentViewModelChanded()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
