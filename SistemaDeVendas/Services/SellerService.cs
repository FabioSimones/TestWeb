using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeVendas.Data;
using SistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.Services.Exceptions;

namespace SistemaDeVendas.Services
{
    public class SellerService 
    {
        private readonly SistemaDeVendasContext _context;

        public SellerService (SistemaDeVendasContext context)
        {
            _context = context;
        }

        public List<Seller> Findall()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById (int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault( obj => obj.Id == id);
        }

        public void Remove (int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
