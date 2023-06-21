using Data.DTO;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface ITravelService
    {
        void AddTravel(Travel travel);
        void UpdateTravel(Travel travel);
        void DeleteTravel(int travelID);
        Travel GetTravelById(int travelID);
        List<Travel> GetAllTravels();
    }
}
