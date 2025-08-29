using Application.DTOs.UserDtos;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDto>> GetUsersListAsync();
        Task<UserDto> GetUserAsync(Guid Id);
        Task<Guid> CreateUserAsync(CreateUserDto createUserDto);
        Task DeleteUserAsync(Guid Id);
        Task UpdateUserAsync(UpdateUserDto ticket);
        UpdateUserDto GetUserByEmail(string Email);
    }

}
