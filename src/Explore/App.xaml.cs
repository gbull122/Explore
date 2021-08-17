using Explore.Views;
using MapGen;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace Explore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell()
        {
            var mainWindow = Container.Resolve<MainWindow>();
            return mainWindow;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var generator = new Generator();
            containerRegistry.RegisterInstance<IGenerator>(generator);
        }
    }
}
