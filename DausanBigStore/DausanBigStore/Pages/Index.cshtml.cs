#nullable disable
using System.Security.Claims;
using Dapper;
using DausanCoreLib.Models;
using DausanCoreLib.Stores;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;


namespace DausanBigStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        [BindProperty]
        public Accounts acc { get; set; }
        public bool IsAuthenticated { get; private set; }
        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
           _config= config;
            _logger = logger;
          
        }
        public IActionResult OnGet()
        {
            IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            return Page();
        }
        public IActionResult OnPostLogin()
        {
            if (ModelState.IsValid)
            {
                using var sqlcon = new SqlConnection(_config.GetConnectionString("DUA"));
                var storeProcedure = "[dbo].[Login]";
                var parameter = new DynamicParameters();
                parameter.Add("@username", acc.username, DbType.String, ParameterDirection.Input);
                parameter.Add("@password", acc.password, DbType.String, ParameterDirection.Input);
               var user = sqlcon.QueryFirstOrDefault<Accounts>(storeProcedure, parameter);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.username),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToPage("/Dashboard");
                }
            }

            return Page();
        }
    }
}
