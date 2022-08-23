using BethanysPieShop.Models.Entities;

namespace BethanysPieShop.Models.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
