using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vampire.API.Models;
using Vampire.API.Services;

namespace Vampire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(Guid id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound(new { Message = $"Character with {id} not found" });
            }
            return Ok(character);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody]CharacterDto characterDto)
        {
            if (characterDto == null)
            {
                return BadRequest(new { Message = "Character data is required" });
            }

            var CreateCharacter = await _characterService.CreateCharacterAsync(characterDto);
            return CreatedAtAction(nameof(GetCharacterById), new { id = CreateCharacter.Id }, CreateCharacter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(Guid id, [FromBody]CharacterDto characterDto)
        {
            if (characterDto == null || id != characterDto.Id)
            {
                return BadRequest(new { Message = "Invalid data or ID mismatch" });
            }

            var updatedCharacter = await _characterService.UpdateCharacterAsync(id, characterDto);
            if (updatedCharacter == null)
            {
                return NotFound(new { Message = $"Character with {id} not found" });
            }

            return Ok(updatedCharacter);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(Guid id)
        {
            var deleted = await _characterService.DeleteCharacterAsync(id);
            if (!deleted)
            {
                return NotFound(new { Message = $"Character with {id} not found" });
            }

            return NoContent();
        }
    }
}
