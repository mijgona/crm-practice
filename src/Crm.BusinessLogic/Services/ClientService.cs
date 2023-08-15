using Crm.DataAccess;

namespace Crm.BusinessLogic;

public sealed class ClientService : IClientService
{
    private readonly List<Client> _clients;

    public ClientService()
    {
        _clients = new();
    }

    public Client CreateClient(
        string firstName,
        string lastName,
        string middleName,
        short age,
        string passportNumber,
        Gender gender
    )
    {
        Client newClient = new()
        {
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Age = age,
            PassportNumber = passportNumber,
            Gender = gender
        };

        _clients.Add(newClient);
        
        return newClient;
    }

    public bool RemoveClient(string firstName, string lastName)
    {
        foreach(Client item in _clients)
        {
            if (item.FirstName.Equals(firstName) && item.LastName.Equals(lastName))
            {
                _clients.Remove(item);
                return true;
            }
        }
        
        return false;
    }

    public Client? GetClient(string firstName, string lastName)
    {
        if (firstName is not { Length: > 0 })
            throw new ArgumentNullException(nameof(firstName));

        if (lastName is not { Length: > 0 })
            throw new ArgumentNullException(nameof(lastName));
            
        foreach(Client client in _clients)
        {
            if (client.FirstName.Equals(firstName) && client.LastName.Equals(lastName))
                return client;
        }

        return null;
    }
}