using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAPDOLLS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace GAPDOLLS.Data
{
    public class GAPDOLLSContext : IdentityDbContext
    {

        public GAPDOLLSContext (DbContextOptions<GAPDOLLSContext> options)
            : base(options)
        {
           

        }

        public DbSet<GAPDOLLS.Models.Dolls> Dolls { get; set; } = default!;
        public DbSet<GAPDOLLS.Models.Customer> Customer { get; set; }

    }
}
