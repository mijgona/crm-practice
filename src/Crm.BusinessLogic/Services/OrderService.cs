using Crm.DataAccess;

namespace Crm.BusinessLogic;

public sealed class OrderService : IOrderService
{
    private readonly List<Order> _orders;

    public OrderService()
    {
        _orders = new();
    }

    public Order CreateOrder(
        long id,
        long clientId,
        string description,
        float price,
        DateTime createdAt,
        DeliveryType deliveryType,
        string Address,
        OrderState orderState
    )
    {
        Order newOrder = new()
        {
            Id = id,
            ClientId = clientId,
            Description = description,
            Price = price,
            CreatedAt = createdAt,
            DeliveryType = deliveryType,
            Address = Address,
            OrderState = orderState
        };

        _orders.Add(newOrder);

        return newOrder;
    }
    
    public bool RemoveOrderById(long id)
    {
        if (id  < 0 )
            throw new ArgumentNullException(nameof(id));
        
        foreach(Order item in _orders)
        {
            if (item.Id.Equals(id))
            {
                _orders.Remove(item);
                return true;
            }
        }
        
        return false;
    }    
    
    public bool ChangeOrderStatusById(long id, OrderState state)
    {
        if (id  < 0 )
            throw new ArgumentNullException(nameof(id));
        
        foreach(Order item in _orders)
        {
            if (item.Id.Equals(id))
            {
                item.OrderState = state;
                return true;
            }
        }
        
        return false;
    }
    
    public Order? GetOrderById(long id)
    {
        if (id  < 0 )
            throw new ArgumentNullException(nameof(id));
        
        foreach(Order item in _orders)
        {
            if (item.Id.Equals(id))
            {
                return item;
            }
        }
        
        return null;
    }    
    
    public int GetOrderCount()
    {
        return _orders.Count;
    }
    
    
    public int GetOrdersByStatus(OrderState state)
    {
        var count = 0;
        foreach(Order item in _orders)
        {
            if (item.OrderState.Equals(state))
            {
                count++;
            }
        }
        
        return count;
    }
}