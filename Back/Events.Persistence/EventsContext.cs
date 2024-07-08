using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Domain;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistence
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options) : base(options){}
        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }
        public DbSet<Social> Socials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>().HasKey(SE => new {SE.EventId, SE.SpeakerId});
        }
    }
}