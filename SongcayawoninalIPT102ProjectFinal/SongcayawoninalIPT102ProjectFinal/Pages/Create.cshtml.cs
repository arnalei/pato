using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SongcayawoninalIPT102ProjectFinal.Classes;
using System.Data;
#nullable disable

namespace SongcayawoninalIPT102ProjectFinal.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _config;

        [BindProperty]
        public Accounts createacc { get; set; }

        public CreateModel(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using var sqlcon = new SqlConnection(_config.GetConnectionString("SW"));
            var storeProcedure = "[dbo].[Create]";
            var parameter = new DynamicParameters();
            parameter.Add("@username", createacc.username, DbType.String, ParameterDirection.Input);
            parameter.Add("@password", createacc.password, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(storeProcedure, parameter, commandType: CommandType.StoredProcedure);
            return RedirectToPage("/Index");
        }
    }
}
