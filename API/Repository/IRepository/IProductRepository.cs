using API.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace API.Repository.IRepository
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);

        bool ProductExists(string casno);

        Task<ICollection<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByCasNoAsync(string casno);

        //Task<IReadOnlyList<Product>> GetProductsAsync();
        //Task<IReadOnlyList<ProductsGroupFirst>> GetProductTypeMainsAsync();
        //Task<IReadOnlyList<ProductsGroupSecond>> GetProductTypesAsync();
        //Task<IReadOnlyList<ProductsListInGroupThird>> GetProductListInTypesAsync();

        Task<ICollection<ProductsGroupFirst>> GetGroupFirstsAsync();

        Task<bool> SaveAllAsync();
    }
}
