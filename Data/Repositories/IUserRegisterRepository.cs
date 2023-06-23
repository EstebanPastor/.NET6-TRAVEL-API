using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IUserRegisterRepository
    {
        UserRegister GetUserById(int userId);
        UserRegister GetUserByEmail(string email);
        List<UserRegister> GetAllUsers();
        void AddUser(UserRegister user);
        void UpdateUser(UserRegister user);
        void DeleteUser(UserRegister user);
    }
}
