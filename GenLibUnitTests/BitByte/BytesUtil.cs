using System.Linq;
using GenLibUnitTests.Extension;
using Xunit;

namespace GenLibUnitTests.BitByte
{
    public class BytesUtil
    {
        private readonly GenLib.BitByte.BytesUtil _bytesUtil = new GenLib.BitByte.BytesUtil();

        [Fact]
        public void Checksum()
        {
            Assert.Equal(221, _bytesUtil.Checksum(new GenLib.BitByte.Encoder().StringToBytes("123456789"), 0, 9));

            Assert.True(true);
        }

        [Fact]
        public void HasBit()
        {
            Assert.True(_bytesUtil.HasBit(15, new byte[] {1}.ToList()));
            Assert.False(_bytesUtil.HasBit(16, new byte[] {1}.ToList()));

            Assert.True(true);
        }

        [Fact]
        public void IndexOf()
        {
            _bytesUtil.IndexOf(new byte[] {1, 2, 3}, 2).ShouldBeGreaterThanOrEqualTo(0);
            Assert.Equal(-1, _bytesUtil.IndexOf(new byte[] {1, 2, 3}, 4));

            Assert.True(true);
        }

        [Fact]
        public void LowerNibble()
        {
            Assert.Equal(1, _bytesUtil.LowerNibble(17));

            Assert.True(true);
        }

        [Fact]
        public void ParseString()
        {
            const string testString = "0x01 0xf0 0x04";
            var expectedBytes = new byte[] {1, 240, 4};

            var bytes = _bytesUtil.ParseString(testString);
            for (var ix = 0; ix < expectedBytes.Length; ix++)
                Assert.Equal(expectedBytes[ix], bytes[ix]);

            Assert.Null(_bytesUtil.ParseString("xyz"));

            Assert.True(true);
        }

        [Fact]
        public void SetBit()
        {
            Assert.Equal(3, _bytesUtil.SetBit(3, 1, true));
            Assert.Equal(2, _bytesUtil.SetBit(3, 1, false));
            Assert.Equal(3, _bytesUtil.SetBit(2, 1, true));
            Assert.Equal(2, _bytesUtil.SetBit(2, 1, false));

            Assert.Equal(255, _bytesUtil.SetBit(255, 1, true));
            Assert.Equal(254, _bytesUtil.SetBit(255, 1, false));
            Assert.Equal(255, _bytesUtil.SetBit(254, 1, true));
            Assert.Equal(254, _bytesUtil.SetBit(254, 1, false));

            Assert.True(true);
        }
    }
}