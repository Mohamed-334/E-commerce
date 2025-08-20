using BaseArchitecture.Core.Features.Products.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.ProductMapping
{
    public partial class ProductMapping
    {
        #region Methods
        public void MapFromAddProductCommandRequestModelToProductEntity()
        {
            CreateMap<AddProductCommandRequestModel, Product>()
            .AfterMap<MetaMappingDataBasedOnDestination<AddProductCommandRequestModel, Product>>();
            #endregion
        }
    }
}
