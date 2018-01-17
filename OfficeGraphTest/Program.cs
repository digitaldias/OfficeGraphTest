using OfficeGraphTest.DependencyInversion;
using OfficeGraphTest.Domain.Contracts;
using StructureMap;
using System.Threading.Tasks;

namespace OfficeGraphTest
{
    class Program
    {
        // ensure that IOC is set up and configured 
        private static Container _container = new Container(new RuntimeRegistry());

        static void Main(string[] args)
        {
            RunExamplesAsync().Wait();

            System.Console.WriteLine("Program completed");
        }


        public static async Task RunExamplesAsync()
        {
            IOfficeGraphClient officeGraphClient = CreateAndInializeOfficeGraphClient();

            if (officeGraphClient == null)
            {
                System.Console.WriteLine("Unable to continue");
                return;
            }
            
            var me = await officeGraphClient.GetMyInformationAsync();

            System.Console.WriteLine($"Allright, {me.givenName}, let's do this!");
        }


        private static IOfficeGraphClient CreateAndInializeOfficeGraphClient()
        {
            var identityManager   = _container.GetInstance<IIdentityManager>();
            var officeGraphClient = _container.GetInstance<IOfficeGraphClient>();

            if (!officeGraphClient.Initialize())
                return null;

            return officeGraphClient;
        }
    }
}
