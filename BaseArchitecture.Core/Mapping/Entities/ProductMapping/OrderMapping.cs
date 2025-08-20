using AutoMapper;

namespace BaseArchitecture.Core.Mapping.ProductMapping
{
    public partial class ProductMapping : Profile
    {
        #region Constructor
        public ProductMapping()
        {
            MapFromAddProductCommandRequestModelToProductEntity();
            MapFromUpdateProductCommandRequestModelToProductEntity();
            MappingFromProductToProductFullDataDto();
        }
        #endregion

    }
}
