using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Phonebook.Features.Utilities;

public class Serialize
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    public static string Serializer<T>(T value)
    {
        return JsonSerializer.Serialize(value, JsonOptions);
    }
}