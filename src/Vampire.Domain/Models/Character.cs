using System;
using Vampire.Domain.Enums;

namespace Vampire.Domain.Models;

public class Character
{
    // Basic Information
    public string Name { get; set; }
    public ClanType Clan { get; set; }
    public PredatorType PredatorType { get; set; }
    public int Generation { get; set; } // Vampire generation (e.g., 13th Gen)

    // Attributes (Physical, Social, Mental)
    public Attributes Attributes { get; set; }

    // Skills
    public Skills Skills { get; set; }

    // Disciplines (Vampire powers)
    public List<Discipline> Disciplines { get; set; }

    // Health and Willpower
    public int Health { get; set; }
    public int Willpower { get; set; }

    // Hunger
    public int Hunger { get; set; }

    // Experience Points (for progression)
    public int ExperiencePoints { get; set; }

    // Advantages and Flaws
    public List<AdvantageOrFlaw> AdvantagesAndFlaws { get; set; }

    // Chronicle-specific elements
    public List<Touchstone> Touchstones { get; set; }
    public List<Conviction> Convictions { get; set; }

    // Humanity and Stains
    public int Humanity { get; set; }
    public int Stains { get; set; }
}
