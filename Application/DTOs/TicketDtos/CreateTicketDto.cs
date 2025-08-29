using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TicketDtos
{
    public class CreateTicketDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(TicketPriority), ErrorMessage = "Invalid ticket priority.")]
        public TicketPriority Priority { get; set; }

        public Guid? AssignedToUserId { get; set; }

    }

}
