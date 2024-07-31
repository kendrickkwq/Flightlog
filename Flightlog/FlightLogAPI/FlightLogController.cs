using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightLogAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightLogController : ControllerBase
    {
        private readonly FlightLogContext _context;

        public FlightLogController(FlightLogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightLog>>> GetFlightLogs()
        {
            return await _context.FlightLogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightLog>> GetFlightLog(int id)
        {
            var flightLog = await _context.FlightLogs.FindAsync(id);

            if (flightLog == null)
            {
                return NotFound();
            }

            return flightLog;
        }

        [HttpPost]
        public async Task<ActionResult<FlightLog>> PostFlightLog(FlightLog flightLog)
        {
            _context.FlightLogs.Add(flightLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlightLog), new { id = flightLog.Id }, flightLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightLog(int id, FlightLog flightLog)
        {
            if (id != flightLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightLog(int id)
        {
            var flightLog = await _context.FlightLogs.FindAsync(id);
            if (flightLog == null)
            {
                return NotFound();
            }

            _context.FlightLogs.Remove(flightLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightLogExists(int id)
        {
            return _context.FlightLogs.Any(e => e.Id == id);
        }
    }

}
