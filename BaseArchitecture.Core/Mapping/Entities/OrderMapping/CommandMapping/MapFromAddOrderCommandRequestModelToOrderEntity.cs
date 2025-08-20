using BaseArchitecture.Core.Features.Orders.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.OrderMapping
{
    public partial class OrderMapping
    {
        #region Methods
        public void MapFromAddOrderCommandRequestModelToOrderEntity()
        {
            CreateMap<AddOrderCommandRequestModel, Order>()
            .AfterMap<MetaMappingDataBasedOnDestination<AddOrderCommandRequestModel, Order>>();
            #endregion
        }
    }
}
