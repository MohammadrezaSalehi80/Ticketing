using Application.DTOs.TicketDtos;
using Application.Interfaces;
using DataAccess.Repositories.Interfaces;
using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Application.Implementations
{
    public class TicketServices : ITicketServices
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketServices(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Guid> CreateTicketAsync(TicketDto ticket)
        {
            var ticketId = Guid.NewGuid();
            await _ticketRepository.AddAsync(
                    new Tickets()
                    {
                        Id = ticketId,
                        AssignedToUserId = ticket.AssignedToUserId,
                        CreatedAt = DateTime.Now,
                        Description = ticket.Description,
                        Priority = (TicketPriority)Enum.Parse(typeof(TicketPriority), ticket.Priority),
                        Status = TicketStatus.Open,
                        Title = ticket.Title,
                        UpdatedAt = DateTime.Now,
                        CreatedByUserId = ticket.CreatedByUserId
                    });
            return ticketId;
        }

        public Task DeleteTicketAsync(Guid Id) =>
               _ticketRepository.DeleteAsync(Id);

        public async Task<TicketDto> GetTicketAsync(Guid Id)
        {
            var ticket = await _ticketRepository.GetAsync(Id);

            if (ticket != null)
            {
                return new TicketDto
                {
                    Id = ticket.Id,
                    AssignedToUserId = ticket.AssignedToUserId,
                    Description = ticket.Description,
                    Priority = ticket.Priority.ToString(),
                    Status = ticket.Status.ToString(),
                    CreatedByUserId = ticket.CreatedByUserId,
                    Title = ticket.Title
                };
            }

            return null;
        }


        public Task<Dictionary<string, int>> GetTicketCountByStatus() => _ticketRepository.GetTicketCountByStatus();

        public async Task<IEnumerable<TicketDto>> GetTicketForUserAsync(Guid UserId)
        {
            var tickets = await _ticketRepository.GetTicketsByUserId(UserId);
            if (tickets != null)
            {

                return tickets.Select(x =>
                    new TicketDto
                    {
                        Status = x.Status.ToString(),
                        CreatedByUserId = x.CreatedByUserId,
                        Title = x.Title,
                        Id = x.Id,
                        AssignedToUserId = x.AssignedToUserId,
                        Description = x.Description,
                        Priority = x.Priority.ToString()
                    }
                ).ToList();
            }

            return Enumerable.Empty<TicketDto>();
        }

        public async Task<IEnumerable<TicketDto>> GetTicketListAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();

            if (tickets != null)
            {
                return tickets.Select(x =>
                    new TicketDto
                    {
                        Status = x.Status.ToString(),
                        CreatedByUserId = x.CreatedByUserId,
                        Title = x.Title,
                        Id = x.Id,
                        AssignedToUserId = x.AssignedToUserId,
                        Description = x.Description,
                        Priority = x.Priority.ToString()
                    }
                ).ToList();
            }

            return Enumerable.Empty<TicketDto>();
        }

        public Task UpdateTicketAsync(TicketDto ticket) => _ticketRepository.UpdateAsync(

                new Tickets()
                {
                    AssignedToUserId = ticket.AssignedToUserId,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    Priority = (TicketPriority)Enum.Parse(typeof(TicketPriority), ticket.Priority),
                    Id = ticket.Id,
                    Status = (TicketStatus)Enum.Parse(typeof(TicketStatus), ticket.Status),
                    UpdatedAt = DateTime.Now
                });


    }

}
