using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CakeBaker.Models;

namespace CakeBaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeDetailsController : ControllerBase
    {
        private readonly BakerCakeContext _context;

        public CakeDetailsController(BakerCakeContext context)
        {
            _context = context;
        }

        // GET: api/CakeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CakeDetail>>> GetCakeDetails()
        {
            return await _context.CakeDetails.ToListAsync();
        }

        // GET: api/CakeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CakeDetail>> GetCakeDetail(int id)
        {
            var cakeDetail = await _context.CakeDetails.FindAsync(id);

            if (cakeDetail == null)
            {
                return NotFound();
            }

            return cakeDetail;
        }

        // PUT: api/CakeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCakeDetail(int id, CakeDetail cakeDetail)
        {
            if (id != cakeDetail.CakeId)
            {
                return BadRequest();
            }

            _context.Entry(cakeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CakeDetailExists(id))
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

        // POST: api/CakeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CakeDetail>> PostCakeDetail(CakeDetail cakeDetail)
        {
            _context.CakeDetails.Add(cakeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCakeDetail", new { id = cakeDetail.CakeId }, cakeDetail);
        }

        // DELETE: api/CakeDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCakeDetail(int id)
        {
            var cakeDetail = await _context.CakeDetails.FindAsync(id);
            if (cakeDetail == null)
            {
                return NotFound();
            }

            _context.CakeDetails.Remove(cakeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CakeDetailExists(int id)
        {
            return _context.CakeDetails.Any(e => e.CakeId == id);
        }
    }
}
