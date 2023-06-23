using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRegisterRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UserRegister GetUserById(int userId)
        {
            return _dbContext.UserRegister.FirstOrDefault(u => u.Id == userId);
        }

        public UserRegister GetUserByEmail(string email)
        {
            return _dbContext.UserRegister.FirstOrDefault(u => u.Email == email);
        }

        public List<UserRegister> GetAllUsers()
        {
            return _dbContext.UserRegister.ToList();
        }

        public void AddUser(UserRegister user)
        {
            _dbContext.UserRegister.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(UserRegister user)
        {
            _dbContext.UserRegister.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(UserRegister user)
        {
            _dbContext.UserRegister.Remove(user);
            _dbContext.SaveChanges();
        }

    }
}
