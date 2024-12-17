using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_4._0.ViewModel;
using Taxi4._0.Domain.Models;

namespace Taxi_4._0.Services.RegestrationProvider
{
    public class DataBaseRegitrationProvider : IRegistrationProvider
    {
        private Taxi2 _taxiContext;

        public DataBaseRegitrationProvider()
        {
            _taxiContext = new Taxi2();
        }

        public void Registration(RegistrationViewModel registrationViewModel)
        {
            var user = _taxiContext.Users.Where(i => i.Login == registrationViewModel.RLogin).FirstOrDefault();
            if (user == null)
            {
                registrationViewModel.ErrorMessage = "Succussed registration";
                var tody = DateTime.Now;
                var usertoadd = new User(registrationViewModel.RLogin, registrationViewModel.REmail, int.Parse(registrationViewModel.RPassword), new DateTime(tody.Year, tody.Month, tody.Day));
                _taxiContext.Users.Add(usertoadd);
                var account = new Account(usertoadd);
                _taxiContext.Accounts.Add(account);
                _taxiContext.SaveChanges();

            }
            else
            {
                registrationViewModel.ErrorMessage = "Registrtion failed,requre ununiq username";
            }
        }
    }
}
