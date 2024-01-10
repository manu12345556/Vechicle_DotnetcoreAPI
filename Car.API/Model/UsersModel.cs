using System.ComponentModel.DataAnnotations;

namespace Car.API.Model
{
    public class UsersModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
