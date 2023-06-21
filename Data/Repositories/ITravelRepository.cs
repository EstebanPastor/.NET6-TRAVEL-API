using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel = Data.Entities.Travel;

namespace Data.Repositories
{
    public interface ITravelRepository
    {
        void AddTravel(Travel travel);
        void UpdateTravel(Travel travel);
        void DeleteTravel(int Id);

        Travel GetTravelById(int Id);

        List<Travel> GetAllTravels();
    }

    
}
