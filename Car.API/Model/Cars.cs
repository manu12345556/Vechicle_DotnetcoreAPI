using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Car.API.Model
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel {  get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
