using Crm.DataAccess;

namespace Crm.BusinessLogic;

public interface IOrderService
{
    public Order CreateOrder(
        long id,
        long clientId,
        string description,
        float price,
        DateTime createdAt,
        DeliveryType deliveryType,
        string address,
        OrderState orderState
    );

    public Order? GetOrderById(long id);
    public bool RemoveOrderById(long id);
    public bool ChangeOrderStatusById(long id, OrderState state);
    public int GetOrderCount();
    public int GetOrdersByStatus(OrderState state);
}