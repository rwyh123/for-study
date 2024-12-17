using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi4._0.Domain.Models
{
    public class User
    { 
        public int UserId { get; set; }
        public string Login { get; set; } 
        public string Email { get; set; }
        public int Password { get; set; }
        public DateOnly RegDate { get; set; }

    }
}
