using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MapGen
{
    public interface IGenerator
    {
        double[] CreateNoiseMap(int width, int height);
        ImageSource CreateMapImage(double[] mapData, int width, int height);
    }

    public class Generator : IGenerator
    {
        private INoise noise;

        public Generator(INoise noise)
        {
            this.noise = noise;
        }

        /// <summary>
        /// https://lotsacode.wordpress.com/2010/02/24/perlin-noise-in-c/
        /// </summary>
        public double[] CreateNoiseMap(int width, int height)
        {
            double[] mapData = new double[width * height];

            double widthDivisor = 1 / (double)width;
            double heightDivisor = 1 / (double)height;

            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {

                    var idx = ((i-1) * width) + j-1;


                    // First octave
                    var oct1 = (noise.Noise(2 * i * widthDivisor, 2 * j * heightDivisor, -0.5) + 1) / 2 * 0.7;
                    // Second octave
                    var oct2 = (noise.Noise(4 * i * widthDivisor, 4 * j * heightDivisor, 0) + 1) / 2 * 0.2;
                    // Third octave
                    var oct3 = (noise.Noise(8 * i * widthDivisor, 8 * j * heightDivisor, +0.5) + 1) / 2 * 0.1;
                    mapData[idx] = 255*(oct1+oct2+oct3);
                }

            }
            return mapData;
        }

        public ImageSource CreateMapImage(double[] mapData, int width,int height)
        {

            BitmapSource bitmapMap = BitmapSource.Create(width, height, 96, 96, PixelFormats.Gray8, null, mapData, width);

            return bitmapMap;
        }
    }
}
