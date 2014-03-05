using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Extension
{
    public class EnumExtension
    {
        [Fact]
        public void ConvertTo()
        {
            Assert.Equal(TestingEnum.TestingTwo, "TestingTwo".ConvertTo<TestingEnum>());

            Assert.True(true);
        }
    }
}