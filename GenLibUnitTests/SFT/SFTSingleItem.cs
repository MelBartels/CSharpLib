using Xunit;

namespace GenLibUnitTests.SFT
{
    public class SFTSingleItem
    {
        private const string TestName = "Aaa";

        [Fact]
        public void Name()
        {
            var s = SFTSingleItemTestObject.Aaa.Name;
            Assert.Equal(s, TestName);

            Assert.True(true);
        }
    }
}