using System.Windows;

namespace TextChecker
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ViewFactory factory = new ViewFactory();
            ViewInfrastructure infrastructure = factory.Create();

            infrastructure.CheckerView.DataContext = infrastructure.CheckerViewModel;
            infrastructure.CheckerView.Show();
        }
    }
}
