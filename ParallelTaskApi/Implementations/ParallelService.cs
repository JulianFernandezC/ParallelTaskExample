using Microsoft.Extensions.DependencyInjection;
using ParallelTaskApi.Contexts;
using ParallelTaskApi.Contracts;
using ParallelTaskApi.Models;
using ParallelTaskApi.Utils;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelTaskApi.Implementations
{
    public class ParallelService : IParallelService
    {
        private readonly ParallelTaskContext _dbContext;
        private readonly IRandomStringGenerator _randomStringGenerator;
        private readonly IServiceProvider _services;

        public ParallelService(ParallelTaskContext dbContext, IRandomStringGenerator randomStringGenerator, IServiceProvider services)
        {
            _dbContext = dbContext;
            _randomStringGenerator = randomStringGenerator;
            _services = services;
        }

        public async Task<bool> ExecuteTasks()
        {
            Task<bool> task1 = AddStudents();
            Task<bool> task2 = AddCourses();

            Task allTasks = Task.WhenAll(task1, task2);
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                await allTasks;

                watch.Stop();
                Console.WriteLine(watch.Elapsed.TotalSeconds.ToString());
            }
            catch
            {
                AggregateException allExceptions = allTasks.Exception;
            }
          

            return true;
        }

        private async Task<bool> AddStudents()
        {
            try
            {
                using (var scope = _services.CreateScope())
                {
                    var dbService = scope.ServiceProvider.GetRequiredService<ParallelTaskContext>();

                    var list = _randomStringGenerator.DeserializeJSON();
                    Student student = new Student();
                    for (int i = 0; i < 10000; i++)
                    {
                        student.ID = 0;
                        var task1 = GenerateStudentName();
                        var task2 = GenerateStudentSurname();

                        await Task.WhenAll(task1, task2);
                        student.Name = task1.Result;
                        student.Surname = task2.Result;

                        dbService.Student.Add(student);
                        await dbService.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex); 
            }     
            return true;
        }

        private async Task<string> GenerateStudentName()
        {
            var list = _randomStringGenerator.DeserializeJSON();
            return await _randomStringGenerator.GenerateName(list);
        }
        private async Task<string> GenerateStudentSurname()
        {
            var list = _randomStringGenerator.DeserializeJSON();
            return await _randomStringGenerator.GenerateSurName(list);
        }

        private async Task<bool> AddCourses()
        {
            try
            {
                using (var scope = _services.CreateScope())
                {
                    var dbService = scope.ServiceProvider.GetRequiredService<ParallelTaskContext>();

                    var list = _randomStringGenerator.DeserializeJSON();
                    Course course = new Course();
                    for (int i = 0; i < 10000; i++)
                    {
                        course.ID = 0;
                        course.Name = _randomStringGenerator.GenerateCourse(list).Result;

                        dbService.Course.Add(course);
                        await dbService.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return true;
        }

    }
}
