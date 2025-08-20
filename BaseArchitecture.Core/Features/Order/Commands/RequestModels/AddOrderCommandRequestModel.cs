using BaseArchitecture.Core.Shared.Models;
using MediatR;
using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace BaseArchitecture.Core.Features.Orders.Commands.RequestModels
{
    public class AddOrderCommandRequestModel : IRequest<Response<string>>
    {
        public string Status { get; set; } = OrderStatus.Pending.ToString();
        public int StatusCode { get; set; } = (int)OrderStatus.Pending;
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
