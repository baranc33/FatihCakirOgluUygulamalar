using NLayerApp.Core.DTOs;
using NLayerApp.Core.Entites;
using NLayerApp.Core.ResponseDto;

namespace NLayerApp.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();

    }
}
