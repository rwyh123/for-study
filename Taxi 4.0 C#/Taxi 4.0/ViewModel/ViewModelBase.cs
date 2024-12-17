using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_4._0.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnProperetyChanged(string properetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properetyName));
        }
    }
}
