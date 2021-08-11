namespace ParallelTaskApi.Utils
{
    public interface IRandomStringGenerator
    {
        RandomStringList DeserializeJSON();
        string GenerateName(RandomStringList listRandomString);
        string GenerateSurName(RandomStringList listRandomString);
        string GenerateCourse(RandomStringList listRandomString);
    }
}