using BaseArchitecture.Core.Features.Products.Commands.RequestModels;
using BaseArchitecture.Core.Features.Products.Queries.RequestModels;
using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class ProductController : BaseControllerApp
    {
        [HttpGet(Router.ProductRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetProductByIdQueryRequestModel()
            {
                Id = id
            });
            return Result(response);
        }
        [HttpGet(Router.ProductRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetProductsListQueryRequestModel());
            return Result(response);
        }
        [HttpPost(Router.ProductRouting.GetPaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromBody] GetProductPaginatedListQueryRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.ProductRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddProductCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.ProductRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpDelete(Router.ProductRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteProductCommandRequestModel
            {
                Id = id
            });
            return Result(response);
        }
        [HttpGet(Router.ProductRouting.SoftDeleteAndActivate)]
        public async Task<IActionResult> SoftDeleteAndActivate([FromRoute] int id)
        {
            var response = await _mediator.Send(new SoftDeleteAndActivateProductCommandRequestQuery
            {
                Id = id
            });
            return Result(response);
        }
    }
}
