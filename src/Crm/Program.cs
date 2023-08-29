using Crm.DataAccess;
using Crm.BusinessLogic;
using System.Collections;

IClientService clientService = new ClientService();
IOrderService orderService = new OrderService();

orderService.CreateOrder(1, 1,"Sugar", 20,
 DateTime.Now,DeliveryType.Express, "Academy", OrderState.Pending);
Order order = orderService.GetOrderById(1);
Console.WriteLine(order.Address);

clientService.CreateClient(firstName: "Faridun", "Berdiev", "", 10, "", Gender.Male);
bool result = clientService.RemoveClient("Faridun", "Berdiev");
Console.WriteLine(result);

CreateClient();


void CreateClient()
{
    string firstName = Console.ReadLine();
    string lastName = Console.ReadLine();
    string middleName = Console.ReadLine();
    string ageInputStr = Console.ReadLine();
    string passportNumber = Console.ReadLine();
    string genderInputStr = Console.ReadLine();

    if(!ValidateClient(
           firstName,
           lastName,
           middleName,
           ageInputStr,
           passportNumber,
           genderInputStr
       )) return;

    Gender gender = (Gender)int.Parse(genderInputStr);
    short age = short.Parse(ageInputStr);

    Client newClient = clientService.CreateClient(
        firstName,
        lastName,
        middleName,
        age,
        passportNumber,
        gender
    );
    Console.WriteLine(newClient);

    Console.WriteLine("Client Name: {0}",
        string.Join(' ', newClient.FirstName, newClient.MiddleName, newClient.LastName));

    Console.WriteLine("Client Age: {0}", newClient.Age);
    Console.WriteLine("Client Passport Number: {0}", newClient.PassportNumber);
}

void CreateOrder()
{
    string idStr = Console.ReadLine();
    string clientIdStr = Console.ReadLine();
    string description = Console.ReadLine();
    string priceStr = Console.ReadLine();
    string deliveryTypeStr= Console.ReadLine();
    string address= Console.ReadLine();
    string orderStateStr = Console.ReadLine();
    
    if(!ValidateOrder(
            idStr,
            clientIdStr,
            description,
            priceStr,
            deliveryTypeStr,
            address, orderStateStr
       )) return;
   
    DeliveryType deliveryType = (DeliveryType)int.Parse(deliveryTypeStr);
    OrderState orderState = (OrderState)int.Parse(orderStateStr);
    
    long id = long.Parse(idStr);
    long clientId = long.Parse(clientIdStr);
    short price = short.Parse(priceStr);
    var createdAt = DateTime.Now;
    

    Order newOrder = orderService.CreateOrder(
        id,
        clientId,
        description,
        price,
        createdAt, 
        deliveryType, 
        address,
        orderState
    );
    Console.WriteLine(newOrder);

    Console.WriteLine("New Order id: {0}",newOrder.Id);

    Console.WriteLine("Order Delivery Type: {0}", newOrder.DeliveryType);
    Console.WriteLine("Order Address: {0}", newOrder.Address);
}

bool ValidateClient(
    string firstName,
    string lastName,
    string middleName,
    string ageStr,
    string passportNumber,
    string genderStr)
{
    List<string> errors = new();

    if (firstName is { Length: 0 })
        errors.Add("First Name field is required!");

    if (lastName is { Length: 0 })
        errors.Add("Last Name field is required!");

    if (middleName is { Length: 0 })
        errors.Add("Middle Name field is required!");

    bool isAgeCorrect = short.TryParse(ageStr, out short age);
    if (!isAgeCorrect)
        errors.Add("Please input correct value for age field!");

    if (passportNumber is { Length: 0 })
        errors.Add("Passport Number field is required!");

    bool isGenderCorrect = int.TryParse(genderStr, out int genderIndex);
    if (!isGenderCorrect)
        errors.Add("Please input correct value for gender field!");

    bool isEnumGenderCorrect = genderIndex.TryParse(out Gender gender);
    if (!isEnumGenderCorrect)
        errors.Add("Please input correct value for gender field (0 - Male, 1 - Female)!");

    if (errors is { Count: > 0 })
    {
        foreach (string errorMessage in errors)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
        }

        Console.ForegroundColor = ConsoleColor.White;
        return false;
    }

    return true;
}

bool ValidateOrder(
        string idStr,
        string clientIdStr,
        string description,
        string priceStr,
        string deliveryTypeStr,
        string address,
        string orderState)
    {
        List<string> errors = new();

        if (description is { Length: 0 })
            errors.Add("description field is required!");
        
        if (address is { Length: 0 })
            errors.Add("address field is required!");

        bool isIdCorrect = long.TryParse(idStr, out long id);
        if (!isIdCorrect)
            errors.Add("Please input correct value for id field!");

        bool isClinetIdCorrect = long.TryParse(clientIdStr, out long clientId);
        if (!isClinetIdCorrect)
            errors.Add("Please input correct value for clientId field!");

        bool isPriceCorrect = short.TryParse(priceStr, out short price);
        if (!isPriceCorrect)
            errors.Add("Please input correct value for price field!");

        bool isDeliveryTypeStrCorrect = int.TryParse(deliveryTypeStr, out int deliveryType);
        if (!isDeliveryTypeStrCorrect)
            errors.Add("Please input correct value for gender field!");

        bool isEnumDeliveryTypeCorrect = deliveryType.TryParse(out DeliveryType delivery);
        if (!isEnumDeliveryTypeCorrect)
            errors.Add("Please input correct value for gender field (0 - Express, 1 - Standard, 1 - Free)!");
        
        bool isOrderStateCorrect = int.TryParse(orderState, out int order);
        if (!isOrderStateCorrect)
            errors.Add("Please input correct value for gender field!");

        bool isEnumOrderCorrect = order.TryParse(out OrderState state);
        if (!isEnumOrderCorrect)
            errors.Add("Please input correct value for gender field (0 - Pending, 1 - Approved, 1 - Cancel)!");

        if (errors is { Count: > 0 })
        {
            foreach (string errorMessage in errors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
            }

            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        return true;
    }

