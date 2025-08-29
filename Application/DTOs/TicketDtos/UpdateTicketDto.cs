using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.TicketDtos
{
    public class UpdateTicketDto
    {
        public Guid? AssignedToUserId { get; set; }

        [Required]
        public TicketStatus Status { get; set; }
    }

}
