using System.Threading.Tasks;
using Events.Domain;
using Microsoft.EntityFrameworkCore;
using Events.Persistence.Contracts;
using Events.Persistence.Context;

namespace Events.Persistence
{
    public class SpeakerPersistence : ISpeakerPersist
    {
        private readonly EventsContext _context;
        public SpeakerPersistence(EventsContext context)
        {
            _context = context;
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvent = false)
        {
            IQueryable<Speaker> query = _context.Speakers.Include(s => s.Socials);
            
            if(includeEvent){
                query = query.Include(s => s.SpeakersEvents).ThenInclude(se => se.Event);
            }
           query = query.OrderBy(s => s.Id);
          
            return await query.ToArrayAsync();
        }


        public async Task<Speaker[]> GetAllSpeakerByNameAsync(string name, bool includeEvent = false)
        {
             IQueryable<Speaker> query = _context.Speakers.Include(s => s.Socials);
            
            if(includeEvent){
                query = query.Include(s => s.SpeakersEvents).ThenInclude(se => se.Event);
            }
           query = query.OrderBy(s => s.Id).Where(s => s.Name.ToLower().Contains(name.ToLower()));
          
            return await query.ToArrayAsync();
        }


        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvent = false)
        {
           IQueryable<Speaker> query = _context.Speakers.Include(s => s.Socials);
            
            if(includeEvent){
                query = query.Include(s => s.SpeakersEvents).ThenInclude(se => se.Event);
            }
           query = query.OrderBy(s => s.Id).Where(s => s.Id == speakerId);
          
            return await query.FirstOrDefaultAsync();
        }
    }
}
