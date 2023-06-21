using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace Travel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _travelService;
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        [HttpGet]
        public ActionResult<List<Travel>> GetAllTravels()
        {
            var travels = _travelService.GetAllTravels();
            return Ok(travels);
        }

        [HttpGet("{id}")]
        public ActionResult<Travel> GetTravelById(int id)
        {
            var travel = _travelService.GetTravelById(id);
            if (travel == null)
                return NotFound();

            return Ok(travel);
        }

        [HttpPost]
        public ActionResult<Travel> AddTravel(Travel travel)
        {
            _travelService.AddTravel(travel);
            return CreatedAtAction(nameof(GetTravelById), new { id = travel.Id }, travel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTravel(int id, Travel updatedTravel)
        {
            var travel = _travelService.GetTravelById(id);
            if (travel == null)
                return NotFound();

            travel.Destination = updatedTravel.Destination;
            travel.DepartureDate = updatedTravel.DepartureDate;
            travel.ReturnDate = updatedTravel.ReturnDate;
            travel.Price = updatedTravel.Price;

            _travelService.UpdateTravel(travel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTravel(int id)
        {
            var travel = _travelService.GetTravelById(id);
            if (travel == null)
                return NotFound();

            _travelService.DeleteTravel(id);

            return NoContent();
        }

    }
}