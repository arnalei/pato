using Dapper;
using DausanCoreLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
#nullable disable

namespace DausanBigStore.Pages
{
    public class CreateAccountModel : PageModel
    {
        private readonly IConfiguration config;


        [BindProperty]
        public Accounts createacc { get; set; }
       
        public CreateAccountModel(IConfiguration CONFIG)
        {
            config= CONFIG;
        }
        public IActionResult OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using var sqlcon = new SqlConnection(config.GetConnectionString("DUA"));
            var storeProcedure = "[dbo].[Create]";
            var parameter = new DynamicParameters();
            parameter.Add("@username", createacc.username, DbType.String, ParameterDirection.Input);
            parameter.Add("@password", createacc.password, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(storeProcedure, parameter, commandType: CommandType.StoredProcedure);
            return RedirectToPage("/Index");
        }
    }
}
