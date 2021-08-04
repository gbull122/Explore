using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGen
{
    public interface IGenerator
    {
        double[] CreateNoiseMap(int width, int height);
    }

    public class Generator : IGenerator
    {
        private INoise noise;

        public Generator(INoise noise)
        {
            this.noise = noise;
        }

        public double[] CreateNoiseMap(int width, int height)
        {
            double[] mapData = new double[width * height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var idx = (j * width) + i;
                    mapData[idx] = noise.NoisePoint(i, j, 1);
                }

            }
            return mapData;
        }
    }
}
