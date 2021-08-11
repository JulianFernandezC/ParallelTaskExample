using Microsoft.EntityFrameworkCore;
using ParallelTaskApi.Models;

namespace ParallelTaskApi.Contexts
{
    public class ParallelTaskContext : DbContext
    {
        public ParallelTaskContext(DbContextOptions<ParallelTaskContext> options) : base(options)
        {
            
        }

        public ParallelTaskContext()
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }

    }
}
