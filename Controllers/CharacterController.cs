using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RolePlayingGame.Molels;

namespace RolePlayingGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController:ControllerBase
    {
        private static Character kniight=new Character();
        private static List<Character> characters=new List<Character>{
            new Character(),
            new Character{Id=1,Name="Sam"}
        };



        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id){
            return Ok(characters.FirstOrDefault(c=>c.Id==id));
        }


    }
}