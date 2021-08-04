using Explore.Views;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explore.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private readonly IRegionManager regionManager;

        public MainWindowViewModel(IRegionManager regManager)
        {
            regionManager = regManager;
            regionManager.RegisterViewWithRegion("MainRegion", typeof(MapView));
        }
    }
}
