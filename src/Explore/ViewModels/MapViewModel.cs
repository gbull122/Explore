using MapGen;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explore.ViewModels
{
    public class MapViewModel: BindableBase
    {
        private readonly IGenerator generator;

        public MapViewModel(IGenerator gen)
        {
            generator = gen;
        }
    }
}
