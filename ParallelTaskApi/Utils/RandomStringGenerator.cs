using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ParallelTaskApi.Utils
{
    public class RandomStringGenerator : IRandomStringGenerator
    {
        public RandomStringList DeserializeJSON()
        {
            using (TextReader textReader = File.OpenText("data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (RandomStringList)serializer.Deserialize(textReader, typeof(RandomStringList));
            }
        }

        public Task<string> GenerateName(RandomStringList listRandomString)
        {
            Random rand = new Random();
            return Task.FromResult(listRandomString.Names[rand.Next(listRandomString.Names.Count)]);
        }

        public Task<string> GenerateSurName(RandomStringList listRandomString)
        {
            Random rand = new Random();
            return Task.FromResult(listRandomString.Surnames[rand.Next(listRandomString.Surnames.Count)]);
        }
        public Task<string> GenerateCourse(RandomStringList listRandomString)
        {
            Random rand = new Random();
            return Task.FromResult((listRandomString.Courses[rand.Next(listRandomString.Courses.Count)] + "-" + rand.Next(1,100)));
        }
    }
}
