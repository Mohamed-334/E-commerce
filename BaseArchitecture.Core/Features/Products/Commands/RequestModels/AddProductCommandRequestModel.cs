using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Products.Commands.RequestModels
{
    public class AddProductCommandRequestModel : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string? NameLocalization { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
