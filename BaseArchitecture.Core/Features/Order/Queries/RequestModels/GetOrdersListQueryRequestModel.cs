using BaseArchitecture.Core.Features.Orders.Dto;
using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Orders.Queries.RequestModels
{
    public class GetOrdersListQueryRequestModel : IRequest<Response<List<OrderFullDataDto>>>
    {
    }
}
