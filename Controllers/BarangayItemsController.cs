using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpinsWebApi.Models;


namespace SpinsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangayItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarangayItemsController(ApplicationDbContext context)
        {
            _context = context;
        }


   
        // GET: api/BarangayItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarangayDTO>>> Getlib_barangay_forentity()
        {
            return await _context.lib_barangay_forentity
            .Select(x => BarangayToDTO(x))
            .ToListAsync();
        }

        // GET: api/BarangayItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BarangayDTO>> GetBarangay(long id)
        {
            var barangay = await _context.lib_barangay_forentity.FindAsync(id);

            if (barangay == null)
            {
                return NotFound();
            }

            return BarangayToDTO(barangay);
        }

        // PUT: api/BarangayItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarangay(long id, BarangayDTO barangayDTO)
        {
            if (id != barangayDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(barangayDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarangayExists(id))
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

        // POST: api/BarangayItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BarangayDTO>> PostBarangay(BarangayDTO barangayDTO)
        {
            _context.lib_barangay_forentity.Add(barangayDTO);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetBarangay", new { id = barangay.Id }, barangay);
            return CreatedAtAction(nameof(GetBarangay), new { id = barangayDTO.Id }, barangayDTO);
        }

        // DELETE: api/BarangayItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarangay(long id)
        {
            var barangay = await _context.lib_barangay_forentity.FindAsync(id);
            if (barangay == null)
            {
                return NotFound();
            }

            _context.lib_barangay_forentity.Remove(barangay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarangayExists(long id)
        {
            return _context.lib_barangay_forentity.Any(e => e.Id == id);
        }
             private static BarangayDTO BarangayToDTO(BarangayDTO barangayItem) =>
           new BarangayDTO
           {
               Id = barangayItem.Id,
               PSGCBrgy = barangayItem.PSGCBrgy,
               BrgyName = barangayItem.BrgyName,
               PSGCCityMun = barangayItem.PSGCCityMun,
               ClassificationID = barangayItem.ClassificationID
           };

    }
}
