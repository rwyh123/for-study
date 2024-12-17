using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Services.OrdersProvider;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;

namespace Taxi_4._0.Commands
{
    public class LoadOrdersCommand : ComandBase
    {
        private readonly OrderListViewModel _oderListModel;
        private readonly OrdersStore _orderStore;
        private readonly IorderProvider _orderProvider;
        private readonly AccountStore _accountStore;

        public LoadOrdersCommand(OrderListViewModel oderListModel, OrdersStore orderStore, IorderProvider iorderProvider,AccountStore accountStore)
        {
            _oderListModel = oderListModel;
            _orderStore = orderStore;
            _orderProvider = iorderProvider;
            _accountStore = accountStore;
        }

        public override void Execute(object? parameter)
        {
            //привязать к совйству чтобы каждый раз не подгружать !!!
            var orders = _orderProvider.GetOrders(_accountStore);
            foreach (var order in orders)
            {
                _oderListModel._orders.Add(new OrderViewModel(order));
            }
        }
    }
}
