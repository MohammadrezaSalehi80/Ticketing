using Application.DTOs.TicketDtos;
using DataAccess.Repositories.Implementations;
using Domain.Models.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITicketServices
    {
        Task<IEnumerable<TicketDto>> GetTicketListAsync();
        Task<TicketDto> GetTicketAsync(Guid Id);
        Task<IEnumerable<TicketDto>> GetTicketForUserAsync(Guid UserId);
        Task<Dictionary<string, int>> GetTicketCountByStatus();
        Task<Guid> CreateTicketAsync(TicketDto ticket);
        Task DeleteTicketAsync(Guid Id);
        Task UpdateTicketAsync(TicketDto ticket);
    }

}
