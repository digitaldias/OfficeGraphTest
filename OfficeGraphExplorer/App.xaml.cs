using OfficeGraphExplorer.DependencyInversion;
using StructureMap;
using System.Windows;

namespace OfficeGraphExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container IoC = new Container(new RuntimeRegistry());
    }
}
