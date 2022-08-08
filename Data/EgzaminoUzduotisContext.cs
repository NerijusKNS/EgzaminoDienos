using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EgzaminoUzduotis.Models;

namespace EgzaminoUzduotis.Data
{
    public class EgzaminoUzduotisContext : DbContext
    {
        public EgzaminoUzduotisContext (DbContextOptions<EgzaminoUzduotisContext> options)
            : base(options)
        {
        }

        public DbSet<EgzaminoUzduotis.Models.FilmuPortalas> FilmuPortalas { get; set; } = default!;
    }
}
