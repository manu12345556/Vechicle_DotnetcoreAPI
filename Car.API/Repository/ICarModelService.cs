using Car.API.DTO;
using Car.API.Model;

namespace Car.API.Repository
{
    public interface ICarModelService
    {
        Task<CarModelDTO> GetCarModelByIdAsync(int id);
        Task<IEnumerable<CarModelDTO>> GetAllCarModelsAsync();
        Task<CarModelDTO> CreateCarModelAsync(CreateCarModelRequestDTO carModelRequest);
        Task<CarModelDTO> UpdateCarModelAsync(UpdateCarModelRequestDTO carModelRequest);
        Task<bool> DeleteCarModelAsync(int id);
    }
}
