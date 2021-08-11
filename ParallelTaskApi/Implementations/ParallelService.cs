using ParallelTaskApi.Contexts;
using ParallelTaskApi.Contracts;
using ParallelTaskApi.Models;
using ParallelTaskApi.Utils;
using System;
using System.Threading.Tasks;

namespace ParallelTaskApi.Implementations
{
    public class ParallelService : IParallelService
    {
        private readonly ParallelTaskContext _dbContext;
        private readonly IRandomStringGenerator _randomStringGenerator;

        public ParallelService(ParallelTaskContext dbContext, IRandomStringGenerator randomStringGenerator)
        {
            _dbContext = dbContext;
            _randomStringGenerator = randomStringGenerator;
        }



        public async Task<bool> ExecuteTasks()
        {
            Task<bool> task1 = AddStudents();
            Task<bool> task2 = AddCourses();

            Task allTasks = Task.WhenAll(task1, task2);
            try
            {
                await allTasks;
            }
            catch
            {
                AggregateException allExceptions = allTasks.Exception;
            }
          

            return true;
        }

        private async Task<bool> AddStudents()
        {
            var list = _randomStringGenerator.DeserializeJSON();
            Student student = new Student();
            for (int i = 0; i < 10000; i++)
            {
                student.ID = 0;
                student.Name = _randomStringGenerator.GenerateName(list);
                student.Surname = _randomStringGenerator.GenerateSurName(list);

                _dbContext.Student.Add(student);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }

        private async Task<bool> AddCourses()
        {
            var list = _randomStringGenerator.DeserializeJSON();
            Course course = new Course();
            for (int i = 0; i < 10000; i++)
            {
                course.ID = 0;
                course.Name = _randomStringGenerator.GenerateCourse(list);
                
                _dbContext.Course.Add(course);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }

    }
}
