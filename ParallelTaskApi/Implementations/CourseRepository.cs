using ParallelTaskApi.Contexts;
using ParallelTaskApi.Models;
using System.Threading.Tasks;

namespace ParallelTaskApi.Implementations
{
    public class CourseRepository
    {
        private readonly ParallelTaskContext _context;

        public CourseRepository(ParallelTaskContext context)
        {
            _context = context;
        }

        public async Task<Course> Add(Course model)
        {
            if (model != null)
            {
                _context.Course.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            return null;
        }
    }
}
