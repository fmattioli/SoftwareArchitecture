namespace TrackR.Shipping.Orders.API.Controllers
{
    using KafkaFlow;
    using KafkaFlow.Producers;
    using Microsoft.AspNetCore.Mvc;
    using TrackR.Shipping.Orders.Application.InputModels;
    using TrackR.Shipping.Orders.Application.Services;

    [ApiController]
    [Route("api/shipping-orders")]
    public class ShippingOrdersController : Controller
    {
        private readonly IProducerAccessor commandProducer;
       
        private readonly IShippingOrderService _service;
        public ShippingOrdersController(IProducerAccessor commandProducer)
        {
            this.commandProducer = commandProducer;
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
            var producer = commandProducer.GetProducer("say-hello");
            await producer.ProduceAsync(
                   "sample-topic",
                   Guid.NewGuid().ToString(),
                   new HelloMessage { Text = "Hello!" });

            return Ok(model);
        }
    }
}
