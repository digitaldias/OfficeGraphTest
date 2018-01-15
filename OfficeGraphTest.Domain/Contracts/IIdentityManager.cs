namespace OfficeGraphTest.Domain.Contracts
{
    public interface IIdentityManager
    {
        string BearerToken { get; }

        bool SignIn();
    }
}