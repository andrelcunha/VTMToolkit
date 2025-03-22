namespace Vampire.Domain.Models;

public class AdvantageOrFlaw
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; } // Positive for advantages, negative for flaws
}
