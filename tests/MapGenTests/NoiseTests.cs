using MapGen;
using NUnit.Framework;

namespace MapGenTests
{
    [TestFixture]
    public class NoiseTests
    {

        [Test]
        public void NoiseTest_1()
        {
            var expectedValue = 0.13691995878400012;

            PerlinNoise noise = new PerlinNoise(12);

            var actualValue = noise.Noise(3.14, 1, 1);

            Assert.That(actualValue, Is.InRange(0,255));
        }
    }
}