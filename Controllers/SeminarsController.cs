using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_SignToSeminar_WebApplication.Context;
using Backend_SignToSeminar_WebApplication.Models;

namespace Backend_SignToSeminar_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarsController : ControllerBase
    {
        private readonly StsDBContext _context;

        public SeminarsController(StsDBContext context)
        {
            _context = context;
        }

        // GET: api/Seminars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seminar>>> GetAllSeminar()
        {
            return await _context.Seminars.ToListAsync();
        }

        // GET: api/Seminars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seminar>> GetSeminar(int id)
        {
            var seminar = await _context.Seminars.FindAsync(id);

            if (seminar == null)
            {
                return NotFound();
            }

            return seminar;
        }

        // PUT: api/Seminars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeminar(int id, Seminar seminar)
        {
            var dbSeminar = await _context.Seminars.FindAsync(id);
            if (dbSeminar == null)
            {
                return NotFound();
            }

            dbSeminar.Title = seminar.Title;
            dbSeminar.Speaker = seminar.Speaker;
            dbSeminar.SeminarDateTime = seminar.SeminarDateTime;
            dbSeminar.Seats = seminar.Seats;
            dbSeminar.Description = seminar.Description;

            await _context.SaveChangesAsync();

            return Ok(dbSeminar);
        }

        // POST: api/Seminars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Seminar>> PostSeminar(Seminar seminar)
        {
            _context.Seminars.Add(seminar);
            await _context.SaveChangesAsync();

            return Ok(_context.Seminars);
        }

        // DELETE: api/Seminars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seminar>> DeleteSeminar(int id)
        {
            var seminar = await _context.Seminars.FindAsync(id);
            if (seminar == null)
            {
                return NotFound();
            }

            _context.Seminars.Remove(seminar);
            await _context.SaveChangesAsync();

            return Ok(_context.Seminars);
        }

        private bool SeminarExists(int id)
        {
            return _context.Seminars.Any(e => e.Id == id);
        }
    }
}
