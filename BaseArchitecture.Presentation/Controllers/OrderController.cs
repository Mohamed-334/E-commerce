using BaseArchitecture.Core.Features.Orders.Commands.RequestModels;
using BaseArchitecture.Core.Features.Orders.Queries.RequestModels;
using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using EcommerceProject.Core.Features.Order.Commands.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class OrderController : BaseControllerApp
    {
        [HttpGet(Router.OrderRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetOrderByIdQueryRequestModel()
            {
                Id = id
            });
            return Result(response);
        }
        [HttpGet(Router.OrderRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetOrdersListQueryRequestModel());
            return Result(response);
        }
        [HttpPost(Router.OrderRouting.GetPaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromBody] GetOrderPaginatedListQueryRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.OrderRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddOrderCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.OrderRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.OrderRouting.UpdateOrderStatus)]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpDelete(Router.OrderRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteOrderCommandRequestModel
            {
                Id = id
            });
            return Result(response);
        }
        [HttpGet(Router.OrderRouting.SoftDeleteAndActivate)]
        public async Task<IActionResult> SoftDeleteAndActivate([FromRoute] int id)
        {
            var response = await _mediator.Send(new SoftDeleteAndActivateOrderCommandRequestQuery
            {
                Id = id
            });
            return Result(response);
        }
    }
}
