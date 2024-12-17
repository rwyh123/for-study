using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi4._0.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public ICollection<Order> OrdersS { get; set; } = new List<Order>();
        public ICollection<Order> OrdersE { get; set; } = new List<Order>();
        public Location(int id, string streetName)
        {
            Id = id;
            StreetName = streetName;
        }
        public Location()
        {

        }

        public override string ToString()
        {
            return StreetName;
        }
    }
}
