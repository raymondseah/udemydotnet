using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    // this interface will be implemented in the infrastructure class ProductRepository
    public interface IProductRepository
    {
        // add signature of the methods
        Task<Product> GetProductByIdAsync(int id);

        // only for reading only list
        Task<IReadOnlyList<Product>> GetProductsAsync();


        // add more
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}