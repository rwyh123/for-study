using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi4._0.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Location StartLocation { get; set; }
        public int StartLocationId { get; set; }
        public Location EndLocation { get; set; }
        public int EndLocationId { get; set; }
        public int Price { get; set; }
        public string FeedBack { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
        public RideTime RideTime { get; set; }
        public int Distance { get; set; }
        public Order(Location startLocation, Location endLocation, int price, string feedBack, Account account, RideTime rideTime, int distance)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
            Price = price;
            FeedBack = feedBack;
            Account = account;
            RideTime = rideTime;
            Distance = distance;
        }
        public Order()
        { }
    }
}
