namespace TrackR.Shipping.Orders.Application.Services
{
    using TrackR.Shipping.Orders.Application.ViewModels;
    using TrackR.Shipping.Orders.Core.Entities;
    using TrackR.Shipping.Orders.Core.Repositories;

    public class ShippingServiceService : IShippingServiceService
    {
        private readonly IShippingServiceRepository _shippingServiceRepository;
        public ShippingServiceService(IShippingServiceRepository shippingServiceRepository)
        {
            _shippingServiceRepository = shippingServiceRepository;
        }

        public async Task<List<ShippingServiceViewModel>> GetAll()
        {
            var shippingServices = await _shippingServiceRepository.GetAllAsync();
            return
                shippingServices
                .Select(s => new ShippingServiceViewModel(s.Id, s.Title, s.PricePerKg, s.FixedPrice))
                .ToList();
        }
    }
}
