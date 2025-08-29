using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities
{
    public class Tickets
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Users CreatedByUser { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public Users AssignedToUser { get; set; }
    }


}
