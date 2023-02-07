using System.Globalization;
using ayclass_backend.models;
using backend_ayclass.Data;
using Microsoft.AspNetCore.Mvc;

namespace ayclass_backend.Controllers
{
    [Route("api/[controller]")]
    public class TutorsController : ControllerBase
    {
        private readonly AyClassDbContext _context;
        public TutorsController(AyClassDbContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_context.Tutors.AsEnumerable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(long Id)
        {
            var tutor = await _context.Tutors.FindAsync(Id);

            if (string.IsNullOrEmpty(tutor.Institution))
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterTutor([FromBody] Tutor tutor)
        {
            try
            {
                await _context.AddAsync(tutor);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}