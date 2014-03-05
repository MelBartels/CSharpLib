using System;
using GenLib.Constants;
using Xunit;

namespace GenLibUnitTests.BitByte
{
    public class Encoder
    {
        private readonly GenLib.BitByte.Encoder _encoder = new GenLib.BitByte.Encoder();

        private byte[] BuildTestBytes()
        {
            return new[]
                       {
                           (byte) _encoder.Asc("h"),
                           (byte) _encoder.Asc("e"),
                           (byte) _encoder.Asc("l"),
                           (byte) _encoder.Asc("l"),
                           (byte) _encoder.Asc("o")
                       };
        }

        private byte[] BuildTestBytes2()
        {
            return new[]
                       {
                           (byte) 128,
                           (byte) 128,
                           (byte) _encoder.Asc("h"),
                           (byte) _encoder.Asc("e"),
                           (byte) _encoder.Asc("l"),
                           (byte) _encoder.Asc("l"),
                           (byte) _encoder.Asc("o"),
                           (byte) 128,
                           (byte) 128
                       };
        }

        [Fact]
        public void Asc()
        {
            Assert.Equal(104, _encoder.Asc("h"));

            Assert.True(true);
        }

        [Fact]
        public void AscChrAsc()
        {
            const int testNum = 254;
            var c = _encoder.Chr(testNum);
            Assert.Equal(testNum, _encoder.Asc(c));

            Assert.True(true);
        }

        [Fact]
        public void BufferToString()
        {
            var testBytes = BuildTestBytes2();
            Assert.Equal("hello", _encoder.BytesToString(testBytes, 2, 5));

            Assert.True(true);
        }

        [Fact]
        public void Chr()
        {
            Assert.Equal(_encoder.Chr(104), "h");

            Assert.True(true);
        }

        [Fact]
        public void Hex()
        {
            Assert.Equal("52", _encoder.Hex(_encoder.Asc("R")));
            Assert.Equal("30", _encoder.Hex(_encoder.Asc("0")));
            Assert.Equal("D", _encoder.Hex(_encoder.Asc(General.Cr)));

            Assert.True(true);
        }

        [Fact]
        public void ConvertToHex()
        {
            const string msg = "R+20000" + General.Tab + "+20000" + General.Cr;
            var result = _encoder.ConvertToHex(msg, true);
            Assert.Equal(
                "x52(R) x2B(+) x32(2) x30(0) x30(0) x30(0) x30(0) x9 x2B(+) x32(2) x30(0) x30(0) x30(0) x30(0) xD ",
                result);

            result = _encoder.ConvertToHex(msg, false);
            Assert.Equal("x52 x2B x32 x30 x30 x30 x30 x9 x2B x32 x30 x30 x30 x30 xD ", result);

            Assert.True(true);
        }

        [Fact]
        public void TestBytesToString()
        {
            var numBytes = new byte[8];
            const int test1 = 1234;
            // 0-0-4-210 
            const int test2 = 9876;
            // 0-0-38-148 
            Array.Copy(BitConverter.GetBytes(test1), 0, numBytes, 0, 4);
            Array.Copy(BitConverter.GetBytes(test2), 0, numBytes, 4, 4);

            var numString = _encoder.BytesToString(numBytes);
            Assert.Equal(8, numString.Length);

            var textBytes = BuildTestBytes();
            var textString = _encoder.BytesToString(textBytes);
            Assert.Equal("hello", textString);

            Assert.True(true);
        }

        [Fact]
        public void TestStringToBytes()
        {
            const string testString = "hello";
            var expectedTextBytes = BuildTestBytes();

            var textBytes = _encoder.StringToBytes(testString);
            Assert.Equal(expectedTextBytes, textBytes);

            // represents two int32s, values 1234 and 9876 (see above test) 
            var expectedNumBytes = new byte[] {210, 4, 0, 0, 148, 38, 0, 0};
            var numString = _encoder.BytesToString(expectedNumBytes);
            Assert.Equal(expectedNumBytes.Length, numString.Length);
            var numBytes = _encoder.StringToBytes(numString);
            Assert.Equal(expectedNumBytes, numBytes);

            Assert.True(true);
        }
    }
}