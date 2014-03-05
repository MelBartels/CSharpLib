using Xunit;

namespace GenLibUnitTests.BitByte
{
    public class RomanNumeralConverter
    {
        private readonly GenLib.BitByte.RomanNumeralConverter _converter = new GenLib.BitByte.RomanNumeralConverter();

        [Fact]
        public void ConvertFromRomanNumeralToInt()
        {
            Assert.Equal(2916, _converter.Convert("MMCMXVI"));
            Assert.Equal(12, _converter.Convert("XII"));
            Assert.Equal(6, _converter.Convert("VI"));

            Assert.True(true);
        }
    }
}