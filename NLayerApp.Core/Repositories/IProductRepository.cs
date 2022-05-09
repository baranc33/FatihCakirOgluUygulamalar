using NLayerApp.Core.Entites;

namespace NLayerApp.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWitCategory();
    }
}
