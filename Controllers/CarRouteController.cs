using CarTracking.Entities.DataModel;
using CarTracking.Interfaces;
using CarTracking.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRouteController : ControllerBase
    {
        private readonly ICarRouteRepository _carRouteRepository;
        
        public CarRouteController(ICarRouteRepository carRouteRepository)
        {
            _carRouteRepository = carRouteRepository;
        }

        [HttpGet]
        public IActionResult GetCarRoutes()
        {
            var carRoutes = _carRouteRepository.GetCarRoutes();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carRoutes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarRoute(int id) 
        {
            if (!_carRouteRepository.CarRouteExists(id))
            {
                return NotFound();
            }
            var carRoute = _carRouteRepository.GetCarRoute(id);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carRoute);
        }

        [HttpPost]
        public IActionResult CreateCarRoute([FromBody] CarRouteDataModel carRouteCreate)
        {
            if (carRouteCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRouteRepository.CreateCarRoute(carRouteCreate))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{CarRouteId}")]
        public IActionResult DeleteCarRoute(int id)
        {
            if (!_carRouteRepository.CarRouteExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRouteRepository.DeleteCarRoute(id))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{CarRouteId}")]
        public IActionResult UpdateCarRoute(int CarRouteId, [FromBody] CarRouteDataModel carRouteUpdate)
        {
            if (carRouteUpdate == null)
                return BadRequest(ModelState);

            if (!_carRouteRepository.CarRouteExists(CarRouteId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            carRouteUpdate.Id = CarRouteId;
            if (!_carRouteRepository.UpdateCarRoute(carRouteUpdate))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
