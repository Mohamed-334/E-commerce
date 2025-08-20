using AutoMapper;

namespace BaseArchitecture.Core.Mapping.OrderMapping
{
    public partial class OrderMapping : Profile
    {
        #region Constructor
        public OrderMapping()
        {
            MapFromAddOrderCommandRequestModelToOrderEntity();
            MapFromUpdateOrderCommandRequestModelToOrderEntity();
            MappingFromOrderToOrderFullDataDto();
            MapFromUpdateOrderStatusCommandRequestModelToOrderEntity();
        }
        #endregion

    }
}
