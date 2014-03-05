using Xunit;

namespace GenLibUnitTests.SFT
{
    public class SFTTag
    {
        [Fact]
        public void Tags()
        {
            Assert.Equal(5, SFTTagTestObject.Lll.Tag);
            Assert.Equal("good", SFTTagTestObject.Mmm.Tag);
            Assert.Equal(SFTTestObject.Bbb, SFTTagTestObject.Nnn.Tag);

            Assert.True(true);
        }
    }
}