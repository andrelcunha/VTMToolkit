using System;
using Vampire.Domain.Enums;

namespace Vampire.Domain.Models;

public class Character
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ClanType Clan { get; set; }
    public PredatorType PredatorType { get; set; }
    public int Generation { get; set; } // Vampire generation (e.g., 13th Gen)
    public Attributes Attributes { get; set; }
    public Skills Skills { get; set; }
    public int Health { get; set; }
    public int Willpower { get; set; }
    public int Hunger { get; set; }
    public int Humanity { get; set; }
    public int Stains { get; set; }

    public List<Touchstone> Touchstones { get; set; }
    public List<Conviction> Convictions { get; set; }

    public int ExperiencePoints { get; set; }
    public List<Discipline> Disciplines { get; set; }
    public List<AdvantageOrFlaw> AdvantagesAndFlaws { get; set; }
}
