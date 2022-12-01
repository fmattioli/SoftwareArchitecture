using TrackR.Shipping.Orders.Core.Entities;

namespace TrackR.Shipping.Orders.Core.Repositories
{
    public interface IShippingServiceRepository
    {
        Task<List<ShippingService>> GetAllAsync();
    }
}
