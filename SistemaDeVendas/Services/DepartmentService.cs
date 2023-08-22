using SistemaDeVendas.Data;
using SistemaDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Services
{
    public class DepartmentService
    {
        private readonly SistemaDeVendasContext _context;

        public DepartmentService(SistemaDeVendasContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
