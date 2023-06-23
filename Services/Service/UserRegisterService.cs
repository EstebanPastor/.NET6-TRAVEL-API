using Data.Entities;
using Data.Repositories;
using Services.IService;
using System;
using System.Collections.Generic;

namespace Services.Service
{
    public class UserRegisterService : IUserRegisteredService
    {
        private readonly IUserRegisterRepository _userRegisteredRepository;

        public UserRegisterService(IUserRegisterRepository userRegisteredRepository)
        {
            _userRegisteredRepository = userRegisteredRepository;
        }

        public List<UserRegister> GetAllUsers()
        {
            return _userRegisteredRepository.GetAllUsers();
        }

        public UserRegister GetUserById(int id)
        {
            return _userRegisteredRepository.GetUserById(id);
        }

        public void AddUser(UserRegister user)
        {
            ValidateUser(user);
            _userRegisteredRepository.AddUser(user);
        }

        public void UpdateUser(UserRegister user)
        {
            ValidateUser(user);
            _userRegisteredRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            var user = _userRegisteredRepository.GetUserById(id);
            if (user != null)
            {
                _userRegisteredRepository.DeleteUser(user);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }

        private void ValidateUser(UserRegister user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("Password is required.");
            }
        }
    }
}
