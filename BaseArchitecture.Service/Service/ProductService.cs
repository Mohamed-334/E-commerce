using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using EcommerceProject.Infrastructure.RepositoryInterfaces;
using EcommerceProject.Service.ServiceInterfaces;
using Microsoft.Extensions.Localization;

namespace EcommerceProject.Service.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        #region Felds
        private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        #endregion

        #region Constructor
        public ProductService(IProductRepository productRepository, IStringLocalizer<AppLocalization> stringLocalizer) : base(productRepository, stringLocalizer)
        {
            _productRepository = productRepository;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Methods
        #endregion
    }
}
