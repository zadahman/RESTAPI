using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Z33xClient.Models;

namespace Z33xClient.Controllers
{
    [Route("api/Records")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordDbContext _context;

        public RecordsController(RecordDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> Get()
        {
            return await _context.Records.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> Get(long id)
        {
            var record = await _context.Records.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Record record)
        {
            if (id != record.id)
            {
                return BadRequest();
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Record>> Post(Record record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = record.id }, record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordExists(long id)
        {
            return _context.Records.Any(e => e.id == id);
        }
    }
}
