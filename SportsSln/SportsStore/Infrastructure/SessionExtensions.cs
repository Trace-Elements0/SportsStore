using Microsoft.AspNetCore.Http;
using System.Text.Json;
namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {//Class file provides access to the session state data to serialize Cart objects into JSON and convert them back
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
                ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}