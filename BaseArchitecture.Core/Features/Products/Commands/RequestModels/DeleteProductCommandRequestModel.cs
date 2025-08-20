using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Products.Commands.RequestModels
{
    public class DeleteProductCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
