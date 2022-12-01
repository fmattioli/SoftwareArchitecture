namespace TrackR.Shipping.Orders.Application.Services
{
    using System.Text.Json;
    using TrackR.Shipping.Orders.Application.InputModels;
    using TrackR.Shipping.Orders.Application.ViewModels;
    using TrackR.Shipping.Orders.Core.Entities;
    using TrackR.Shipping.Orders.Core.Repositories;
    using TrackR.Shipping.Orders.Core.ValueObjects;

    public class ShippingOrderService : IShippingOrderService
    {
        private readonly IShippingOrderRepository _repository;
        public ShippingOrderService(IShippingOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Add(AddShippingOrderInputModel model)
        {
            var shippingOrder = model.ToEntity();
            var shippingServices = model
                .Services
                .Select(s => s.ToEntity())
                .ToList();

            shippingOrder.SetupServices(shippingServices);
            await _repository.AddAsync(shippingOrder);
            return shippingOrder.TrackingCode;
        }

        public async Task<ShippingOrderViewModel> GetByCode(string trackingCode)
        {
            var shippingOrder = await _repository.GetByCodeAsync(trackingCode);
            return ShippingOrderViewModel.FromEntity(shippingOrder);
        }
    }
}
