using System.Threading.Tasks;
using Events.Domain;
using Microsoft.EntityFrameworkCore;
using Events.Persistence.Contracts;
using Events.Persistence.Context;

namespace Events.Persistence
{
    public class EventsPersistence : IEventPersist
    {
        private readonly EventsContext _context;
        public EventsPersistence(EventsContext context)
        {
            _context = context;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker = false)
        {
           IQueryable<Event> query = _context.Events.Include(e => e.Batchs).Include(e => e.Socials);
            if(includeSpeaker){
                query = query.Include(e => e.SpeakersEvents).ThenInclude(pe => pe.Speaker);
            }
           query = query.OrderBy( e => e.Id);
           return await query.ToArrayAsync();
        }   
        // Eventos

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false)
        {
         IQueryable<Event> query = _context.Events.Include(e => e.Batchs).Include(e => e.Socials);
            if(includeSpeaker){
                query = query.Include(e => e.SpeakersEvents).ThenInclude(pe => pe.Speaker);
            }
           query = query.OrderBy( e => e.Id).Where(e => e.Theme.ToLower().Contains(theme.ToLower()));
           return await query.ToArrayAsync();
        }

    
        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker = false)
        {
           IQueryable<Event> query = _context.Events.Include(e => e.Batchs).Include(e => e.Socials);
            if(includeSpeaker){
                query = query.Include(e => e.SpeakersEvents).ThenInclude(pe => pe.Speaker);
            }
           query = query.OrderBy( e => e.Id).Where(e => e.Id == eventId);
           return await query.FirstOrDefaultAsync();
        }
    }
}
