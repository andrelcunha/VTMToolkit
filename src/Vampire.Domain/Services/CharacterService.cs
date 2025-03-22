using System;
using Vampire.Domain.Enums;
using Vampire.Domain.Interfaces;
using Vampire.Domain.Models;

namespace Vampire.Domain.Services;

public class CharacterService : ICharacterService
{ 
    
    public Character CreateCharacter(string name, ClanType clan, PredatorType predatorType)
    {
        return new Character
        {
            Name = name,
            Clan = clan,
            PredatorType = predatorType,
            Attributes = new Attributes(),
            Disciplines = new List<Discipline>(),
            Hunger = 0, 
        };
    }
    public void AddDiscipline(Character character, Discipline discipline)
    {
        if (!character.Disciplines.Contains(discipline))
        {
            character.Disciplines.Add(discipline);
        }
    }

    public void UpdateAttributes(Character character, Attributes updatedAttributes)
    {
        character.Attributes = updatedAttributes;
    }

    public void UpdateHunger(Character character, int hungerChange)
    {
        character.Hunger = Math.Clamp(character.Hunger + hungerChange, 0, 5);
    }
}
