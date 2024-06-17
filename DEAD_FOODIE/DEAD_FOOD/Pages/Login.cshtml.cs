using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DEAD_CL;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
#nullable disable

namespace DEAD_FOOD.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration config;

        [BindProperty]
        public Accounts acc { get; set; }
        public bool IsAuthenticated { get; private set; }
        public LoginModel(IConfiguration _config)
        {
            config= _config;
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
                using var sqlcon = new SqlConnection(config.GetConnectionString("DEAD_DB"));
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

                    return RedirectToPage("/DEAD_Index");
                }
            }

            return Page();
        }
    }
}
