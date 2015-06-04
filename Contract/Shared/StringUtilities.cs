using Newtonsoft.Json;

namespace Safehaus.IntranetGaming.Contract.Shared
{
    public static class StringUtilities
    {
        public static T ToObject<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static string ToJsonString(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
