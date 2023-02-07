using ayclass_backend;
using ayclass_backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend_ayclass.Data
{
    public class AyClassDbContext : DbContext
    {
        public AyClassDbContext(DbContextOptions<AyClassDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}