using CarTracking.Entities.DataModel;
using CarTracking.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetCars();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            if (!_carRepository.CarExists(id))
            {
                return NotFound();
            }
            var car = _carRepository.GetCar(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody] CarDataModel carCreate)
        {
            if (carCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.CreateCar(carCreate))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{CarId}")]
        public IActionResult DeleteCar(int id)
        {
            if (!_carRepository.CarExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.DeleteCar(id))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpPut("{CarId}")]
        public IActionResult UpdateCar(int CarId, [FromBody] CarDataModel carUpdate)
        {
            if (carUpdate == null)
                return BadRequest(ModelState);

            if (!_carRepository.CarExists(CarId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            carUpdate.Id = CarId;
            if (!_carRepository.UpdateCar(carUpdate))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
