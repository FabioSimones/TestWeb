using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Data
{
    public class SistemaDeVendasContext : DbContext
    {
        public SistemaDeVendasContext (DbContextOptions<SistemaDeVendasContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaDeVendas.Models.Department> Department { get; set; }
    }
}
