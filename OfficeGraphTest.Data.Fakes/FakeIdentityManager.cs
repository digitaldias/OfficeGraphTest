using OfficeGraphTest.Domain.Contracts;

namespace OfficeGraphTest.Data.Fakes
{
    public class FakeIdentityManager : IIdentityManager
    {
        public string BearerToken => "BEARER BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3BW1THM3";

        public bool IsSignedIn => true;

        public bool SignIn(string resource)
        {
            return true;
        }

        public bool SignOut()
        {
            return true;
        }
    }
}
