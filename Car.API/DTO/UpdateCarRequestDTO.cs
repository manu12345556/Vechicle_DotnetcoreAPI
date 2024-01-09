using System.ComponentModel.DataAnnotations;

namespace Car.API.DTO
{
    public class UpdateCarRequestDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CarModelId { get; set; }
    }
}
