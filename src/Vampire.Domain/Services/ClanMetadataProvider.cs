using System.Text.Json;

namespace Vampire.Domain.Services;

public static class ClanMetadataProvider
{
    public static List<ClanMetadata> LoadClanMetadata(string languageCode = "en")
    {
        string fileName = $"ClanMetadata_{languageCode}.json";
        if (!File.Exists(fileName))
        {
            fileName = "ClanMetadata_en.json";
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"Clan metadata file not found: {fileName}");
            }
        }

        var json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<ClanMetadata>>(json) ?? new List<ClanMetadata>();
    }
}


public class ClanMetadata
{
    public string Name { get; set; }
    public string Source { get; set; }
    public string Description { get; set; }
}

