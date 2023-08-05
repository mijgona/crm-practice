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
}