using MartinezFinalProject.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable
namespace MartinezFinalProject.Pages
{
    public class GetInfoModel : PageModel
    {
        public CharacterDBStore chars;

        [BindProperty]
        public Character character { get; set; }

        public GetInfoModel(CharacterDBStore _chars)
        {
            chars = _chars;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPostSubmit()
        {
            chars.Create(character);

            return Page();
        }
    }
}
