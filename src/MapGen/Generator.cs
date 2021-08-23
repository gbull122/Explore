using SharpNoise;
using SharpNoise.Builders;
using SharpNoise.Modules;
using SharpNoise.Utilities.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MapGen
{
    public interface IGenerator
    {
        void CreateNoiseMap(int width, int height);
        ImageSource CreateMapImage();
    }

    public class Generator : IGenerator
    {
        private NoiseMap noiseMap;

        public Generator()
        {
            
        }


        public void CreateNoiseMap(int width, int height)
        {
            var noiseSource = new Perlin
            {
                Seed = new Random().Next()
            };

            // Create a new, empty, noise map and initialize a new planar noise map builder with it
            noiseMap = new NoiseMap();
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

        }



        public ImageSource CreateMapImage()
        {

            var imageMap = new ImageMap();
            var renderer = new ImageRenderer
            {
                SourceNoiseMap = noiseMap,
                DestinationImage = imageMap
            };

            renderer.BuildTerrainGradient();

            // Before rendering the image, we could set various parameters on the renderer,
            // such as the position and color of the light source.
            // But we aren't going to bother for this sample.

            // Finally, render the image
            renderer.Render();

            var bitmapMap = imageMap.ToGdiBitmap();


            var bitmapData = bitmapMap.LockBits(new Rectangle(0, 0, bitmapMap.Width, bitmapMap.Height),System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmapMap.PixelFormat);

            var bitmapSource = BitmapSource.Create( bitmapData.Width, bitmapData.Height, bitmapMap.HorizontalResolution, bitmapMap.VerticalResolution,PixelFormats.Pbgra32, null,bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmapMap.UnlockBits(bitmapData);
            

            return bitmapSource;
        }
    }
}
