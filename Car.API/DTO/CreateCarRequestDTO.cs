using System.ComponentModel.DataAnnotations;

namespace Car.API.DTO
{
    public class CreateCarRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarModelId { get; set; }
        public string CarModelName { get; set; }
    }
}
