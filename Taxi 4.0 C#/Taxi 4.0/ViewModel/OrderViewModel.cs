using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.ViewModel
{
    public class OrderViewModel
    {
        private readonly Taxi2 _tax;
        private readonly Order _order;
        public string Id => _order.Id.ToString();
        public string StartLocation => _tax.Locations.Where(i => i.Id == _order.StartLocationId).FirstOrDefault().ToString(); 
        public string EndLocation => _tax.Locations.Where(i => i.Id == _order.EndLocationId).FirstOrDefault().ToString();
        public string Price => _order.Price.ToString();
        public string FeedBack => _order.FeedBack.ToString();
        public DateTime Time => new DateTime((long)_order.RideTime.FinalTime　* -1);
        public string Distance => _order.Distance.ToString();
        public OrderViewModel(Order order)
        {
            _order = order;
            _tax = new Taxi2();
        }
    }
}
