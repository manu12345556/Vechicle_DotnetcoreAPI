using Car.API.DTO;
using Car.API.Model;
using Car.API.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly ICarModelService _carModelService;

    public CarController(ICarService carService, ICarModelService carModelService)
    {
        _carService = carService;
        _carModelService = carModelService;
    }

    // CarModel Endpoints
    [HttpGet("car-model/{id}")]
    public async Task<ActionResult<CarModel>> GetCarModel(int id)
    {
        var carModel = await _carModelService.GetCarModelByIdAsync(id);
        if (carModel == null)
        {
            return NotFound();
        }
        return Ok(carModel);
    }

    [HttpGet("car-model")]
    public async Task<ActionResult<IEnumerable<CarModel>>> GetAllCarModels()
    {
        var carModels = await _carModelService.GetAllCarModelsAsync();
        return Ok(carModels);
    }

    [HttpPost("car-model")]
    public async Task<ActionResult<CarModelDTO>> CreateCarModel([FromBody] CreateCarModelRequestDTO carModelRequest)
    {
        var createdCarModel = await _carModelService.CreateCarModelAsync(carModelRequest);
        return CreatedAtAction(nameof(GetCarModel), new { id = createdCarModel.Id }, createdCarModel);
    }

    [HttpPut("car-model/{id}")]
    public async Task<IActionResult> UpdateCarModel(int id, [FromBody] UpdateCarModelRequestDTO carModelRequest)
    {
        if (id != carModelRequest.Id)
        {
            return BadRequest();
        }

        var updatedCarModel = await _carModelService.UpdateCarModelAsync(carModelRequest);
        if (updatedCarModel == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("car-model/{id}")]
    public async Task<IActionResult> DeleteCarModel(int id)
    {
        var result = await _carModelService.DeleteCarModelAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    // Cars Endpoints
    [HttpGet("cars/{id}")]
    public async Task<ActionResult<Cars>> GetCar(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpGet("cars")]
    public async Task<ActionResult<IEnumerable<Cars>>> GetAllCars()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpPost("cars")]
    public async Task<ActionResult<Cars>> CreateCar([FromBody] Cars car)
    {
        var carRequest = new CreateCarRequestDTO
        {
            Name = car.Name,
            CarModelId = car.CarModelId,
            CarModelName = car.CarModel.ModelName
        };

        var createdCar = await _carService.CreateCarAsync(carRequest);
        return CreatedAtAction(nameof(GetCar), new { id = createdCar.Id }, createdCar);
    }

    [HttpPut("cars/{id}")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] Cars car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        var carRequest = new UpdateCarRequestDTO
        {
            Id = car.Id,
            Name = car.Name,
            CarModelId = car.CarModelId,
            // Map other properties as needed
        };

        var updatedCar = await _carService.UpdateCarAsync(carRequest);
        if (updatedCar == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("cars/{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var result = await _carService.DeleteCarAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
