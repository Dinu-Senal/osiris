using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Osiris.Data.Services
{
    public class TicketService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public TicketService(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }
        #endregion

        #region Get All Tickets
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _applicationDbContext.Tickets.ToListAsync();
        }
        #endregion

        #region Add Ticket
        public async Task<bool> AddTicketAsync(Ticket ticket)
        {
            await _applicationDbContext.Tickets.AddAsync(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Update Tickets
        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            _applicationDbContext.Tickets.Update(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Ticket
        public async Task<bool> DeleteTicketAsync(Ticket ticket)
        {
            _applicationDbContext.Remove(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Ticket by Id
        public async Task<bool> DeleteTicketByIdAsync(Guid ticketId)
        {
            var Ticket = _applicationDbContext.Tickets.FirstOrDefault(data => data.TicketId == ticketId);
            if (Ticket != null)
            {
                _applicationDbContext.Remove(Ticket);
                await _applicationDbContext.SaveChangesAsync();
            }
            return true;
        }
        #endregion

        #region Filter Tickets
        public async Task<List<Ticket>> FilterTickets(String ticketFilter, String startDate)
        {
           
            String defaultDate = DateTime.MinValue.ToString("MM/dd/yyyy");
            var castedTicketList = _applicationDbContext.Tickets.AsEnumerable();

            var FitleredTicketList = await _applicationDbContext.Tickets.ToListAsync();

            if (!ticketFilter.Equals("All") && defaultDate.Equals(startDate))
            {
                FitleredTicketList = castedTicketList.Where(data => data.Status.ToLower().Equals(ticketFilter.ToLower())
                                                            ).ToList();
            }
            else if (ticketFilter.Equals("All") && !defaultDate.Equals(startDate))
            {
                FitleredTicketList = castedTicketList.Where(data => data.StartDate.ToString("MM/dd/yyyy").Equals(startDate)
                                                               ).ToList();
            }
            else if (!ticketFilter.Equals("All") && !defaultDate.Equals(startDate))
            {
                FitleredTicketList = castedTicketList.Where(data => data.Status.ToLower().Equals(ticketFilter.ToLower()) && 
                                                                    data.StartDate.ToString("MM/dd/yyyy").Equals(startDate)
                                                               ).ToList();
            }

            return FitleredTicketList;
        }
        #endregion
    }
}
