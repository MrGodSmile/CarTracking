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
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;
        
        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [HttpGet]
        public IActionResult GetDrivers()
        {
            var drivers = _driverRepository.GetDrivers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public IActionResult GetDriver(int id) 
        {
            if (!_driverRepository.DriverExists(id))
            {
                return NotFound();
            }
            var driver = _driverRepository.GetDriver(id);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(driver);
        }
        
        [HttpPost]
        public IActionResult CreateDriver([FromBody] DriverDataModel driverCreate)
        {
            if (driverCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_driverRepository.CreateDriver(driverCreate))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{DriverId}")]
        public IActionResult DeleteDriver(int id)
        {
            if (!_driverRepository.DriverExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_driverRepository.DeleteDriver(id))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpPut("{DriverId}")]
        public IActionResult UpdateDriver(int DriverId, [FromBody] DriverDataModel driverUpdate)
        {
            if (driverUpdate == null)
                return BadRequest(ModelState);

            if (!_driverRepository.DriverExists(DriverId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            driverUpdate.Id = DriverId;
            if (!_driverRepository.UpdateDriver(driverUpdate))
            {
                ModelState.AddModelError("", "Ошибка");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
