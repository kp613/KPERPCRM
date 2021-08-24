using API.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        //Task<IReadOnlyList<Product>> GetProductsAsync();
        //Task<IReadOnlyList<ProductsGroupFirst>> GetProductTypeMainsAsync();
        //Task<IReadOnlyList<ProductsGroupSecond>> GetProductTypesAsync();
        //Task<IReadOnlyList<ProductsListInGroupThird>> GetProductListInTypesAsync();

        Task<IEnumerable<ProductsGroupFirst>> GetGroupFirstsAsync();
    }
}
