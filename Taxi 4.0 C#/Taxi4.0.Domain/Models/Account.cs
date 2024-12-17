using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi4._0.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public User AccountHolder { get; set; }
        public IEnumerable<Order> OrderList { get; set; }
    }
}
