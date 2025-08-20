using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using EcommerceProject.Infrastructure.RepositoryInterfaces;
using EcommerceProject.Service.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace EcommerceProject.Service.Service
{
    public class OrderDetailsService : BaseService<OrderDetails>, IOrderDetailsService
    {
        #region Felds
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        #endregion

        #region Constructor
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IStringLocalizer<AppLocalization> stringLocalizer) : base(orderDetailsRepository, stringLocalizer)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Methods
        public async Task<List<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            var orderDetails = await _orderDetailsRepository.GetTableNoTracking().Where(c => c.OrderId == orderId).ToListAsync();
            return orderDetails;
        }
        #endregion
    }
}
