using System;

namespace Vampire.API.Models;

public class AttributesDto
{
    // Physical Attributes
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Stamina { get; set; }

    // Social Attributes
    public int Charisma { get; set; }
    public int Manipulation { get; set; }
    public int Composure { get; set; }
    
    // Mental Attributes
    public int Intelligence { get; set; }
    public int Wits { get; set; }
    public int Resolve { get; set; }
}