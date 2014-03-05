using GenLibUnitTests.Extension;
using Xunit;

namespace GenLibUnitTests.Helper
{
    public class EnumHelper
    {
        [Fact]
        public void ToList()
        {
            var el = GenLib.Helper.EnumHelper.GetList<TestingEnum>();
            Assert.Equal(TestingEnum.TestingTwo, el[1]);

            Assert.True(true);
        }
    }
}