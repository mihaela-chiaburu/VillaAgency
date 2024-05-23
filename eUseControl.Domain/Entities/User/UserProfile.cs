using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities.User
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public int Age { get; set; }
        public string Biography { get; set; }
    }
}
