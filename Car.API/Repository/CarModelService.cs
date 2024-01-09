using Car.API.DB;
using Car.API.DTO;
using Car.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car.API.Repository
{
    public class CarModelService : ICarModelService
    {
        private readonly VechicleDbContext _context;

        public CarModelService(VechicleDbContext context)
        {
            _context = context;
        }
        public async Task<CarModelDTO> GetCarModelByIdAsync(int id)
        {
            var carModelEntity = await _context.CarModels
           .Where(cm => cm.Id == id && !cm.IsDelete) // checking IsDelete status
           .FirstOrDefaultAsync(); // 
            return MapToCarModelDTO(carModelEntity);
        }

        public async Task<IEnumerable<CarModelDTO>> GetAllCarModelsAsync()
        {
                  var carModelsEntities = await _context.CarModels
                 .Where(cm => !cm.IsDelete) 
                .ToListAsync();
            return carModelsEntities.Select(MapToCarModelDTO);
        }
        public async Task<CarModelDTO> CreateCarModelAsync(CreateCarModelRequestDTO carModelDTO)
        {
            var newCarModel = new CarModel
            {
                ModelName = carModelDTO.ModelName,
                // Map other properties from the DTO to the CarModel entity as needed
            };

            _context.CarModels.Add(newCarModel);
            await _context.SaveChangesAsync();

            return MapToCarModelDTO(newCarModel);
        }

        public async Task<CarModelDTO> UpdateCarModelAsync(UpdateCarModelRequestDTO carModelDTO)
        {
            var existingCarModel = await _context.CarModels.FindAsync(carModelDTO.Id);
            if (existingCarModel == null)
            {
                return null;
            }
            existingCarModel.ModelName = carModelDTO.ModelName;
            _context.CarModels.Update(existingCarModel);
            await _context.SaveChangesAsync();
            return MapToCarModelDTO(existingCarModel);
        }

        public async Task<bool> DeleteCarModelAsync(int id)
        {
            var carModel = await _context.CarModels.FindAsync(id);
            if (carModel == null)
                return false;

            carModel.IsDelete = true;
            await _context.SaveChangesAsync();
            return true;

        }

        // method to map entity to DTO
        private CarModelDTO MapToCarModelDTO(CarModel carModelEntity)
        {
            return new CarModelDTO
            {
                Id = carModelEntity.Id,
                ModelName = carModelEntity.ModelName,
                // Map other properties as needed
            };
        }
    }
}
