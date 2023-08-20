﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeVendas.Data;
using SistemaDeVendas.Models;

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
    }
}