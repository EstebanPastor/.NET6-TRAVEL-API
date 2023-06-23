using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IUserRegisteredService
    {
        List<UserRegister> GetAllUsers();

        UserRegister GetUserById(int id);
        void AddUser(UserRegister user);
        void UpdateUser(UserRegister user);
        void DeleteUser(int id);
    }
}
