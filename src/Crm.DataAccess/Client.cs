namespace Crm.DataAccess;

public sealed class Client
{
    private string? _firstName;
    public long Id { get; set; }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public short Age { get; set; }
    public string PassportNumber { get; set; }
    public Gender Gender { get; set; }
}
