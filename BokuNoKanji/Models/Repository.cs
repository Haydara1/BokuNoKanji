using BokuNoKanji.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace BokuNoKanji.Services;

public static class KanjiDataService
{
    private static List<Kanji> _allKanji;

    public static async Task<List<Kanji>> GetAllKanjiAsync()
    {
        // If already loaded, return cached list
        if (_allKanji != null)
            return _allKanji;

        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("kanji.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();

            var root = JsonSerializer.Deserialize<KanjiRoot>(json);

            _allKanji = new List<Kanji>();

            if (root?.kanjis != null)
            {
                foreach (var kvp in root.kanjis)
                {
                    var k = kvp.Value;
                    _allKanji.Add(new Kanji
                    {
                        Character = k.kanji,
                        Meaning = string.Join(", ", k.meanings),
                        Onyomi = string.Join(", ", k.on_readings),
                        Kunyomi = string.Join(", ", k.kun_readings),
                        Strokes = k.stroke_count,
                        Jlpt = k.jlpt == null ? 0 : (int)k.jlpt,
                        Grade = k.grade == null ? 0 : (int)k.grade,
                    });
                }
            }

            System.Diagnostics.Debug.WriteLine($"Loaded {_allKanji.Count} kanji into memory");
            return _allKanji;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Failed to load kanji JSON: " + ex);
            return new List<Kanji>();
        }
    }

    // JSON models
    public class KanjiRoot
    {
        public Dictionary<string, JsonKanji> kanjis { get; set; }
    }

    public class JsonKanji
    {
        public string kanji { get; set; }
        public string[] meanings { get; set; }
        public string[] on_readings { get; set; }
        public string[] kun_readings { get; set; }
        public int? grade { get; set; }
        public int? jlpt { get; set; }
        public int stroke_count { get; set; }
    }
}
