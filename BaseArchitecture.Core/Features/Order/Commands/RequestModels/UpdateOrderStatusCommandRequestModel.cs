using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace EcommerceProject.Core.Features.Order.Commands.RequestModels
{
    public class UpdateOrderStatusCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int StatusCode { get; set; }
    }
}
