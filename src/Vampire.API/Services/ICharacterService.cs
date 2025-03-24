using System;
using Vampire.API.Models;

namespace Vampire.API.Services;

public interface ICharacterService
{
    Task<CharacterDto?> GetCharacterByIdAsync(Guid id);
    Task<IEnumerable<CharacterDto>> GetAllCharactersAsync();
    Task<CharacterDto> CreateCharacterAsync(CharacterDto characterDto);
    Task<CharacterDto> UpdateCharacterAsync(Guid id, CharacterDto characterDto);
    Task<bool> DeleteCharacterAsync(Guid id);
}
