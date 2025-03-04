using Microsoft.EntityFrameworkCore;
using System;
using UserProject.Data;
using UserProject.Model;
using UserProject.Repisotry;

namespace UserProject.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {

            return await _userRepository.GetAllUsers();
        }

        public async Task<bool> AddNewUser(User user)
        {
            if (await _userRepository.EmailExists(user.Email))
            {
                return false; // Duplicate email found
            }
            await _userRepository.AddNewUser(user);
            return true;
        }


    }
}
