using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Products.Commands.RequestModels
{
    public class SoftDeleteAndActivateProductCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
