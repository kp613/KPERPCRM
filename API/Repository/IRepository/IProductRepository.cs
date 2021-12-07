using API.DTOs.ProductsDtos;
using API.Helpers.Pagination;
using API.Helpers.Params;
using API.Models.ApplicationModels.Products;
using System.Threading.Tasks;


namespace API.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<PagedList<ProductDto>> GetProductsAsync(ProductParams productrParams);
        //Task<ICollection<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByCasNoAsync(string casno);

        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);

        bool ProductExists(string casno);

        Task<bool> SaveAllAsync();

        //Task<IReadOnlyList<Product>> GetProductsAsync();
        //Task<IReadOnlyList<ProductsGroupFirst>> GetProductTypeMainsAsync();
        //Task<IReadOnlyList<ProductsGroupSecond>> GetProductTypesAsync();
        //Task<IReadOnlyList<ProductsListInGroupThird>> GetProductListInTypesAsync();

        //Task<ICollection<ProductsGroupFirst>> GetGroupFirstsAsync();
    }
}
