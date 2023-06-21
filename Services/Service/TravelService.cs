using Data.DTO;
using Data.Entities;
using Data.Repositories;
using Data.Repositories;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{

    public class TravelService : ITravelService
    {
        private readonly ITravelRepository _travelRepository;
        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public void AddTravel(Travel travel)
        {
            _travelRepository.AddTravel(travel);
        }

        public void UpdateTravel(Travel travel)
        {
            _travelRepository.UpdateTravel(travel);
        }

        public void DeleteTravel(int travelID)
        {
            _travelRepository.DeleteTravel(travelID);
        }

        public Travel GetTravelById(int travelID)
        {
            return _travelRepository.GetTravelById(travelID);
        }

        public List<Travel> GetAllTravels()
        {
            return _travelRepository.GetAllTravels();
        }

    }
}