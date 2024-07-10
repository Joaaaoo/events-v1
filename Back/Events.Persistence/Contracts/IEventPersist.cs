using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Events.Domain;

namespace Events.Persistence.Contracts
{
    public interface IEventPersist
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool IncludeSpeaker = false );
        Task<Event[]> GetAllEventsAsync( bool IncludeSpeaker = false );
        Task<Event> GetAllEventByIdAsync(int eventId, bool IncludeSpeaker = false );
    }
}