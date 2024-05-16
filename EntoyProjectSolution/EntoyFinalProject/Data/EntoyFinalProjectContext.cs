using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntoyFinalProject.Models;

namespace EntoyFinalProject.Data
{
    public class EntoyFinalProjectContext : DbContext
    {
        public EntoyFinalProjectContext (DbContextOptions<EntoyFinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<EntoyFinalProject.Models.User> User { get; set; } = default!;
    }
}
