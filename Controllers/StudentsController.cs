using System.Net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using backend_ayclass.Data;

namespace ayclass_backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AyClassDbContext _context;

        public StudentsController(AyClassDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var students = _context.Students.AsEnumerable();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Student student)
        {
            if (string.IsNullOrEmpty(student.Password))
            {
                return BadRequest("Password cannot be empty!!");
            }

            var students = _context.Students.AsQueryable();
            var existingStudentWithEmail = students.Where(stdnt => stdnt.Email == student.Email);
            if (existingStudentWithEmail.Any())
            {
                return BadRequest("Email already exist!!");
            }

            try
            {
                student.Password = EncryptPassword(student.Password);
                await _context.AddAsync(student);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                var students = _context.Students.AsQueryable();
                var existingStudent = students.Where(student => student.Email == email).FirstOrDefault();

                if (existingStudent != null)
                {
                    if (existingStudent.Password == EncryptPassword(password))
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Wrong password");
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Logout()
        {
            try
            {
                Response.Cookies.Delete("jwt");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string EncryptPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}