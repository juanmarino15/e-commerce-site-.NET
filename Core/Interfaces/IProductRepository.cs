using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //async methods. T
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}