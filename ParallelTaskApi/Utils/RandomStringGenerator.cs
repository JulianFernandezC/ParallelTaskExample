using Newtonsoft.Json;
using System;
using System.IO;

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

        public string GenerateName(RandomStringList listRandomString)
        {
            Random rand = new Random();
            return listRandomString.Names[rand.Next(listRandomString.Names.Count)];
        }

        public string GenerateSurName(RandomStringList listRandomString)
        {
            Random rand = new Random();
            return listRandomString.Surnames[rand.Next(listRandomString.Surnames.Count)];
        }
        public string GenerateCourse(RandomStringList listRandomString)
        {
            Random rand = new Random();
            return (listRandomString.Surnames[rand.Next(listRandomString.Courses.Count)] + "-" + rand.Next(1,100));
        }
    }
}
