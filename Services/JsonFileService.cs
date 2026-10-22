using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using WestCoastEducationAssignment.CourseModels;

namespace WestCoastEducationAssignment.Services;

public static class JsonFileService
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static void SaveData<T>(List<T> items, string filePath)
    {
        string jsonString = JsonSerializer.Serialize(items, _options);
        File.WriteAllText(filePath, jsonString);
    }

    public static List<T> LoadData<T>(string filePath)
    {
        string? directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        
        if (!File.Exists(filePath))
        {
            SaveData(new List<T>(), filePath);
            return new List<T>();
        }

        string jsonString = File.ReadAllText(filePath);
        var items = JsonSerializer.Deserialize<List<T>>(jsonString, _options);
        return items ?? new List<T>();
    }
}
