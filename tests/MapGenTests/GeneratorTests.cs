using FakeItEasy;
using MapGen;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenTests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void WhenSquare_NoiseHasCorrectCount()
        {
            var height = 2;
            var width = 2;

            var expectedMapCount = 4;
            var noise = A.Fake<INoise>();
            A.CallTo(() => noise.Noise(A<double>._, A<double>._, A<double>._)).Returns(1);

            var generator = new Generator(noise);

            var actualMap = generator.CreateNoiseMap(width, height);
            var actualMapCount = actualMap.Count();

            Assert.That(actualMapCount, Is.EqualTo(expectedMapCount));
        }

        [Test]
        public void WhenNotSquare_NoiseHasCorrectCount()
        {
            var height = 2;
            var width = 4;

            var expectedMapCount = 8;
            var noise = A.Fake<INoise>();
            A.CallTo(() => noise.Noise(A<double>._, A<double>._, A<double>._)).Returns(1);

            var generator = new Generator(noise);

            var actualMap = generator.CreateNoiseMap(width, height);
            var actualMapCount = actualMap.Count();

            Assert.That(actualMapCount, Is.EqualTo(expectedMapCount));
        }

        [Test]
        public void MapImageHasCorrectDimension()
        {
            var height = 3;
            var width = 3;

            var imageArray = new double[] {1,2,3,4,5,6,7,8,9 };
            var noise = A.Fake<INoise>();

            var generator = new Generator(noise);

            var actualImage = generator.CreateMapImage(imageArray, width, height);

            var actualWidth = actualImage.Width;
            var actualHeight = actualImage.Height;

            Assert.That(width, Is.EqualTo(actualWidth));
            Assert.That(height, Is.EqualTo(actualHeight));
        }
    }
}
