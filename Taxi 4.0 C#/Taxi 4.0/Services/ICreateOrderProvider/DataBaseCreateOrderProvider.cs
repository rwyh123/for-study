using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.Stores;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Services.ICreateOrderProvider
{
    public class DataBaseCreateOrderProvider : ICreateOrderProvider
    {
        private Taxi2 _taxiContext;
        public DataBaseCreateOrderProvider()
        {
            _taxiContext = new Taxi2();
        }
        public void CreateOrder(CreateOrderViewModel createOrderViewModel, AccountStore accountStore)
        {
            //var account = _taxiContext.Accounts.Include(x => x.AccountHolder).FirstOrDefault(x => x.Id == accountStore.CurrentAccount.Id);
            var where = _taxiContext.Locations.FirstOrDefault(x => x.StreetName == createOrderViewModel.Where.ToString());
            var from = _taxiContext.Locations.FirstOrDefault(x => x.StreetName == createOrderViewModel.From.ToString());
            Random rand = new Random();
            int _rnd = rand.Next(5, 100);
            var order = new Order(
                _taxiContext.Locations.Where(i => i.StreetName == createOrderViewModel.Where).FirstOrDefault(),
                _taxiContext.Locations.Where(i => i.StreetName == createOrderViewModel.From).FirstOrDefault(),
                createOrderViewModel.PrePrice,
                "<3hardcode",
                _taxiContext.Accounts.Where(i => i.Id == accountStore.CurrentAccount.Id).FirstOrDefault(),
                new RideTime(DateTime.Now, DateTime.Now.AddMinutes(_rnd), (DateTime.Now.Subtract(DateTime.Now.AddMinutes(_rnd)))),
                rand.Next(10, 80)); ;
            _taxiContext.Orders.Add(order);
            _taxiContext.SaveChanges();
            createOrderViewModel.Message = "sucessed";
        }

    }
}


