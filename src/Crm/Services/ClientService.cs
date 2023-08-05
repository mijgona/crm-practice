using Crm.DataAccess;

namespace Crm.Services;

public sealed class ClientService : ClientBase
{
    public Client CreateClient(
        string firstName,
        string lastName,
        string middleName,
        short age,
        string passportNumber,
        Gender gender
    )
    {
        // TODO: Validate input parameters.
        return new()
        {
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Age = age,
            PassportNumber = passportNumber,
            Gender = gender
        };
    }
}