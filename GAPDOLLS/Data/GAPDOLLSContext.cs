using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAPDOLLS.Models;

namespace GAPDOLLS.Data
{
    public class GAPDOLLSContext : DbContext
    {
        public GAPDOLLSContext (DbContextOptions<GAPDOLLSContext> options)
            : base(options)
        {
        }

        public DbSet<GAPDOLLS.Models.Dolls> Dolls { get; set; } = default!;
    }
}
