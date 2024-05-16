using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DausanBigStore.Pages
{
    public class AboutModel : PageModel
    {
        public bool IsAuthenticated { get; private set; }
        public IActionResult OnGet()
        {
            IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            return Page();
        }
    }
}
