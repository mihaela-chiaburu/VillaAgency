using eUseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Credential { get; set; }
        public string Password { get; set; }
        public URole Level { get; set; }

    }
}