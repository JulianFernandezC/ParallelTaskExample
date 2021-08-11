using Microsoft.AspNetCore.Mvc;
using ParallelTaskApi.Contracts;
using System.Threading.Tasks;

namespace ParallelTaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParallelTaskController : Controller
    {
        private readonly IParallelService _parallelService;

        public ParallelTaskController(IParallelService parallelService)
        {
            _parallelService = parallelService;
        }

        [HttpPost("ExecuteInsertTasks")]
        public async Task<bool> ExecuteParallelTasks()
        {
            return await _parallelService.ExecuteTasks();
        }
    }
}
