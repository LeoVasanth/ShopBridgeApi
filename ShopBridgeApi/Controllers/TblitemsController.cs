using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridgeApi.Models;

namespace ShopBridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblitemsController : ControllerBase
    {
        private readonly ModelContext _context;

        public TblitemsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Tblitems
        [HttpGet]
        public async Task<ActionResult<List<Tblitem>>> GetTblitems()
        {
            return await _context.Tblitems.ToListAsync();
        }

        // GET: api/Tblitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblitem>> GetTblitem(decimal id)
        {
            var tblitem = await _context.Tblitems.FindAsync(id);

            if (tblitem == null)
            {
                return NotFound();
            }

            return tblitem;
        }

        // PUT: api/Tblitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblitem(decimal id, Tblitem tblitem)
        {
            if (id != tblitem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(tblitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblitemExists(id))
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

        // POST: api/Tblitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblitem>> PostTblitem(Tblitem tblitem)
        {
            _context.Tblitems.Add(tblitem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblitemExists(tblitem.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblitem", new { id = tblitem.ItemId }, tblitem);
        }

        // DELETE: api/Tblitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblitem(decimal id)
        {
            var tblitem = await _context.Tblitems.FindAsync(id);
            if (tblitem == null)
            {
                return NotFound();
            }

            _context.Tblitems.Remove(tblitem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblitemExists(decimal id)
        {
            return _context.Tblitems.Any(e => e.ItemId == id);
        }
    }
}
