using TrackR.Shipping.Orders.Application.ViewModels;

namespace TrackR.Shipping.Orders.Application.Services
{
    public interface IShippingServiceService
    {
        Task<List<ShippingServiceViewModel>> GetAll();
    }
}
