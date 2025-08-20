using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Orders.Commands.RequestModels
{
    public class SoftDeleteAndActivateOrderCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
