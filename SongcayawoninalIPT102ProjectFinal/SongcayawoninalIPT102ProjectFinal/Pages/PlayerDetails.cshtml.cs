using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SongcayawoninalIPT102ProjectFinal.Classes;
using System.Collections.Generic;

#nullable disable

namespace SongcayawoninalIPT102ProjectFinal.Pages
{
    public class PlayerDetailsModel : PageModel
    {
        public IEnumerable<Players> playerOptions;
        public ConDb con;

        [BindProperty]
        public Players playD { get; set; }

        [BindProperty]
        public int PlayerDetailsId { get; set; }

        public PlayerDetailsModel(ConDb _con)
        {
            con = _con;
            playerOptions = con.playerlist();
            playD = new Players();
        }

        public IActionResult OnPostPlayerDetailsDisplay()
        {
            playD = con.PickedPlayer(PlayerDetailsId)?.FirstOrDefault();
            return Page();
        }

        public IActionResult OnPostPlayerDetailsDelete(int ID)
        {
            con.PlayerDetailsDelete(ID);
            playD = new Players();
            playerOptions = con.playerlist();
            return Page();
        }
    }
}
