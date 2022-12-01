namespace TrackR.Shipping.Orders.Infrastructure.Persistence.Repositories
{
    using MongoDB.Driver;
    using TrackR.Shipping.Orders.Core.Entities;
    using TrackR.Shipping.Orders.Core.Repositories;

    public class ShippingServiceRepository : IShippingServiceRepository
    {
        private readonly IMongoCollection<ShippingService> _collection;
        public ShippingServiceRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }
        public async Task<List<ShippingService>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }
    }
}
