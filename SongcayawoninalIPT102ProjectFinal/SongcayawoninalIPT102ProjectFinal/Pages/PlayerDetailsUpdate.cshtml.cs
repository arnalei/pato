using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SongcayawoninalIPT102ProjectFinal.Classes;
using System.Numerics;
#nullable disable
namespace SongcayawoninalIPT102ProjectFinal.Pages
{
    public class PlayerDetailsUpdateModel : PageModel
    {
        public IEnumerable<Players> playerOptions;
        public ConDb con;

        [BindProperty]
        public Players playUpdate { get; set; }

        [BindProperty]
        public int PlayerDetailsId { get; set; }
        public PlayerDetailsUpdateModel(ConDb _con)
        {
            con = _con;
            playerOptions = con.playerlist();
        }
        public IActionResult OnPostPlayerDetailsDisplay()
        {
            playUpdate = con.PickedPlayer(PlayerDetailsId)?.FirstOrDefault();
            return Page();
        }
        public IActionResult OnPostPlayerDetailsUpdate()
        {

            con.PlayerDetailsUpdate(playUpdate);
            playUpdate = new Players();
            playerOptions = con.playerlist();
            return Page();
        }
    }
}
