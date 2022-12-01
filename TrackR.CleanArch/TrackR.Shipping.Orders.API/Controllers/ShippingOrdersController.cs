namespace TrackR.Shipping.Orders.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TrackR.Shipping.Orders.Application.InputModels;
    using TrackR.Shipping.Orders.Application.Services;

    [ApiController]
    [Route("api/shipping-orders")]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly IShippingOrderService _service;
        public ShippingOrdersController(IShippingOrderService service)
        {
            _service = service;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var shippingorder = await _service.GetByCode(code);
            if (shippingorder == null)
                return NotFound();

            return Ok(shippingorder);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderInputModel model)
        {
            var code = await _service.Add(model);
            return CreatedAtAction(
                nameof(GetByCode),
                new { code },
                model
            );
        }
    }
}
