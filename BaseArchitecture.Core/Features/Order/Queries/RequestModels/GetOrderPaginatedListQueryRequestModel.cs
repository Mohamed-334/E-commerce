using BaseArchitecture.Core.Features.Orders.Dto;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;

namespace BaseArchitecture.Core.Features.Orders.Queries.RequestModels
{
    public class GetOrderPaginatedListQueryRequestModel : IRequest<Response<PaginatedList<OrderFullDataDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
