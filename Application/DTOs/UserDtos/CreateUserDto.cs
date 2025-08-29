using Domain.Models.Enums;

namespace Application.DTOs.UserDtos
{
    public class CreateUserDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
