using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SongcayawoninalIPT102ProjectFinal.Classes;
#nullable disable
namespace SongcayawoninalIPT102ProjectFinal.Pages
{
    public class CreatePlayerModel : PageModel
    {
        [BindProperty]
        public Players playerInput {  get; set; }

        private ConDb con;

        public CreatePlayerModel(ConDb _con)
        {
        con = _con;
        }
        public IActionResult OnPostCreate()
        {
            con.Create(playerInput);
            playerInput = new Players();    
            return Page();
        }
    }
}
