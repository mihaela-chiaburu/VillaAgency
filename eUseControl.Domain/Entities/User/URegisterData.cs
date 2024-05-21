using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
    public class URegisterData
    {
        public string Username {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string RegistrationIp { get; set; }
        public DateTime RegistrationDateTime { get; set; }
    }
}
