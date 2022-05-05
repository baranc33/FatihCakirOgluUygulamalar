using AutoMapper;
using NLayerApp.Core.Entites;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;

namespace NLayerApp.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        //public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        //{
        //    var products = await _productRepository.GetProductsWitCategory();

        //    var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
        //    return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);

        //}
    }


}
