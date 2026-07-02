namespace BMH.Core.Services;

public interface INameProvider
{
    (string FirstName, string LastName) CreateName();
}
