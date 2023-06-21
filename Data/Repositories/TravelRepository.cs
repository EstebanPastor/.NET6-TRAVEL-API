using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly AppDBContext _dbContext;

        public TravelRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTravel(Entities.Travel travel)
        {
            _dbContext.Travel.Add(travel);
            _dbContext.SaveChanges();
        }

        public void UpdateTravel(Entities.Travel travel)
        {
            _dbContext.Travel.Update(travel);
            _dbContext.SaveChanges();
        }

        public void DeleteTravel(int TravelID)
        {
            var travel = _dbContext.Travel.Find(TravelID);
            if (travel != null)
            {
                _dbContext.Travel.Remove(travel);
                _dbContext.SaveChanges();
            }
        }

        public Travel GetTravelById(int TravelID)
        {
            return _dbContext.Travel.FirstOrDefault(t => t.Id == TravelID);
        }

        public List<Travel> GetAllTravels()
        {
            return _dbContext.Travel.ToList();
        }
    }
}
