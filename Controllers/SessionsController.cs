using System.Globalization;
using backend_ayclass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ayclass_backend.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly AyClassDbContext _context;

        public SessionController(AyClassDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSession()
        {
            try
            {
                return Ok(_context.Sessions.AsEnumerable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        //adding session
        public async Task<IActionResult> RequestSession([FromBody] Session session)
        {
            try
            {
                var tutor = await _context.Tutors.Where(tut => tut.Id == session.TutorId).FirstOrDefaultAsync();

                if (tutor == null)
                {
                    return NotFound("Tutor is not found!!");
                }

                await _context.AddAsync(session);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentSession(long studentId)
        {
            var sessions = await _context.Sessions.Where(session => session.StudentId == studentId).ToListAsync();

            if (!sessions.Any())
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        [HttpGet("{tutorId}")]
        public async Task<IActionResult> GetTutorSession(long tutorId)
        {
            var sessions = await _context.Sessions.Where(session => session.TutorId == tutorId).ToListAsync();

            if (!sessions.Any())
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        [HttpPut("{id}")]
        //update session
        public async Task<IActionResult> ManageSessionRequest(long id, Session session)
        {
            if (id != session.Id)
            {
                return BadRequest();
            }
            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool SessionExists(long id)
        {
            return _context.Sessions.Any(e => e.Id == id);
        }
    }
}