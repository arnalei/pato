using AJJK_CL;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
#nullable disable

namespace AJJK_Planner.Pages
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

            using var sqlcon = new SqlConnection(_config.GetConnectionString("AJJK_DB"));
            var storeProcedure = "[dbo].[Create]";
            var parameter = new DynamicParameters();
            parameter.Add("@username", createacc.username, DbType.String, ParameterDirection.Input);
            parameter.Add("@password", createacc.password, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(storeProcedure, parameter, commandType: CommandType.StoredProcedure);
            return RedirectToPage("/Login");
        }
    }
}
