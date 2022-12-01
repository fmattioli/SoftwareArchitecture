using TrackR.Shipping.Orders.Core.Entities;

namespace TrackR.Shipping.Orders.Core.Repositories
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetByCodeAsync(string code);
        Task AddAsync(ShippingOrder shippingOrder);
    }
}