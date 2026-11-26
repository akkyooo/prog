using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace DovidnykMelomana.Services;

/// Читання та запис об'єктів у файли формату JSON.

public static class JsonStorage
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        // кирилиця записується у файл без екранування \uXXXX
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static T Load<T>(string path) where T : new()
    {
        if (!File.Exists(path))
        {
            return new T();
        }

        var json = File.ReadAllText(path);
        if (string.IsNullOrWhiteSpace(json))
        {
            return new T();
        }

        return JsonSerializer.Deserialize<T>(json, Options) ?? new T();
    }

    public static void Save<T>(string path, T data)
    {
        var directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // спочатку пишемо в тимчасовий файл, щоб збій під час запису не зіпсував дані
        var tempPath = path + ".tmp";
        File.WriteAllText(tempPath, JsonSerializer.Serialize(data, Options));
        File.Move(tempPath, path, overwrite: true);
    }
}
