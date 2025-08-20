using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;
using EcommerceProject.Core.Features.Order.Commands.RequestModels;

namespace BaseArchitecture.Core.Mapping.OrderMapping
{
    public partial class OrderMapping
    {
        #region Methods
        public void MapFromUpdateOrderStatusCommandRequestModelToOrderEntity()
        {
            CreateMap<UpdateOrderStatusCommandRequestModel, Order>()
            .AfterMap<MetaMappingDataBasedOnDestination<UpdateOrderStatusCommandRequestModel, Order>>();
        }
        #endregion
    }
}
