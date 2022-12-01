using TrackR.Shipping.Orders.Application.InputModels;
using TrackR.Shipping.Orders.Application.ViewModels;

namespace TrackR.Shipping.Orders.Application.Services
{
    public interface IShippingOrderService
    {
        Task<string> Add(AddShippingOrderInputModel model);
        Task<ShippingOrderViewModel> GetByCode(string trackingCode);
    }
}
