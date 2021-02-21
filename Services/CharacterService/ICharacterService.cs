using System.Collections.Generic;
using System.Threading.Tasks;
using RolePlayingGame.Models;
using RolePlayingGame.ViewModels.Character;

namespace RolePlayingGame.Services
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterViewModel>>> GetAllCharacters();
         Task<ServiceResponse<GetCharacterViewModel>> GetCharacterById(int id);
         Task<ServiceResponse<List<GetCharacterViewModel>>> AddCharacter(AddCharacterViewModel newCharacter);

         Task<ServiceResponse<GetCharacterViewModel>> UpdateCharacter(UpdateCharacterViewModel updateCharacterViewModel);
         

         Task<ServiceResponse<List<GetCharacterViewModel>>> DeleteCharacter(int id);
    }
}