using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace DeveloperStore.Api.Infra.Configuration;

public static class JsonUtils
{
    private static readonly JsonSerializerOptions DefaultOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.Create((UnicodeRanges.All))
    };
    
    public static string Serialize(object obj) => JsonSerializer.Serialize(obj, DefaultOptions);
}