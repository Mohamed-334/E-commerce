using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using EcommerceProject.Infrastructure.RepositoryInterfaces;
using EcommerceProject.Service.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace EcommerceProject.Service.Service
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        #region Felds
        private readonly IOrderRepository _orderRepository;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        #endregion

        #region Constructor
        public OrderService(IOrderRepository orderRepository, IStringLocalizer<AppLocalization> stringLocalizer) : base(orderRepository, stringLocalizer)
        {
            _orderRepository = orderRepository;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Methods
        public async Task<string> ChangeProductStockForOrder(int OrderId, int newStatusCode)
        {
            var order = await _orderRepository
                .GetTableAsTracking()
                .Where(o => o.Id == OrderId)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync();

            if (order == null)
                return _stringLocalizer[AppLocalizationKeys.OrderNotFound];
            var OrderDetails = order.OrderDetails
                .ToList();

            if (newStatusCode == (int)OrderStatus.Delivered)
            {
                foreach (var OrderDetail in OrderDetails)
                {
                    OrderDetail.Product.Stock -= OrderDetail.Quantity;
                }
            }
            else if (newStatusCode == (int)OrderStatus.Cancelled)
            {
                foreach (var OrderDetail in OrderDetails)
                {
                    OrderDetail.Product.Stock += OrderDetail.Quantity;
                }
            }
            try
            {
                await _orderRepository.SaveChangesAsync();
                return _stringLocalizer[AppLocalizationKeys.Success];
            }
            catch (Exception ex)
            {
                return _stringLocalizer[AppLocalizationKeys.UpdateFailed];
            }
        }
        #endregion
    }
}
