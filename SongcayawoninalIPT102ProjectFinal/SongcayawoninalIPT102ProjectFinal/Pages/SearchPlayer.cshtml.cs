using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SongcayawoninalIPT102ProjectFinal.Classes;
using Dapper;
#nullable disable

namespace SongcayawoninalIPT102ProjectFinal.Pages
{
    public class SearchPlayerModel : PageModel
    {
        public List<Players> AllLogs { get; set; }
        private readonly IConfiguration config;
        private readonly SqlConnection connection;

        [BindProperty]
        public Players plays { get; set; }

        public SearchPlayerModel(IConfiguration _config)
        {
            config = _config;
            connection = new SqlConnection(config.GetConnectionString("SW"));
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(plays.PlayerName))
            {
                var sqlStr = "[dbo].[SearchByName]";
                var param = new { PlayerName = plays.PlayerName };
                AllLogs = connection.Query<Players>(sqlStr, param).ToList();
                return Page();
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
