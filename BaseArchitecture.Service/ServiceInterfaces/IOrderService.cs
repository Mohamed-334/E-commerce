using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Service.Shared.Interface;

namespace EcommerceProject.Service.ServiceInterfaces
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<string> ChangeProductStockForOrder(int OrderId, int newStatusCode);
    }
}
