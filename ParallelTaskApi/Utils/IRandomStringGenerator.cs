using System.Threading.Tasks;

namespace ParallelTaskApi.Utils
{
    public interface IRandomStringGenerator
    {
        RandomStringList DeserializeJSON();
        Task<string> GenerateName(RandomStringList listRandomString);
        Task<string> GenerateSurName(RandomStringList listRandomString);
        Task<string> GenerateCourse(RandomStringList listRandomString);
    }
}