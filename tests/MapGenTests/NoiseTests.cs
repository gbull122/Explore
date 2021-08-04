using MapGen;
using NUnit.Framework;

namespace MapGenTests
{
    [TestFixture]
    public class NoiseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoiseTest_1()
        {
            var expectedValue = 0.13691995878400012;

            Noise noise = new Noise();

            var actualValue = noise.NoisePoint(3.14, 42, 7);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}