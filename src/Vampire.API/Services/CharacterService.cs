using AutoMapper;
using Vampire.API.Models;
using Vampire.Domain.Models;

namespace Vampire.API.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;
    private readonly IMapper _mapper;
    public CharacterService(ICharacterRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CharacterDto?> GetCharacterByIdAsync(Guid id)
    {
        var character = await _repository.GetCharacterByIdAsync(id);
        return character == null ? null : _mapper.Map<CharacterDto>(character);
    }

    public async Task<IEnumerable<CharacterDto>> GetAllCharactersAsync()
    {
        var characters = await _repository.GetAllCharactersAsync();
        return _mapper.Map<IEnumerable<CharacterDto>>(characters);
    }

    public async Task<CharacterDto> CreateCharacterAsync(CharacterDto characterDto)
    {
        var character =  _mapper.Map<Character>(characterDto);
        await _repository.AddCharacterAsync(character);
        return _mapper.Map<CharacterDto>(character);
    }

    public async Task<CharacterDto> UpdateCharacterAsync(Guid id, CharacterDto characterDto)
    {
        var existingCharacter = await _repository.GetCharacterByIdAsync(id);
        if (existingCharacter == null) return null;

        _mapper.Map(characterDto, existingCharacter);
        
        await _repository.UpdateCharacterAsync(existingCharacter);
        return _mapper.Map<CharacterDto>(existingCharacter);
    }

    public async Task<bool> DeleteCharacterAsync(Guid id)
    {
        var character = await _repository.GetCharacterByIdAsync(id);
        if (character == null) return false;

        await _repository.DeleteCharacterAsync(id);
        return true;
    }

}
