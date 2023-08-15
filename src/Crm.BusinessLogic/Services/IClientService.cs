using Crm.DataAccess;

namespace Crm.BusinessLogic;

public interface IClientService
{
    public Client CreateClient(
        string firstName,
        string lastName,
        string middleName,
        short age,
        string passportNumber,
        Gender gender
    );

    public Client? GetClient(string firstName, string lastName);
    public bool RemoveClient(string firstName, string lastName);
}
