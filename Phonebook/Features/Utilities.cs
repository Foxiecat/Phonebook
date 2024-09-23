using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Phonebook.Features;

public class Utilities
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    public static string Serialize<T>(T value)
    {
        return JsonSerializer.Serialize(value, JsonOptions);
    }
}