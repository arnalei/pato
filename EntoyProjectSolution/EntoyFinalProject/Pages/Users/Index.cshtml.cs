using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntoyFinalProject.Data;
using EntoyFinalProject.Models;

namespace EntoyFinalProject.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly EntoyFinalProject.Data.EntoyFinalProjectContext _context;

        public IndexModel(EntoyFinalProject.Data.EntoyFinalProjectContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
