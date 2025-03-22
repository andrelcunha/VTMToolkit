using System;

namespace Vampire.Domain.Models;

public class Skills
{
    // Physical Skills
    public int Athletics { get; set; }
    public int Brawl { get; set; }
    public int Drive { get; set; }
    public int Firearms { get; set; }
    public int Melee { get; set; }
    public int Stealth { get; set; }
    public int Survival { get; set; }
    public int Larceny { get; set; }

    // Social Skills
    public int AnimalKen { get; set; }
    public int Etiquette { get; set; }
    public int Insight { get; set; }
    public int Intimidation { get; set; }
    public int Leadership { get; set; }
    public int Performance { get; set; }
    public int Persuasion { get; set; }
    public int Streetwise { get; set; }
    public int Subterfuge { get; set; }

    // Mental Skills
    public int Academics { get; set; }
    public int Awareness { get; set; }
    public int Finance { get; set; }
    public int Investigation { get; set; }
    public int Medicine { get; set; }
    public int Occult { get; set; }
    public int Politics { get; set; }
    public int Science { get; set; }
    public int Technology { get; set; }
}


