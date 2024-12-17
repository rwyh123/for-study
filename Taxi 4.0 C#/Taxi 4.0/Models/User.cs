using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi4._0.Domain.Models
{
    public class User
    { 
        public int Id { get; set; }
        public string Login { get; set; } 
        public string Email { get; set; }
        public int Password { get; set; }
        public DateTime RegDate { get; set; }
        public ICollection<Account> Accounts { get; }
        public User(string login, string email, int password, DateTime regDate)
        {

            Login = login;
            Email = email;
            Password = password;
            RegDate = regDate;
        }
        public User()
        {

        }

    }
}
