using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolePlayingGame.Molels;
using RolePlayingGame.Services;

namespace RolePlayingGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController:ControllerBase
    {
        private readonly ICharacterService _characterService;
        private static List<Character> characters=new List<Character>{
            new Character(),
            new Character{Id=1,Name="Sam"}
        };  
        public CharacterController(ICharacterService characterService)
        {
            this._characterService=characterService;
        }
        private static Character kniight=new Character();      

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }


        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character newCharacter){            
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

         



    }
}