using BaseArchitecture.Core.Features.Products.Dto;
using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Products.Queries.RequestModels
{
    public class GetProductsListQueryRequestModel : IRequest<Response<List<ProductFullDataDto>>>
    {
    }
}
