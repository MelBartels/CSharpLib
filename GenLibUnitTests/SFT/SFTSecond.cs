using GenLib.SFT;
using Xunit;

namespace GenLibUnitTests.SFT
{
    public class SFTSecond
    {
        private const string NextTestName = "Bbb";
        private const string SecondTestName = "Ddd";
        private const int TestSize = 3;

        private readonly ISFT _testIsfTcopy;
        private readonly ISFT _testIsft;

        public SFTSecond()
        {
            _testIsft = new SFTTestObject().FirstItem;
            _testIsfTcopy = new SFTSecondTestObject().FirstItem;
        }

        [Fact]
        public void FirstItemsNotSame()
        {
            Assert.NotSame(_testIsft.FirstItem(), _testIsfTcopy.FirstItem());

            Assert.True(true);
        }

        [Fact]
        public void MatchString()
        {
            Assert.Equal(SecondTestName, _testIsfTcopy.Match(SecondTestName).Name);
            Assert.Null(_testIsft.Match(SecondTestName));

            Assert.True(true);
        }

        [Fact]
        public void Size()
        {
            Assert.Equal(TestSize, _testIsft.Size());
            Assert.Equal(TestSize, _testIsfTcopy.Size());

            Assert.True(true);
        }

        [Fact]
        public void SizeAndNextItemTest()
        {
            Assert.Equal(NextTestName, _testIsft.NextItem().Name);

            Assert.True(true);
        }
    }
}