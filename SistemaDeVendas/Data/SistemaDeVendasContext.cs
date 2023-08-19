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

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
