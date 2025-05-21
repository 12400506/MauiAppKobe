using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet("GetCars")]
        public ActionResult Get()
        {
            var result = Cars.GetCars();
            if (result.Succeeded)
            {
                var car = result.DataTable;
                string JSONresult = JsonConvert.SerializeObject(car);
                return Ok(JSONresult);
            }
            return NotFound();
        }

        [HttpPost("InsertCar")]
        public ActionResult InsertTeam(Car car)
        {

            try
            {
                Cars.AddCars(car);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
