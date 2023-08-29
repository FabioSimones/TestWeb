using SistemaDeVendas.Data;
using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeVendas.Services
{
    public class DepartmentService
    {
        private readonly SistemaDeVendasContext _context;

        public DepartmentService(SistemaDeVendasContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
