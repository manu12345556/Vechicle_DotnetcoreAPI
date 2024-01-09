namespace Car.API.DTO
{
    public class UpdateCarModelRequestDTO
    {
        public int Id { get; set; } // Identifier for the car model to be updated
        public string ModelName { get; set; }
    }
}
