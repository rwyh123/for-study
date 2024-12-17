using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi_4._0.Views;

namespace Taxi_4._0.Commands
{
    public class ReportCommand : ComandBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ReportCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void Execute(object? parameter)
        {
            var newWindow = _serviceProvider.GetRequiredService<ReportWindowViewModel>();
            var Window = _serviceProvider.GetRequiredService<ReportWindow>();
            Window.Show();
        }
    }
}
