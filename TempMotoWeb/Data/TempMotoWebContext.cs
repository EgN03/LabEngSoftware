using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TempMotoWeb.Models;

namespace TempMotoWeb.Data
{
    public class TempMotoWebContext : DbContext
    {
        public TempMotoWebContext (DbContextOptions<TempMotoWebContext> options)
            : base(options)
        {
        }

        public DbSet<TempMotoWeb.Models.Medicao> Medicao { get; set; } = default!;
    }
}
