using System;

namespace Vampire.API.Models;

public class CharacterDto
{
    public Guid Id { get; set; }
    // Basic Information
    public string Name { get; set; }
    public string Clan { get; set; } // String version for simplicity
    public string PredatorType { get; set; } // String version for simplicity
    public int Generation { get; set; }

    // Attributes and Skills (Optional for API)
    public Dictionary<string, int> Attributes { get; set; } // Key-value for simplicity
    public Dictionary<string, int> Skills { get; set; } // Key-value for simplicity

    // Core Stats
    public int Health { get; set; }
    public int Willpower { get; set; }
    public int Hunger { get; set; }
    public int Humanity { get; set; }
    public int Stains { get; set; }

    // Optional Chronicle Information
    public List<string> Touchstones { get; set; }
    public List<string> Convictions { get; set; }

    // Experience Points
    public int ExperiencePoints { get; set; }

    // Additional Simplifications or Exclusions
    public List<string> Disciplines { get; set; } // String names of Disciplines
    public List<string> AdvantagesAndFlaws { get; set; } // String descriptions
}

