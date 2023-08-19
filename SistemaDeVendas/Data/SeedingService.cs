using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeVendas.Models;
using SistemaDeVendas.Models.Enums;

namespace SistemaDeVendas.Data
{
    public class SeedingService
    {
        private SistemaDeVendasContext _context;

        public SeedingService(SistemaDeVendasContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //O Banco de dados já foi populado.
            }
            Department d1 = new Department(1, "Computer");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", 1000.0, new DateTime(1998, 4, 21), d1);
            Seller s2 = new Seller(2, "Mari Green", "maria@gmail.com", 2000.0, new DateTime(1979, 4, 21), d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", 1500.0, new DateTime(1988, 4, 21), d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", 1200.0, new DateTime(1993, 4, 21), d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", 2200.0, new DateTime(2000, 4, 21), d3);
            Seller s6 = new Seller(6, "Alex Pink", "alexpink@gmail.com", 3100.0, new DateTime(1997, 4, 21), d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 9, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 9, 27), 1100.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 10, 05), 21000.0, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 10, 05), 9000.0, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 10, 12), 9500.0, SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 10, 15), 11500.0, SaleStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 10, 17), 2000.0, SaleStatus.Billed, s1);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 10, 19), 36000.0, SaleStatus.Billed, s2);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 10, 21), 25000.0, SaleStatus.Billed, s3);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 10, 21), 1000.0, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            _context.SaveChanges();
        }
    }
}
