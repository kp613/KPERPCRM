using API.Data;
using API.Models.ProductModels;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductsGroupThirdProducts)
                .ToListAsync();
        }

        async Task<IEnumerable<ProductsGroupFirst>> IProductRepository.GetGroupFirstsAsync()
        {
            return await _context.ProductsGroupFirst
                .Include(g => g.ProductsGroupSeconds)
                .ThenInclude(gs => gs.ProductsGroupThirds)
                .AsSingleQuery()
                .AsNoTracking()
                .ToListAsync();
        }



        //async Task<IReadOnlyList<ProductsGroupFirst>> IProductRepository.GetProductTypeMainsAsync()
        //{
        //    return await _context.ProductsGroupFirst
        //        .Include(p => p.ProductsGroupSeconds)
        //        .ToListAsync();
        //}


        //async Task<IReadOnlyList<ProductsGroupSecond>> IProductRepository.GetProductTypesAsync()
        //{
        //    return await _context.ProductsGroupSecond
        //        .Include(p=>p.ProductsGroupThirds)
        //        .ToListAsync();
        //}

        //async Task<IReadOnlyList<ProductsGroupSecond>> IProductRepository.GetProductListInTypesAsync()
        //{
        //    return await _context.ProductsGroupSecond
        //        //.Include(p=>p.ProductsGroupThirds)
        //        //.Include(p=>p.Products)
        //        .ToListAsync();
        //}

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
