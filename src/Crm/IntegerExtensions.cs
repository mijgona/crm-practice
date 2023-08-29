using Crm.DataAccess;

public static class IntegerExtensions
{
    public static bool TryParse(this int genderIndex, out Gender gender)
    {
        switch(genderIndex)
        {
            case 0:
                gender = Gender.Male;
                return true;
            case 1:
                gender = Gender.Female;
                return true;
            default:
                gender = default;
                return false;
        }
    }
    
    public static bool TryParse(this int deliveryTypeIndex, out DeliveryType delivery)
    {
        switch(deliveryTypeIndex)
        {
            case 0:
                delivery = DeliveryType.Express;
                return true;
            case 1:
                delivery = DeliveryType.Standard;
                return true;
            case 2:
                delivery = DeliveryType.Free;
                return true;
            default:
                delivery = default;
                return false;
        }
    }
    
    public static bool TryParse(this int orderStateIndex, out OrderState order)
    {
        switch(orderStateIndex)
        {
            case 1:
                order = OrderState.Approved;
                return true;
            case 2:
                order = OrderState.Cancelled;
                return true;
            case 0:
                order = OrderState.Pending;
                return true;
            default:
                order = default;
                return false;
        }
    }
}