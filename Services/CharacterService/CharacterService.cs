using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RolePlayingGame.Models;
using RolePlayingGame.ViewModels.Character;

namespace RolePlayingGame.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters=new List<Character>{
            new Character(),
            new Character{Id=1,Name="Sam"}
        };
        public async Task<ServiceResponse<List<GetCharacterViewModel>>> AddCharacter(AddCharacterViewModel newCharacter)
        {
            Character character=new Character(){
                    Name=newCharacter.Name,
                    HitPoints=newCharacter.HitPoints,
                    Strength=newCharacter.Strength,
                    Defense=newCharacter.Defense,
                    Intelligence=newCharacter.Intelligence,
                    Class=newCharacter.Class,
                    Id=characters.Max(c => c.Id)+1
            };
            characters.Add(character);


            ServiceResponse<List<GetCharacterViewModel>> serviceResponse=new ServiceResponse<List<GetCharacterViewModel>>();  
            List<GetCharacterViewModel> list=new List<GetCharacterViewModel>();   
            foreach(Character a in characters)
            {
                GetCharacterViewModel getCharacter=new GetCharacterViewModel(){
                    Id=a.Id,
                    Name=a.Name,
                    HitPoints=a.HitPoints,
                    Strength=a.Strength,
                    Defense=a.Defense,
                    Intelligence=a.Intelligence,
                    Class=a.Class
                    };
                    list.Add(getCharacter);
            }
            serviceResponse.Data=list;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterViewModel>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterViewModel>> serviceResponse=new ServiceResponse<List<GetCharacterViewModel>>();
            
            try
            {
            Character character=characters.First(c=>c.Id==id);
            characters.Remove(character);


            List<GetCharacterViewModel> list=new List<GetCharacterViewModel>();
            foreach(var a in characters){
                GetCharacterViewModel characterE=new GetCharacterViewModel(){
                    Id=a.Id,
                    Name=a.Name,
                    HitPoints=a.HitPoints,
                    Strength=a.Strength,
                    Defense=a.Defense,
                    Intelligence=a.Intelligence,
                    Class=a.Class
                    };
                    list.Add(characterE);
            }
            serviceResponse.Data=list;
            }
            catch(Exception ex){
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterViewModel>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterViewModel>> serviceResponse=new ServiceResponse<List<GetCharacterViewModel>>();            
            List<GetCharacterViewModel> list=new List<GetCharacterViewModel>();
            foreach(var a in characters){
                GetCharacterViewModel characterE=new GetCharacterViewModel(){
                    Id=a.Id,
                    Name=a.Name,
                    HitPoints=a.HitPoints,
                    Strength=a.Strength,
                    Defense=a.Defense,
                    Intelligence=a.Intelligence,
                    Class=a.Class
                    };
                    list.Add(characterE);
            }
            serviceResponse.Data=list;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterViewModel>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterViewModel> serviceResponse=new ServiceResponse<GetCharacterViewModel>();      
            Character character=characters.FirstOrDefault(c=>c.Id==id);
            if(character !=null){
                    GetCharacterViewModel characterE=new GetCharacterViewModel(){
                    Id=character.Id,
                    Name=character.Name,
                    HitPoints=character.HitPoints,
                    Strength=character.Strength,
                    Defense=character.Defense,
                    Intelligence=character.Intelligence,
                    Class=character.Class
                    };
                    serviceResponse.Data=characterE;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterViewModel>> UpdateCharacter(UpdateCharacterViewModel updateCharacterViewModel)
        {
            
            ServiceResponse<GetCharacterViewModel> serviceResponse=new ServiceResponse<GetCharacterViewModel>();
            
            try{
                Character character=characters.FirstOrDefault(c=>c.Id==updateCharacterViewModel.Id);
            character.Name=updateCharacterViewModel.Name;
            character.Class=updateCharacterViewModel.Class;
            character.Defense=updateCharacterViewModel.Defense;
            character.HitPoints=updateCharacterViewModel.HitPoints;
            character.Intelligence=updateCharacterViewModel.Intelligence;
            character.Strength=updateCharacterViewModel.Strength;

            GetCharacterViewModel getCharacterViewModel=new GetCharacterViewModel(){
                    Name=updateCharacterViewModel.Name,
                    HitPoints=updateCharacterViewModel.HitPoints,
                    Strength=updateCharacterViewModel.Strength,
                    Defense=updateCharacterViewModel.Defense,
                    Intelligence=updateCharacterViewModel.Intelligence,
                    Class=updateCharacterViewModel.Class
            };
            serviceResponse.Data=getCharacterViewModel;
            }
            catch(Exception ex){
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }
            return serviceResponse;

        }
    }
}