using BaseArchitecture.Core.Features.Products.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.ProductMapping
{
    public partial class ProductMapping
    {
        #region Methods
        public void MapFromUpdateProductCommandRequestModelToProductEntity()
        {
            CreateMap<UpdateProductCommandRequestModel, Product>()
            .AfterMap<MetaMappingDataBasedOnDestination<UpdateProductCommandRequestModel, Product>>();
        }
        #endregion
    }
}
