using AutoMapper;
using BbCenter.Dto.User;
using BbCenter.Exceptions;
using BbCenter.Models;
using BbCenter.Repositories.Interface;
using BbCenter.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace BbCenter.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositories _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepositories userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto CreateUser(CreateUserDto userDto)
        {
            // Get user by email
            User user = _userRepository.GetUserByEmail(userDto.Email);
            if (user != null)
            {
                throw new ConflictException("Email already exists");
            }

            // Hash password
            var passwordHasher = new PasswordHasher<string>();
            userDto.Password = passwordHasher.HashPassword(null, userDto.Password);

            // Map registerDto to user
            user = _mapper.Map<User>(userDto);

            // Create user
            _userRepository.CreateUser(user);

            return _mapper.Map<UserDto>(_userRepository.GetUserById(user.UserId));
        }

        public string DeleteUser(Guid userId)
        {
            User user = _userRepository.GetUserById(userId) ?? throw new NotFoundException("User not found");

            _userRepository.DeleteUser(user);

            return "User deleted successfully";
        }

        public List<UserDto> GetAllUser()
        {
            List<User> users = _userRepository.GetAllUser();
            return _mapper.Map<List<UserDto>>(users);
        }

        public UserDto GetUserById(Guid userId)
        {
            User user = _userRepository.GetUserById(userId) ?? throw new NotFoundException("User not found");
            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            User user = _userRepository.GetUserById(id) ?? throw new NotFoundException("User not found");
            updateUserDto.UserId = id;

            if (updateUserDto.Password != null)
            {
                updateUserDto.Password = HashPassword(updateUserDto.Password);
            }
            else
            {
                updateUserDto.Password = user.Password;
            }

            user = _mapper.Map<User>(updateUserDto);

            _userRepository.UpdateUser(user);

            return _mapper.Map<UserDto>(_userRepository.GetUserById(user.UserId));
        }

        public string HashPassword(string newPassword)
        {
            var passwordHasher = new PasswordHasher<string>();
            return passwordHasher.HashPassword(null, newPassword);
        }

        public List<UserDto> GetAllUserByRoleIdAndBranchId(QueryDto queryDto)
        {
            List<User> users = _userRepository.GetAllUserByRoleIdAndBranchId(queryDto);
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
