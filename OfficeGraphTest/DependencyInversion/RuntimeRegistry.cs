﻿using StructureMap;

namespace OfficeGraphTest.DependencyInversion
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            // Don't you just love simple IoC Configurations? :)
            Scan(x => {
                x.AssembliesAndExecutablesFromApplicationBaseDirectory();

                x.WithDefaultConventions();
            });
        }
    }
}
