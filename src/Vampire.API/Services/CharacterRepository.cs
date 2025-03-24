using AutoMapper;
using Vampire.Domain.Models;

namespace Vampire.API.Services;

public class CharacterRepository : ICharacterRepository
{
    private readonly List<Character> _characters = new();
    private readonly IMapper _mapper;

    public CharacterRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<Character?> GetCharacterByIdAsync(Guid id)
    {
        return await Task.FromResult(_characters.FirstOrDefault(c => c.Id == id));
    }
    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        return await Task.FromResult(_characters);
    }

    public async Task AddCharacterAsync(Character character)
    {
        _characters.Add(character);
        await Task.CompletedTask;
    }

    public async Task UpdateCharacterAsync(Character character)
    {
        var existingCharacter = _characters.FirstOrDefault(c => c.Id == character.Id);
        if (existingCharacter != null)
        {
            _mapper.Map(character, existingCharacter);
        }
        await Task.CompletedTask;
    }

    public async Task DeleteCharacterAsync(Guid id)
    {
        var character = _characters.FirstOrDefault(c => c.Id == id);
        if (character != null)
        {
            _characters.Remove(character);
        }
        await Task.CompletedTask;
    }
}
