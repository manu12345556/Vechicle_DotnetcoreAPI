using System.ComponentModel.DataAnnotations;

namespace Car.API.DTO
{
    public class CreateCarModelRequestDTO
    {
        [Required]
        public string ModelName { get; set; }
    }
}
