using System.Collections.Generic;
using System.Threading.Tasks;
using RolePlayingGame.Molels;

namespace RolePlayingGame.Services
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<Character>>> GetAllCharacters();
         Task<ServiceResponse<Character>> GetCharacterById(int id);
         Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
         
    }
}