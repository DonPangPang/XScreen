using Newtonsoft.Json;

namespace XScreen.WpfApp.Extensions;

public static class JsonExtensions
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.None);
    }

    public static T ToObject<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json)!;
    }
}