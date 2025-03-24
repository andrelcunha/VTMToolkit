using System;
using Vampire.API.Models;
using Vampire.Domain.Enums;
using Vampire.Domain.Models;

namespace Vampire.API.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;

    public CharacterService(ICharacterRepository repository)
    {
        _repository = repository;
    }

    public async Task<CharacterDto> GetCharacterByIdAsync(Guid id)
    {
        var character = await _repository.GetCharacterByIdAsync(id);
        return character == null ? null : MapToDto(character);
    }

    public async Task<IEnumerable<CharacterDto>> GetAllCharactersAsync()
    {
        var characters = await _repository.GetAllCharactersAsync();
        return characters.Select(MapToDto);
    }

    public async Task<CharacterDto> CreateCharacterAsync(CharacterDto characterDto)
    {
        var character = MapToEntity(characterDto);
        await _repository.AddCharacterAsync(character);
        return MapToDto(character);
    }

    public async Task<CharacterDto> UpdateCharacterAsync(Guid id, CharacterDto characterDto)
    {
        var existingCharacter = await _repository.GetCharacterByIdAsync(id);
        if (existingCharacter == null) return null;

        existingCharacter.Name = characterDto.Name;
        existingCharacter.Clan = characterDto.Clan;
        existingCharacter.Age = characterDto.Age;

        await _repository.UpdateCharacterAsync(existingCharacter);
        return MapToDto(existingCharacter);
    }

    public async Task<bool> DeleteCharacterAsync(Guid id)
    {
        var character = await _repository.GetCharacterByIdAsync(id);
        if (character == null) return false;

        await _repository.DeleteCharacterAsync(id);
        return true;
    }

    private CharacterDto MapToDto(Character character)
    {
        return new CharacterDto
        {
            Name = character.Name,
            Clan = character.Clan.ToString(),
            PredatorType = character.PredatorType.ToString(),
            Generation = character.Generation,
            Attributes = character.Attributes?.ToDictionary(attr => attr.Name, attr => attr.Value),
            Skills = character.Skills?.ToDictionary(skill => skill.Name, skill => skill.Value),
            Health = character.Health,
            Willpower = character.Willpower,
            Hunger = character.Hunger,
            Humanity = character.Humanity,
            Stains = character.Stains,
            ExperiencePoints = character.ExperiencePoints,
            Touchstones = character.Touchstones?.Select(t => t.Name).ToList(),
            Convictions = character.Convictions?.Select(c => c.Description).ToList(),
            Disciplines = character.Disciplines?.Select(d => d.Name).ToList(),
            AdvantagesAndFlaws = character.AdvantagesAndFlaws?.Select(a => a.Description).ToList()
        };
    }

    private Character MapToEntity(CharacterDto dto)
    {
        return new Character
        {
            Name = dto.Name,
            Clan = Enum.Parse<ClanType>(dto.Clan),
            PredatorType = Enum.Parse<PredatorType>(dto.PredatorType),
            Generation = dto.Generation,
            Attributes = new Attributes(dto.Attributes),
            Skills = new Skills(dto.Skills),
            Health = dto.Health,
            Willpower = dto.Willpower,
            Hunger = dto.Hunger,
            Humanity = dto.Humanity,
            Stains = dto.Stains,
            ExperiencePoints = dto.ExperiencePoints,
            Touchstones = dto.Touchstones?.Select(name => new Touchstone(name)).ToList(),
            Convictions = dto.Convictions?.Select(desc => new Conviction(desc)).ToList(),
            Disciplines = dto.Disciplines?.Select(name => new Discipline(name)).ToList(),
            AdvantagesAndFlaws = dto.AdvantagesAndFlaws?.Select(desc => new AdvantageOrFlaw(desc)).ToList()
        };
    }

}
