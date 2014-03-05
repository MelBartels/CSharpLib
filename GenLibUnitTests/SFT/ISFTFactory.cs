using GenLib.SFT;
using Xunit;

namespace GenLibUnitTests.SFT
{
    public class IsftFactory
    {
        private const int TestSize = 3;

        [Fact]
        public void FactoryBuild()
        {
            var isft = new ISFTFactory().Build(typeof (SFTFactoryTestObject).FullName).FirstItem;
            Assert.NotNull(isft);
            Assert.Equal(TestSize, isft.Size());
        }

        [Fact]
        public void Exception()
        {
            Assert.Null(new ISFTFactory().Build("xyz"));
        }
    }
}