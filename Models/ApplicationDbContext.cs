using Microsoft.EntityFrameworkCore;

namespace SpinsWebApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BarangayDTO> lib_barangay_forentity{ get; set; } = null!;
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        

    }
}