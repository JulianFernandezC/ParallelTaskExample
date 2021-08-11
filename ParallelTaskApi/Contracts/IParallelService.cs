using System.Threading.Tasks;

namespace ParallelTaskApi.Contracts
{
    public interface IParallelService
    {
        Task<bool> ExecuteTasks();
    }
}
