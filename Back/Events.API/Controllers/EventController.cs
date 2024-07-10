using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Events.Domain;
using Events.Persistence;
using Microsoft.EntityFrameworkCore;
using Events.Application.Contracts;

namespace Events.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventsService _eventsService;
        public EventoController( IEventsService eventsService )
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
                var events = await _eventsService.GetAllEventsAsync(true);
                if (events == null) return NotFound("No events were found");
                return Ok(events);
           }
           catch (Exception ex)
           {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error trying do return all events. Error: {ex.Message}");
           }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var events = await _eventsService.GetAllEventByIdAsync(id, true);
                if (events == null) return NotFound("No events by id were found");
                return Ok(events);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error trying do return event. Error: {ex.Message}");
            }
        }

         [HttpGet("{theme}/theme")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var events = await _eventsService.GetAllEventsByThemeAsync(theme, true);
                if (events == null) return NotFound("No events were found by theme");
                return Ok(events);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error trying do return event. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var events = await _eventsService.AddEvents(model);
                if (events == null) return BadRequest("Error trying to add events");
                return Ok(events);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error trying do add event. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try
            {
                var events = await _eventsService.UpdateEvent(id, model);
                if (events == null) return BadRequest("Error trying to update event");
                return Ok(events);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error trying do update event. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await _eventsService.DeleteEvent(id))
                    return Ok("Event removed");
                else
                    return BadRequest("Error removing event");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error trying do remove event. Error: {ex.Message}");
            }
        }
    }
