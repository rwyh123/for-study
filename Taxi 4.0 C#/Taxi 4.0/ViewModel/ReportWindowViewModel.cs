using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Stores;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.ViewModel
{
    public class ReportWindowViewModel
    {
        public  string OrdersCount { get; set; }
        public string TotalDistanse {  get; set; }
        private  int _totalDistanse {  get; set; }
        public string TotalPrice {  get; set; }
        private  int _totalPrice {  get; set; }
        public ReportWindowViewModel(AccountStore accountStore)
        {
            var dbcont = new Taxi2();

            var orderList  = dbcont.Orders.Where(i => i.AccountId == accountStore.CurrentAccount.Id).ToList();

            OrdersCount = orderList.Count.ToString();

            foreach (var order in orderList)
            {
                _totalDistanse += order.Distance;
            }

            TotalDistanse = _totalDistanse.ToString();

            foreach (var order in orderList)
            {
                _totalPrice += order.Price;
            }

            TotalPrice = _totalPrice.ToString();

        }

    }
}
