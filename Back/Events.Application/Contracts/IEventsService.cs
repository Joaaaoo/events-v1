using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Domain;

namespace Events.Application.Contracts
{
    public interface IEventsService
    {
        Task<Event> AddEvents (Event model);
        Task<Event> UpdateEvent (int eventId, Event model);
        Task<bool> DeleteEvent (int eventId);

        Task<Event[]> GetAllEventsAsync( bool IncludeSpeaker = false );
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool IncludeSpeaker = false );
        Task<Event> GetAllEventByIdAsync(int EventId, bool IncludeSpeaker = false );
    }
}