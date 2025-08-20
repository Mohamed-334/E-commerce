using BaseArchitecture.Core.Features.Orders.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.OrderMapping
{
    public partial class OrderMapping
    {
        #region Methods
        public void MapFromUpdateOrderCommandRequestModelToOrderEntity()
        {
            CreateMap<UpdateOrderCommandRequestModel, Order>()
            .AfterMap<MetaMappingDataBasedOnDestination<UpdateOrderCommandRequestModel, Order>>();
        }
        #endregion
    }
}
