using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi4._0.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public int Price { get; set; }
        public string FeedBack { get; set;}
        public User User { get; set; }
        public RideTime RideTime { get; set; }
        public int Distance { get; set;}
    }
}
