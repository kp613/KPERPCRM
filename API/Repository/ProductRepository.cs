using API.Data;
using API.DTOs.ProductsDtos;
using API.Helpers;
using API.Models.ApplicationModels.Products;
using API.Repository.IRepository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<ICollection<Product>> GetProductsAsync()

        public async Task<PagedList<ProductDto>> GetProductsAsync(ProductParams productrParams)
        {
            //return await _context.Products

            //    .OrderByDescending(p=>p.UpdateDay)
            //    .ToListAsync();

            var query = _context.Products.AsQueryable();

            //query = query.Where(u => u.CasNo == productrParams.CasNo);

            query = productrParams.OrderBy switch
            {
                "updateDay" => query.OrderByDescending(u => u.UpdateDay),
                //"lastActive" => query.OrderBy(u => u.LastActive),
                _ => query.OrderByDescending(u => u.UpdateDay)
            };

            return await PagedList<ProductDto>.CreateAsync(query.ProjectTo<ProductDto>(_mapper
                .ConfigurationProvider).AsNoTracking(),
                    productrParams.PageNumber, productrParams.PageSize);
        }


        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> GetProductByCasNoAsync(string casno)
        {
            //return await _context.Products.FindAsync(casno);
            return await _context.Products.FirstOrDefaultAsync(c=>c.CasNo.Trim() == casno.Trim());
        }

        //async Task<ICollection<ProductsGroupFirst>> IProductRepository.GetGroupFirstsAsync()
        //{
        //    return await _context.ProductsGroupFirst
        //        .Include(g => g.ProductsGroupSeconds)
        //        .ThenInclude(gs => gs.ProductsGroupThirds)
        //        .AsSingleQuery()
        //        .AsNoTracking()
        //        .ToListAsync();
        //}



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
            //return await _context.SaveChangesAsync() > 0;
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public bool ProductExists(string casno)
        {
            bool value = _context.Products.Any(c => c.CasNo.Trim() == casno.Trim());
            return value;
        }


    }
}
