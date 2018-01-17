namespace OfficeGraphTest.Domain.Contracts
{
    public interface IIdentityManager
    {
        string BearerToken { get; }

        bool IsSignedIn { get; }

        bool SignIn(string resource);

        bool SignOut(string resource);
    }
}