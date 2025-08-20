using BaseArchitecture.Core.Features.Products.Dto;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;

namespace BaseArchitecture.Core.Features.Products.Queries.RequestModels
{
    public class GetProductPaginatedListQueryRequestModel : IRequest<Response<PaginatedList<ProductFullDataDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
