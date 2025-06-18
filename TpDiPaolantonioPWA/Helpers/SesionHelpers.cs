using Newtonsoft.Json;

namespace TpDiPaolantonioPWA.Helpers
{
    public static class sesionHelpers
    {
        public static void SetObjectAsJson(this ISession sesion, string key, object value)
        {
            sesion.SetString(key, JsonConvert.SerializeObject(value));

        }   

        public static T GetObjectFromJson<T>(this ISession sesion, string key)
        {
            var value = sesion.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
