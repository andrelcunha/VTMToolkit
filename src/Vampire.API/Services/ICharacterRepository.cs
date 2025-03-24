using System;
using Vampire.Domain.Models;

namespace Vampire.API.Services;

public interface ICharacterRepository
{
    Task<Character?> GetCharacterByIdAsync(Guid id);
    Task<IEnumerable<Character>> GetAllCharactersAsync();
    Task AddCharacterAsync(Character character);
    Task UpdateCharacterAsync(Character character);
    Task DeleteCharacterAsync(Guid id);
}
