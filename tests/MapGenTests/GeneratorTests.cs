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
        public void Test1()
        {
            var height = 2;
            var width = 2;

            var expectedMapCount = 4;
            var noise = A.Fake<INoise>();
            A.CallTo(() => noise.NoisePoint(A<double>._, A<double>._, A<double>._)).Returns(1);

            var generator = new Generator(noise);

            var actualMap = generator.CreateNoiseMap(width, height);
            var actualMapCount = actualMap.Count();

            Assert.That(actualMapCount, Is.EqualTo(expectedMapCount));
        }

        [Test]
        public void Test2()
        {
            var height = 2;
            var width = 3;

            var expectedMapCount = 6;
            var noise = A.Fake<INoise>();
            A.CallTo(() => noise.NoisePoint(A<double>._, A<double>._, A<double>._)).Returns(1);

            var generator = new Generator(noise);

            var actualMap = generator.CreateNoiseMap(width, height);
            var actualMapCount = actualMap.Count();

            Assert.That(actualMapCount, Is.EqualTo(expectedMapCount));
        }
    }
}
