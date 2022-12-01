namespace TrackR.Shipping.Orders.Infrastructure.Persistence.Repositories
{
    using MongoDB.Driver;
    using TrackR.Shipping.Orders.Core.Entities;
    using TrackR.Shipping.Orders.Core.Repositories;

    public class ShippingOrderRepository : IShippingOrderRepository
    {
        private readonly IMongoCollection<ShippingOrder> _collection;

        public ShippingOrderRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingOrder>("shipping-orders");
        }

        public async Task AddAsync(ShippingOrder shippingOrder)
        {
            await _collection.InsertOneAsync(shippingOrder);
        }

        public async Task<ShippingOrder> GetByCodeAsync(string code)
        {
            return await _collection.Find(c => c.TrackingCode == code).SingleOrDefaultAsync();
        }
    }
}
