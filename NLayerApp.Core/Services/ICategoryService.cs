using NLayerApp.Core.DTOs;
using NLayerApp.Core.Entites;
using NLayerApp.Core.ResponseDto;

namespace NLayerApp.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
