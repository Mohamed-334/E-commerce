using BaseArchitecture.Core.Features.Products.Dto;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.ProductMapping
{
    public partial class ProductMapping
    {
        #region Methods
        public void MappingFromProductToProductFullDataDto()
        {
            CreateMap<Product, ProductFullDataDto>()
                .AfterMap<MetaMappingDataBasedOnSource<Product, ProductFullDataDto>>();
        }
        #endregion
    }

}
