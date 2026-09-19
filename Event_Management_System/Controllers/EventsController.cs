using Event_Management_System.Data;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventsController()
    {
        _context = new AppDbContext();
    }

    [HttpGet]
    public ActionResult<List<Event>> GetAll()
    {
        var events = _context.Events
            .ToList();

        return events;
    }

    [HttpGet("{id}")]
    public ActionResult<Event> GetById(int id)
    {
        var eventDetails = _context.Events
         .Include(e => e.Organizer)
         .Include(e => e.Venue)
         .FirstOrDefault(e => e.Id == id);

        return eventDetails;
    }

    [HttpPost("{id}")]
    public IActionResult Add([FromBody] Event e)
    {
        if (e == null)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest();

        _context.Events.Add(e);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = e.Id }, e);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Event e)
    {
        if (id != e.Id)
            return BadRequest();

        var existingEvent = _context.Events.Find(id);

        if (existingEvent == null)
            return BadRequest();

        _context.Entry(e).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PartialUpdate([FromRoute] int id, int capacity)
    {
        var existingEvent = _context.Events.Find(id);

        if (existingEvent == null)
            return BadRequest();

        existingEvent.Capacity = capacity;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var existingEvent = _context.Events.Find(id);

        if (existingEvent == null)
            return NotFound();

        _context.Events.Remove(existingEvent);
        _context.SaveChanges();

        return NoContent();
    }

}
