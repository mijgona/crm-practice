namespace Crm.DataAccess;

public class Order
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public string Address { get; set; }
    public OrderState OrderState { get; set; }
}