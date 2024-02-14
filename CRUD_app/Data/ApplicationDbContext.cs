using CRUD_app.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_app.Data {

    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
    }
}