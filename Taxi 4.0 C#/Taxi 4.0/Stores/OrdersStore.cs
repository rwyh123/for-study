using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Stores
{
    public class OrdersStore
    {
        private readonly Taxi2 _taxi2;
        private readonly List<Order> _orders;
        public IEnumerable<Order> Orders => _orders;

        public AccountStore AccountStore { get; }

        public OrdersStore(AccountStore accountStore)
        {
            _orders = new List<Order>();
            _taxi2 = new Taxi2();
            AccountStore = accountStore;
        }
        public void Load()
        {
            _orders.AddRange(_taxi2.Orders.ToList());
        }
    }
}
