using Newtonsoft.Json;

namespace APITestChallenge.Utilities
{
    public class JsonHelpers
    {
        public static T Deserialize<T>(string responseContent)
        {
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}