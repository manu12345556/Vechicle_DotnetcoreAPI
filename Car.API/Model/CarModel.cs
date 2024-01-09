using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car.API.Model
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ModelName { get; set; }

        public bool IsDelete { get; set; }


    }
}
