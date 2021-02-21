using System.Collections.Generic;
using System.Threading.Tasks;
using RolePlayingGame.Molels;

namespace RolePlayingGame.Services
{
    public interface ICharacterService
    {
         Task<List<Character>> GetAllCharacters();
         Task<Character> GetCharacterById(int id);
         Task<List<Character>> AddCharacter(Character newCharacter);
         
    }
}