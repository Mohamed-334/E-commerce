using BaseArchitecture.Core.Features.Orders.Dto;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.OrderMapping
{
    public partial class OrderMapping
    {
        #region Methods
        public void MappingFromOrderToOrderFullDataDto()
        {
            CreateMap<Order, OrderFullDataDto>()
                .AfterMap<MetaMappingDataBasedOnSource<Order, OrderFullDataDto>>();
        }
        #endregion
    }

}
