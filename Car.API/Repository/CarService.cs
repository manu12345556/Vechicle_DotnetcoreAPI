using Car.API.DB;
using Car.API.DTO;
using Car.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.API.Repository
{
    public class CarService : ICarService
    {
        private readonly VechicleDbContext _context;
        public CarService(VechicleDbContext context)
        {
            _context = context;
        }

        public async Task<CarDTO> GetCarByIdAsync(int id)
        {
            var carEntity = await _context.Cars
            .Include(c => c.CarModel)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDelete);
            if (carEntity == null)
                return null;
            return MapToCarDTO(carEntity);
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            var carsEntities = await _context.Cars
            .Include(c => c.CarModel)
            .Where(c => !c.IsDelete) 
            .ToListAsync();
            return carsEntities.Select(MapToCarDTO);
        }

        public async Task<CarDTO> CreateCarAsync(CreateCarRequestDTO carRequest)
        {
            var newCar = new Cars
            {
                Name = carRequest.Name,
                CarModelId = carRequest.CarModelId
            };
            _context.Cars.Add(newCar);
            await _context.SaveChangesAsync();
            return MapToCarDTO(newCar);
        }

        public async Task<CarDTO> UpdateCarAsync(UpdateCarRequestDTO carRequest)
        {
            var existingCar = await _context.Cars.FindAsync(carRequest.Id);

            if (existingCar == null)
                return null; 
            existingCar.Name = carRequest.Name;
            existingCar.CarModelId = carRequest.CarModelId;

            _context.Cars.Update(existingCar);
            await _context.SaveChangesAsync();

            return MapToCarDTO(existingCar);
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var carEntity = await _context.Cars.FindAsync(id);
            if (carEntity == null)
                return false;

            carEntity.IsDelete = true; 
            await _context.SaveChangesAsync();
            return true;

        }

        // map entity to DTO
        private CarDTO MapToCarDTO(Cars carEntity)
        {
            return new CarDTO
            {
                Id = carEntity.Id,
                Name = carEntity.Name,
                CarModelId = carEntity.CarModelId,
                CarModelName = carEntity.CarModel?.ModelName,
            };
        }
    }
}
