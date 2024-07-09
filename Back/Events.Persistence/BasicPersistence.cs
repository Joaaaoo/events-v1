using System.Threading.Tasks;
using Events.Domain;
using Events.Persistence.Context;
using Events.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistence
{
    public class BasicPersistence : IBasicPersist
    {
        private readonly EventsContext _context;
        public BasicPersistence(EventsContext context)
        {
            _context = context;
        }

        // Geral 
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
