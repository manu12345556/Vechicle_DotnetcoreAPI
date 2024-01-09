using Car.API.DTO;
using Car.API.Model;

namespace Car.API.Repository
{
    public interface ICarService
    {
        Task<CarDTO> GetCarByIdAsync(int id);
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();
        Task<CarDTO> CreateCarAsync(CreateCarRequestDTO carRequest);
        Task<CarDTO> UpdateCarAsync(UpdateCarRequestDTO carRequest);
        Task<bool> DeleteCarAsync(int id);
    }

}
