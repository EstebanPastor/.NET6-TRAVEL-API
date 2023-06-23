using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                var travels = _travelService.GetAllTravels().ToList();
                return Ok(travels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting all the travels: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Travel> GetTravelById(int id)
        {
            try
            {
                var travel = _travelService.GetAllTravels().FirstOrDefault(t => t.Id == id);
                if (travel == null)
                    return NotFound("Travel not found with that id.");

                return Ok(travel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while obtaining the trip " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Travel> AddTravel(Travel travel)
        {
            try
            {
                _travelService.AddTravel(travel);
                return CreatedAtAction(nameof(GetTravelById), new { id = travel.Id }, travel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding a travel: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTravel(int id, Travel updatedTravel)
        {
            try
            {
                var travel = _travelService.GetAllTravels().FirstOrDefault(t => t.Id == id);
                if (travel == null)
                    return NotFound("Error while updating that id.");

                travel.Destination = updatedTravel.Destination;
                travel.DepartureDate = updatedTravel.DepartureDate;
                travel.ReturnDate = updatedTravel.ReturnDate;
                travel.Price = updatedTravel.Price;

                _travelService.UpdateTravel(travel);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating the travel: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTravel(int id)
        {
            try
            {
                var travel = _travelService.GetAllTravels().FirstOrDefault(t => t.Id == id);
                if (travel == null)
                    return NotFound("Travel not found with that id.");

                _travelService.DeleteTravel(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting the travel: " + ex.Message);
            }
        }
    }
}
