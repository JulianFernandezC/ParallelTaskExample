using ParallelTaskApi.Contexts;
using ParallelTaskApi.Models;
using System.Threading.Tasks;

namespace ParallelTaskApi.Implementations
{
    public class StudentRepository
    {
        private readonly ParallelTaskContext _context;

        public StudentRepository(ParallelTaskContext context)
        {
            _context = context;
        }

        public async Task<Student> Add(Student model)
        {
            if (model != null)
            {
                _context.Student.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            return null;
        }
    }
}
