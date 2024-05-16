using MartinezFinalProject.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable
namespace MartinezFinalProject.Pages
{
    public class CharacterListModel : PageModel
    {
        public IEnumerable<Character> characterList;
        public bool EditButton = false;

        public CharacterDBStore chars;

        [BindProperty]
        public Character UpdateCharacter { get; set; }

       public CharacterListModel(CharacterDBStore _chars) 
        {
            chars= _chars;
            characterList = chars.List();
        }  
        public IActionResult OnGetDelete(int Id)
        {
            chars.Delete(Id);
            characterList = chars.List();
            return Page();
        }
        public IActionResult OnGetEdit(int Id) 
        {
            EditButton = true;
            UpdateCharacter = chars.SearchById(Id)?.FirstOrDefault();
            return Page();
        }
        public IActionResult OnPostUpdate()
        
        {
            chars.Update(UpdateCharacter);
            characterList = chars.List();
            return Page();  

        }
    }
}
