using System;
using Vampire.Domain.Enums;
using Vampire.Domain.Models;

namespace Vampire.Domain.Interfaces;

public interface ICharacterService
{
    Character CreateCharacter(string name, ClanType clan, PredatorType predatorType);
    void UpdateAttributes(Character character, Attributes updatedAttributes);
    void AddDiscipline(Character character, Discipline discipline);
    void UpdateHunger(Character character, int hungerChange);
}

