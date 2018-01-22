using OfficeGraphTest.Data.Fakes;
using OfficeGraphTest.Domain.Contracts;
using StructureMap;

namespace OfficeGraphExplorer.DependencyInversion
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            Scan(x => {
                x.AssembliesAndExecutablesFromApplicationBaseDirectory();

                x.WithDefaultConventions();
            });

#if DEBUG
            // Replace all outgoing calls with fakes
            For<IIdentityManager>().Use<FakeIdentityManager>();
            For<IOfficeGraphReader>().Use<FakeOfficeGraphReader>();
#endif
        }
    }
}
