using Explore.Visuals;
using MapGen;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Explore.ViewModels
{
    public class MapViewModel: BindableBase
    {
        private readonly IGenerator generator;

        public DelegateCommand<string> GenCommand { get; private set; }

        public ObservableCollection<MapVisual> MapVisuals;

        private ImageSource imageMap;

        public ImageSource ImageMap
        {
            get { return imageMap; }
            set
            {
                imageMap = value;
                RaisePropertyChanged(nameof(imageMap));
            }
        }

        public MapViewModel(IGenerator gen)
        {
            generator = gen;

            GenCommand = new DelegateCommand<string>(GenMap, CanGenMap);

            MapVisuals = new ObservableCollection<MapVisual>(); 
        }

        private bool CanGenMap(string arg)
        {
            return true;
        }

        private void GenMap(string obj)
        {
            int width = 1000;
            int height = 750;


            generator.CreateNoiseMap(width,height);

            ImageMap = generator.CreateMapImage();
        }
    }
}
