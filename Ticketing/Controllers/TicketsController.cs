using Application.DTOs.TicketDtos;
using Application.Interfaces;
using Domain.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Ticketing.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;

        public TicketsController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _ticketServices.GetTicketListAsync());
            }
            catch
            {
                //log Exception
                return Problem("The operation failed");

            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var ticket = await _ticketServices.GetTicketAsync(id);
                if (ticket == null)
                    return NotFound();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var Role = User.FindFirstValue(ClaimTypes.Role);

                if (ticket.CreatedByUserId.ToString() != userId &&
                    ticket.AssignedToUserId.ToString() != userId
                    && Role != "Admin")
                    return Forbid();

                return Ok(ticket);
            }
            catch
            {
                //log Exception
                return Problem("The operation failed");
            }
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTicketDto createTicketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var createdTicket = await _ticketServices.CreateTicketAsync
                (
                    new TicketDto()
                    {
                        Title = createTicketDto.Title,
                        Priority = createTicketDto.Priority.ToString(),
                        Description = createTicketDto.Description,
                        CreatedByUserId = Guid.Parse(createdUserId),
                        AssignedToUserId = createTicketDto.AssignedToUserId
                    }
                );

                var url = Url.Action(action: nameof(Get), null, values: new { id = createdTicket }, protocol: Request.Scheme);

                return Created(uri: url, "The operation was successful.");
            }
            catch
            {
                //log Exception
                return Problem("The operation failed");
            }


        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTicketDto updateTicketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var ticket = await _ticketServices.GetTicketAsync(id);
                if (ticket == null)
                    return NotFound("The requested row was not found.");


                await _ticketServices.UpdateTicketAsync
            (
                new TicketDto()
                {
                    Id = id,
                    AssignedToUserId = updateTicketDto.AssignedToUserId,
                    Status = updateTicketDto.Status.ToString()
                }
            );

                return Ok();

            }
            catch
            {
                //log Exception
                return Problem("The operation failed");

            }


        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var ticket = await _ticketServices.GetTicketAsync(id);
                if (ticket == null)
                    return NotFound("The requested row was not found.");

                await _ticketServices.DeleteTicketAsync(id);
                return Ok("The operation was successful.");
            }
            catch
            {
                //log Exception
                return Problem("The operation failed");
            }
        }


        [HttpGet("stats")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> stats()
        {
            try
            {
                var state = await _ticketServices.GetTicketCountByStatus();
                if (state == null)
                    return NotFound("The requested row was not found.");

                return Ok(state);

            }
            catch
            {
                //log Exception
                return Problem("The operation failed");
            }

        }

        [Authorize(Roles = "Employee")]
        [HttpGet("my")]
        public async Task<IActionResult> GetCurrentUserList()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var tickets = await _ticketServices.GetTicketForUserAsync(Guid.Parse(userId));
                if (tickets == null)
                    return NotFound("The requested row was not found.");

                return Ok(tickets);

            }
            catch
            {
                //log Exception
                return Problem("The operation failed");
            }

        }



    }
}
