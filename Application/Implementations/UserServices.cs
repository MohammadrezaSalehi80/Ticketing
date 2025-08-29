using Application.DTOs.UserDtos;
using Application.Interfaces;
using DataAccess.Repositories.Interfaces;
using Domain.Models.Entities;

namespace Application.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public UserServices(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> CreateUserAsync(CreateUserDto createUserDto)
        {
            var userId = Guid.NewGuid();
            await _userRepository.AddAsync(
                    new Users()
                    {
                        Id = userId,
                        Email = createUserDto.Email,
                        FullName = createUserDto.FullName,
                        Password = _passwordHasher.HashPassword(createUserDto.Password),
                        Role = createUserDto.Role,
                    });

            return userId;
        }


        public Task DeleteUserAsync(Guid Id) =>
                     _userRepository.DeleteAsync(Id);

        public async Task<UserDto> GetUserAsync(Guid Id)
        {
            var user = await _userRepository.GetAsync(Id);

            if (user != null)
            {
                return new UserDto
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Role = user.Role.ToString(),
                    Id = user.Id
                };
            }

            return null;
        }



        public UpdateUserDto GetUserByEmail(string Email)
        {
            var user = _userRepository.GetUserByEmail(Email);

            if (user != null)
            {
                return new UpdateUserDto
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Role = user.Role,
                    Password = user.Password,
                    Id = user.Id
                };
            }

            return null;
        }

        public async Task<IEnumerable<UserDto>> GetUsersListAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (users != null)
            {
                return users.Select(x =>
                    new UserDto
                    {
                        Role = x.Role.ToString(),
                        Id=x.Id,
                        Email = x.Email,
                        FullName = x.FullName
                    }
                ).ToList();
            }

            return Enumerable.Empty<UserDto>();
        }

        public Task UpdateUserAsync(UpdateUserDto ticket) => _userRepository.UpdateAsync(

                new Users()
                {
                    Id = ticket.Id,
                    FullName = ticket.FullName,
                    Email = ticket.Email,
                    Role = ticket.Role,
                    Password = _passwordHasher.HashPassword(ticket.Password)
                });
    }

}
