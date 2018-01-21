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

            //TODO: Add DEBUG conditionals for running unit-test-like structures
        }
    }
}
