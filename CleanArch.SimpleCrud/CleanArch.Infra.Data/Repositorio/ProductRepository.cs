using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositorio
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChangesAsync();
        }

        public async Task<Product> GetById(int? Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
            _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
               
        }
    }
}
