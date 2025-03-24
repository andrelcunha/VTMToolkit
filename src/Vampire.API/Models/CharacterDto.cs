using System;

namespace Vampire.API.Models;

public class CharacterDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Clan { get; set; } // String version for simplicity
    public string PredatorType { get; set; } // String version for simplicity
    public int Generation { get; set; }

    public AttributesDto Attributes { get; set; } // Key-value for simplicity
    public SkillsDto Skills { get; set; } // Key-value for simplicity

    public int Health { get; set; }
    public int Willpower { get; set; }
    public int Hunger { get; set; }
    public int Humanity { get; set; }
    public int Stains { get; set; }

    // Optional Chronicle Information
    public List<TouchstoneDto> Touchstones { get; set; }
    public List<ConvictionDto> Convictions { get; set; }

    // Experience Points
    public int ExperiencePoints { get; set; }

    // Additional Simplifications or Exclusions
    public List<DisciplineDto> Disciplines { get; set; } 
    public List<AdvantageOrFlawDto> AdvantagesAndFlaws { get; set; }
}

public class ConvictionDto
{
    public string Description { get; set; }
    public string ChronicleTenet { get; set; }
}

public class TouchstoneDto
{
    public string Name { get; set; }
    public string Connection { get; set; }
}