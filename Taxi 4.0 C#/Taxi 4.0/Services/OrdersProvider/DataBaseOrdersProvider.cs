using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Stores;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Services.OrdersProvider
{
    public class DataBaseOrdersProvider : IorderProvider
    {
        private readonly Taxi2 _tax;

        public DataBaseOrdersProvider()
        {
            _tax = new Taxi2();
        }

        public IEnumerable<Order> GetOrders(AccountStore accountStore)
        {
            IEnumerable<Order> orders;
            orders = _tax.Orders.Where(t => t.AccountId == accountStore.CurrentAccount.Id).ToList();
            return orders;
        }
    }
}
