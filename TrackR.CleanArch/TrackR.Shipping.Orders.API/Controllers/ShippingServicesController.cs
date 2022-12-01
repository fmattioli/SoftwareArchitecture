using Microsoft.AspNetCore.Mvc;

using TrackR.Shipping.Orders.Application.Services;

namespace TrackR.Shipping.Orders.API.Controllers
{
    [ApiController]
    [Route("api/shipping-services")]
    public class ShippingServicesController : Controller
    {
        private readonly IShippingServiceService _service;
        public ShippingServicesController(IShippingServiceService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shippingServices = await _service.GetAll();
            return Ok(shippingServices);
        }
    }
}
