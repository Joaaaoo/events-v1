using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Application.Contracts;
using Events.Domain;
using Events.Persistence.Contracts;

namespace Events.Application
{
    public class EventService : IEventsService
    {
        private readonly IBasicPersist _basicPersist;
        private readonly IEventPersist _eventPersist;

        public EventService(IBasicPersist basicPersist, IEventPersist eventPersist)
        {
            _basicPersist = basicPersist;
            _eventPersist = eventPersist;
        }

        public async Task<Event> AddEvents(Event model)
        {
            try
            {
                _basicPersist.Add<Event>(model);
                if(await _basicPersist.SaveChangesAsync()){
                    return await _eventPersist.GetAllEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var eventToUpdate = await _eventPersist.GetAllEventByIdAsync(eventId, false);
                if (eventToUpdate == null) return null;

                model.Id = eventToUpdate.Id;

                _basicPersist.Update<Event>(model);
                if (await _basicPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetAllEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var eventToDelete = await _eventPersist.GetAllEventByIdAsync(eventId, false);
                if (eventToDelete == null) throw new Exception("Event not found");

                _basicPersist.Delete<Event>(eventToDelete);
                return await _basicPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsAsync(includeSpeaker);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeaker);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       public async Task<Event> GetAllEventByIdAsync(int EventId, bool includeSpeaker = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventByIdAsync( EventId, includeSpeaker);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}