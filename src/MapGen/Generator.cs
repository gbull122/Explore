using SharpNoise;
using SharpNoise.Builders;
using SharpNoise.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MapGen
{
    public interface IGenerator
    {
        float[] CreateNoiseMap(int width, int height);
        ImageSource CreateMapImage(float[] mapData, int width, int height);
    }

    public class Generator : IGenerator
    {


        public Generator()
        {
            
        }


        public float[] CreateNoiseMap(int width, int height)
        {
            var noiseSource = new Perlin
            {
                Seed = new Random().Next()
            };

            // Create a new, empty, noise map and initialize a new planar noise map builder with it
            var noiseMap = new NoiseMap();
            var noiseMapBuilder = new PlaneNoiseMapBuilder
            {
                DestNoiseMap = noiseMap,
                SourceModule = noiseSource
            };

            // Set the size of the noise map
            noiseMapBuilder.SetDestSize(width, height);

            // Set the bounds of the noise mpa builder
            // These are the coordinates in the noise source from which noise values will be sampled
            noiseMapBuilder.SetBounds(-3, 3, -2, 2);

            // Build the noise map - samples values from the noise module above,
            // using the bounds coordinates we have passed in the builder
            noiseMapBuilder.Build();

            return noiseMap.Data;
        }

        public float[] Normalise(float[] data, double min, double max)
        {
            var minVal = data.Min();
            var maxVal = data.Max();

            double slope = (max - min) / (maxVal - minVal);
            double offset = min - minVal * slope;
            var result = new float[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (int)(slope * data[i] + offset);
            }

            return result;
        }

        public ImageSource CreateMapImage(float[] mapData, int width, int height)
        {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < 256; i++)
            {
                colors.Add(Color.FromRgb((byte)i, (byte)i, (byte)i));
            }
            var bitmapPalette = new BitmapPalette(colors);

            var normed = Normalise(mapData, 0, 255);
            BitmapSource bitmapMap = BitmapSource.Create(width, height, 96, 96, PixelFormats.Gray8, bitmapPalette, normed, width);

            return bitmapMap;
        }
    }
}
