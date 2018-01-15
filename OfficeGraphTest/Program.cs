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

            // and then, we can start to explore the fun stuff!!
            var me = await officeGraphClient.GetMyInformationAsync();
        }


        private static IOfficeGraphClient CreateAndInializeOfficeGraphClient()
        {
            // First, we'll need to authenticate ourselves against a trusted identity provider
            var identityManager = _container.GetInstance<IIdentityManager>();

            // Next, well need to connect to the office graph api, and pass it our identity token
            var officeGraphClient = _container.GetInstance<IOfficeGraphClient>();

            officeGraphClient.Initialize(identityManager);
            return officeGraphClient;
        }
    }
}
