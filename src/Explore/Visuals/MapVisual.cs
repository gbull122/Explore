using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Explore.Visuals
{
    public class MapVisual : DrawingVisual,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int posTop;
        private int posLeft;

        public int PosTop
        {
            get { return posTop; }
            set { 
                posTop = value; 
                RaisePropertyChanged(nameof(posTop));
            }
        }

        public int PosLeft
        {
            get { return posLeft; }
            set
            {
                posLeft = value;
                RaisePropertyChanged(nameof(PosLeft));
            }
        }


        public MapVisual(int x, int y)
        {
            posLeft = x;
            posTop = y;
        }
    }
}
