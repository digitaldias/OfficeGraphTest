using OfficeGraphExplorer.ViewModels;
using System.Windows;

namespace OfficeGraphExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => DataContext = new MainWindowViewModel();
        }
    }
}
